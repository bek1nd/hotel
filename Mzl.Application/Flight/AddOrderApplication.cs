using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.Framework.UnitOfWork;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.Operator;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.IBLL.Common.Operator;
using Mzl.IBLL.Customer.Corp;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IBLL.Customer.CostCenter;
using Mzl.Common.EmailHelper;

namespace Mzl.Application.Flight
{
    /// <summary>
    /// 添加订单应用层
    /// </summary>
    internal class AddOrderApplication : BaseApplicationService, IAddOrderApplication
    {
        private readonly IAddOrderServiceBll _addOrderServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpPassengerCustomerServiceBll _getCorpPassengerCustomerServiceBll;
        private readonly IGetPnrNoServiceBll _getPnrNoServiceBll;
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        private readonly ISubmitCorpAduitOrderServiceBll _submitCorpAduitOrderServiceBll;//送审服务
        private readonly IGetOperatorServiceBll _getOperatorServiceBll;

        public AddOrderApplication(IAddOrderServiceBll addOrderServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll,
            IGetCorpPassengerCustomerServiceBll getCorpPassengerCustomerServiceBll,
            IGetPnrNoServiceBll getPnrNoServiceBll, IGetCorpServiceBll getCorpServiceBll,
            ISubmitCorpAduitOrderServiceBll submitCorpAduitOrderServiceBll,
            IGetOperatorServiceBll getOperatorServiceBll) 
        {
            _addOrderServiceBll = addOrderServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpPassengerCustomerServiceBll = getCorpPassengerCustomerServiceBll;
            _getPnrNoServiceBll = getPnrNoServiceBll;
            _getCorpServiceBll = getCorpServiceBll;
            _submitCorpAduitOrderServiceBll = submitCorpAduitOrderServiceBll;//送审服务
            _getOperatorServiceBll = getOperatorServiceBll;
        }

        /// <summary>
        /// 创建机票订单
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        public AddOrderResponseViewModel AddDomesticOrderApplicationService(AddOrderRequestViewModel orderViewModel)
        {
            string oidTemp = orderViewModel.CreateOid;
            int orderid = 0;
            AddOrderModel addOrderModel = Mapper.Map<AddOrderRequestViewModel, AddOrderModel>(orderViewModel);
            //0.获取客户信息服务
            addOrderModel.Customer = _getCustomerServiceBll.GetCustomerByCid(orderViewModel.Cid);
            if (!string.IsNullOrEmpty(addOrderModel.Customer.CorpID))
            {
                CorporationModel corporationModel = _getCorpServiceBll.GetCorp(addOrderModel.Customer.CorpID);
                if (!addOrderModel.IsPrint.HasValue)
                {
                    addOrderModel.IsPrint = corporationModel.IsPrint ?? 0;
                }
                if (!string.IsNullOrEmpty(corporationModel.ResponsibleOid) && orderViewModel.OrderSource != "O")
                {
                    addOrderModel.CreateOid = corporationModel.ResponsibleOid;
                }
            }


            //1.获取乘机人的联系人Id对应的乘客信息
            List<int> contactList = addOrderModel.PassengerList.Select(n => n.Contactid ?? 0).ToList();
            addOrderModel.PassengerCustomerList= _getCorpPassengerCustomerServiceBll.GetCorpPassengerCustomer(contactList);

            OperatorModel operatorModel = _getOperatorServiceBll.GetOperatorByOid(addOrderModel.CreateOid);


            //2.创建订单服务
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    orderid = _addOrderServiceBll.AddDomesticOrder(addOrderModel);

                    #region 送审

                    if (orderid > 0)
                    {
                        SubmitCorpAduitOrderModel submitCorpAduitOrder = new SubmitCorpAduitOrderModel()
                        {
                            OrderInfoList = new List<SubmitCorpAduitOrderDetailModel>()
                            {
                                new SubmitCorpAduitOrderDetailModel()
                                {
                                    OrderId = orderid,
                                    OrderType = OrderSourceTypeEnum.Flt
                                }
                            },
                            PolicyId = addOrderModel.CorpPolicyId,
                            AduitConfigId = addOrderModel.CorpAduitId,
                            Source = orderViewModel.OrderSource,
                            SubmitCid = orderViewModel.Cid,
                            SubmitOid = oidTemp,
                            IsViolatePolicy =
                                (addOrderModel.FlightList.Find(n => !string.IsNullOrEmpty(n.CorpPolicy)) != null
                                    ? true
                                    : false),
                            OrderType = OrderSourceTypeEnum.Flt
                        };
                        _submitCorpAduitOrderServiceBll.Submit(submitCorpAduitOrder);
                    }

                    #endregion

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            string PNRstr = "";//获取后邮件中使用
            string testCid= AppSettingsHelper.GetAppSettings(AppSettingsEnum.TestCid);//生产环境，测试帐号不许定位
            if (testCid != orderViewModel.Cid.ToString())
            {
                //3.调取pnr定位服务
                PNRstr = _getPnrNoServiceBll.GetPnrNo(orderid, operatorModel?.Email);
            }
            //4.发送提醒邮件
            new TaskFactory().StartNew(() =>
            {

                string mail = operatorModel.Email;
                string corporationName = addOrderModel.PassengerCustomerList[0].Corporation.CorpName;
                string operatorName = addOrderModel.Cname;
                string dport = addOrderModel.FlightList[0].Dport;
                string aport = addOrderModel.FlightList[0].Aport;
                string aDate = addOrderModel.FlightList[0].TackoffTime.ToString();
                string bDate = addOrderModel.FlightList[0].ArrivalsTime.ToString();
                StringBuilder mailContent = new StringBuilder();
                mailContent.Append("<b>订单生成提醒：<b/>");
                mailContent.Append("<br/>");
                mailContent.Append("[" + corporationName + "] 已生成订单:" + orderid + "，请差旅顾问及时处理！");
                mailContent.Append("<br/>");
                mailContent.Append("联系人姓名：" + addOrderModel.Cname + "");
                mailContent.Append("<br/>");
                mailContent.Append("行程：" + dport + " - " + aport + "");
                mailContent.Append("<br/>");
                mailContent.Append("起飞时间：" + aDate + "");
                mailContent.Append("<br/>");
                mailContent.Append("抵达时间：" + bDate + "");
                mailContent.Append("<br/>");
                mailContent.Append("<b>下单时间:" + DateTime.Now + ",请及时关注~<b/>");
                if (!string.IsNullOrEmpty(mail))
                {bool flag = EmailHelper.SendEmail("", "订单生成提醒", null, null, mailContent.ToString(), mail); }
                    
            
            });
        
            return new AddOrderResponseViewModel() {OrderId = orderid};
        }
        
    }
}
