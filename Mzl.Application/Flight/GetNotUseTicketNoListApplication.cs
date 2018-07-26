using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    public class GetNotUseTicketNoListApplication: BaseApplicationService,IGetNotUseTicketNoListApplication
    {
        private readonly IGetNotUseTicketNoListServiceBll _getNotUseTicketNoListServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public GetNotUseTicketNoListApplication(IGetNotUseTicketNoListServiceBll getNotUseTicketNoListServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll)
        {
            _getNotUseTicketNoListServiceBll = getNotUseTicketNoListServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }
        
        public GetNotUseTicketNoViewModel GetNotUseNationTicketNoList(GetNotUseTicketNoQueryViewModel request)
        {
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            //3.查询机票订单

            GetNotUseTicketNoQueryModel query = Mapper.Map<GetNotUseTicketNoQueryViewModel, GetNotUseTicketNoQueryModel>(request);
            query.AportInfo = aportModel;
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;
            //3.1判断是否是administrator帐号，如果是则获取当前公司下所有订单
            if (customerModel.UserID.ToLower() == "administrator")
            {
                query.Cid = null;
            }
           

            GetNotUseTicketNoModel notUseTicketNoModel= _getNotUseTicketNoListServiceBll.GetNotUseNationTicketNoList(query);
            GetNotUseTicketNoViewModel viewModel = Mapper.Map<GetNotUseTicketNoModel, GetNotUseTicketNoViewModel>(notUseTicketNoModel);
            return viewModel;
        }
    }
}
