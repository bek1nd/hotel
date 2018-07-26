using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.Corp;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Train.Order;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.UIModel.Train.Order;

namespace Mzl.Application.Train
{
    internal class AddTraOrderApplication: BaseApplicationService, IAddTraOrderApplication
    {
        private readonly IAddTraOrderServiceBll _addTraOrderServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        private readonly IRequestHoldSeatServiceBll _requestHoldSeatServiceBll;
        private readonly ISubmitCorpAduitOrderServiceBll _submitCorpAduitOrderServiceBll;//送审服务


        public AddTraOrderApplication(IAddTraOrderServiceBll addTraOrderServiceBll,
              IGetCustomerServiceBll getCustomerServiceBll, IGetCorpServiceBll getCorpServiceBll,
              IRequestHoldSeatServiceBll requestHoldSeatServiceBll,
              ISubmitCorpAduitOrderServiceBll submitCorpAduitOrderServiceBll)
        {
            _addTraOrderServiceBll = addTraOrderServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpServiceBll = getCorpServiceBll;
            _requestHoldSeatServiceBll = requestHoldSeatServiceBll;
            _submitCorpAduitOrderServiceBll = submitCorpAduitOrderServiceBll;
        }

        public AddTraOrderResponseViewModel AddTraOrder(AddTraOrderRequestViewModel request)
        {
            //判断是否是生产环境，如果不是则强制request.AddOrderType=1，不走接口
            string oidTemp = request.Order.CreateOid;
            TraAddOrderResultModel addOrderResultModel = new TraAddOrderResultModel();
            TraAddOrderModel addOrderModel = Mapper.Map<AddTraOrderRequestViewModel, TraAddOrderModel>(request);
            addOrderModel.Order.Cid = request.Cid;
            addOrderModel.Order.OrderSource = request.OrderSource;

            

            //0.获取客户信息服务
            addOrderModel.Customer = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            if (!string.IsNullOrEmpty(addOrderModel.Customer.CorpID))
            {
                CorporationModel corporationModel = _getCorpServiceBll.GetCorp(addOrderModel.Customer.CorpID);
                if (!addOrderModel.Order.IsPrint.HasValue)
                {
                    addOrderModel.Order.IsPrint = corporationModel.IsPrint ?? 0;
                }
                if (!string.IsNullOrEmpty(corporationModel.ResponsibleOid) && request.OrderSource != "O")
                {
                    addOrderModel.Order.CreateOid = corporationModel.ResponsibleOid;
                    if (addOrderModel.OrderStatus == null)
                    {
                        addOrderModel.OrderStatus = new TraOrderStatusModel();
                    }
                    if ((addOrderModel.OrderStatus.ProccessStatus & 64) != 64)
                    {
                        addOrderModel.OrderStatus.ProccessStatus = addOrderModel.OrderStatus.ProccessStatus + 64;
                    }
                }
            }

            //1.添加火车订单
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    /***
                     * 1)手动路线：
                     * 添加完订单，直接发起送审
                     * 2)自动路线：
                     * 添加完订单，不发起送审，发起申请占位请求，在确认占位后再发起送审
                     * **/
                    addOrderResultModel = _addTraOrderServiceBll.AddTraOrder(addOrderModel);

                    #region 送审

                    if (addOrderResultModel.OrderId > 0&& request.AddOrderType == 1)//手动路线发起送审
                    {
                        SubmitCorpAduitOrderModel submitCorpAduitOrder = new SubmitCorpAduitOrderModel()
                        {
                            OrderInfoList = new List<SubmitCorpAduitOrderDetailModel>()
                            {
                                new SubmitCorpAduitOrderDetailModel()
                                {
                                    OrderId = addOrderResultModel.OrderId,
                                    OrderType = OrderSourceTypeEnum.Tra
                                }
                            },
                            PolicyId = addOrderModel.Order.CorpPolicyId,
                            AduitConfigId = addOrderModel.Order.CorpAduitId,
                            Source = request.OrderSource,
                            SubmitCid = request.Cid,
                            SubmitOid = oidTemp,
                            IsViolatePolicy =
                                (addOrderModel.OrderDetailList.Find(n => !string.IsNullOrEmpty(n.CorpPolicy)) != null
                                    ? true
                                    : false),
                            OrderType = OrderSourceTypeEnum.Tra
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

            if (request.AddOrderType == 0)//自动路线发起占位申请
            {
                //2.发起火车占位
                _requestHoldSeatServiceBll.RequestHoldSeat(addOrderResultModel.AddOrderModel);
            }


            return new AddTraOrderResponseViewModel()
            {
                OrderId = addOrderResultModel.OrderId,
                AddOrderType = request.AddOrderType
            };
        }
    }
}
