using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Common.Insurance;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    internal class GetAduitOrderApplication : BaseApplicationService, IGetAduitOrderApplication
    {
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetFltOrderBll _getFltOrderBll;


        public GetAduitOrderApplication(IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetFltOrderBll getFltOrderBll)
        {
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getFltOrderBll = getFltOrderBll;
        }

        public GetAduitOrderResponseViewModel GetAuditOrder(GetAduitOrderRequestViewModel request)
        {

            CorpAduitOrderInfoModel corpAduitOrder =
                _getCorpAduitOrderServiceBll.GetAduitOrderInfoById(request.AduitOrderId);

            if (request.OrderSource != "O" && (corpAduitOrder.AduitCidList == null ||
                                               !corpAduitOrder.AduitCidList.Contains(request.Cid)))
                throw new Exception("您无权查看该审批单");

            if (corpAduitOrder.OrderDetailList != null && corpAduitOrder.OrderDetailList.Count > 0)
            {
                //查询机场信息
                _getFltOrderBll.AportInfo = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
               

                foreach (var detail in corpAduitOrder.OrderDetailList)
                {
                    //机票
                    if (detail.OrderTypeEnum == OrderSourceTypeEnum.Flt)
                    {
                        detail.FltOrder = _getFltOrderBll.GetFltOrderById(detail.OrderId);
                    }
                }
            }

            GetAduitOrderResponseViewModel viewModel =
                Mapper.Map<CorpAduitOrderInfoModel, GetAduitOrderResponseViewModel>(corpAduitOrder);

            return viewModel;
        }
    }
}
