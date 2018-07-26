using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Train.Order.OrderDetail;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Train.Order;
using Mzl.UIModel.Train.Order.OrderDetail;

namespace Mzl.Application.Train
{
    internal class GetTraOrderDetailApplication : BaseApplicationService, IGetTraOrderDetailApplication
    {
        private readonly IGetTraOrderDetailServiceBll _getTraOrderDetailServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly ICheckAduitOrderServiceBll _checkAduitOrderServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;




        public GetTraOrderDetailApplication(IGetTraOrderDetailServiceBll getTraOrderDetailServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, ICheckAduitOrderServiceBll checkAduitOrderServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _getTraOrderDetailServiceBll = getTraOrderDetailServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _checkAduitOrderServiceBll = checkAduitOrderServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        /// <summary>
        /// 获取订单详情信息（app）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetTraOrderDetailResponseViewModel GetTraOrderDetailFromAppByOrderId(GetTraOrderDetailRequestViewModel request)
        {
            if (request.OrderId==0)
                throw new Exception("请传入订单Id");

            //根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            GetTraOrderDetailInfoQueryModel query = new GetTraOrderDetailInfoQueryModel()
            {
                OrderId = request.OrderId,
                Cid = request.Cid,
                Customer = customerModel
            };

            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(customerModel.CorpID);
            }
            //判断当前客户是该订单的审批人
            query.IsFromAduitQuery = _checkAduitOrderServiceBll.CheckAduitCidHasOrderId(request.Cid,request.OrderId);
            GetTraOrderDetailInfoModel model =
                _getTraOrderDetailServiceBll.GetTraOrderDetailFromAppByOrderId(query);

            if (model == null || model.TraOrder == null)
                throw new Exception("查无此订单");

            List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                     _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(model.OrderId);
            if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
            {
                model.TraOrder.AduitOrderId = corpAduitOrderInfoModels[0].AduitOrderId;
                model.TraOrder.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                {
                    model.TraOrder.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                    if (corpAduitOrderInfoModels[0].NextAduitCidList.Contains(request.Cid))
                        model.TraOrder.IsCurrentCustomerAduitOrder = true;
                }
            }

            GetTraOrderDetailResponseViewModel viewModel = Mapper.Map<GetTraOrderDetailInfoModel, GetTraOrderDetailResponseViewModel>(model);
            return viewModel;
        }
    }
}
