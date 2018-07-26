using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Flight;
using Mzl.Framework.UnitOfWork;
using Mzl.IBLL.Customer.Corp;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Common.Operator;
using Mzl.DomainModel.Common.Operator;
using Mzl.Common.EmailHelper;

namespace Mzl.Application.Flight
{
    internal class AddFltDomesticModApplyApplication : BaseApplicationService, IAddFltDomesticModApplyApplication
    {
        private readonly IAddFltDomesticModApplyServiceBll _addFltDomesticModApplyServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        private readonly IGetOperatorServiceBll _getOperatorServiceBll;

        public AddFltDomesticModApplyApplication(IAddFltDomesticModApplyServiceBll addFltDomesticModApplyServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetCorpServiceBll getCorpServiceBll, IGetOperatorServiceBll getOperatorServiceBll)
        {
            _addFltDomesticModApplyServiceBll = addFltDomesticModApplyServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpServiceBll = getCorpServiceBll;
            _getOperatorServiceBll = getOperatorServiceBll;
        }


        public AddModApplyResponseViewModel AddModApply(AddModApplyRequestViewModel request)
        {
            int rmid = 0;

            AddRetModApplyModel modApplyModel = Mapper.Map<AddModApplyRequestViewModel, AddRetModApplyModel>(request);

            //1.获取改签乘客
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            modApplyModel.Customer = customerModel;
            modApplyModel.IsOnlineRefund = request.IsOnline;
            modApplyModel.OrderType = "M";
            modApplyModel.CorpId = customerModel.CorpID;

            CorporationModel corporationModel= _getCorpServiceBll.GetCorp(customerModel.CorpID);
            if (corporationModel.IsAmplitudeCorp == "T")
                modApplyModel.OrderStatus = "T";
           

            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    rmid = _addFltDomesticModApplyServiceBll.AddModApply(modApplyModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
            new TaskFactory().StartNew(() =>
            {
                //2.发送提醒邮件
                OperatorModel operatorModel = _getOperatorServiceBll.GetOperatorByOid(corporationModel.ResponsibleOid);
                string mail = operatorModel.Email;
                string corporationName = corporationModel.CorpName;

                StringBuilder mailContent = new StringBuilder();
                mailContent.Append("<b>客户改签提醒：<b/>");
                mailContent.Append("<br/>");
                mailContent.Append("[" + corporationName + "] 已经申请了改签，订单编号:" + request.OrderId.ToString() + "，请差旅顾问及时处理！");
                mailContent.Append("<br/>");
                mailContent.Append("<b>下单时间:" + DateTime.Now + ",请及时关注~<b/>");
                if (!string.IsNullOrEmpty(mail))
                {  bool flag = EmailHelper.SendEmail("", "客户改签提醒", null, null, mailContent.ToString(), mail);}
                   
            });

            return new AddModApplyResponseViewModel() { Rmid = rmid };
        }
    }
}
