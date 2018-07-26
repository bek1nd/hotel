using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;
using AutoMapper;

namespace Mzl.Application.Flight
{
    public class GetFltDomesticModApplyViewApplication : BaseApplicationService,IGetFltDomesticModApplyViewApplication
    {
        private readonly IGetFltDomesticModApplyViewServiceBll _getFltDomesticModApplyViewServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public GetFltDomesticModApplyViewApplication(
            IGetFltDomesticModApplyViewServiceBll getFltDomesticModApplyViewServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll) : base()
        {
            _getFltDomesticModApplyViewServiceBll = getFltDomesticModApplyViewServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public GetModApplyResponseViewModel GetFltDomesticModApply(GetModApplyRequestViewModel request)
        {
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            GetModApplyQueryModel query = Mapper.Map<GetModApplyRequestViewModel, GetModApplyQueryModel>(request);
            query.AportInfo = aportModel;
            query.Customer = customerModel;

            if (customerModel.UserID.ToLower() == "administrator" && !string.IsNullOrEmpty(customerModel.CorpID))
            {
                throw new Exception("administrator帐号无法提交改签申请");
            }

            GetModApplyModel dataModel = _getFltDomesticModApplyViewServiceBll.GetModApplyView(query);

            GetModApplyResponseViewModel viewModel = Mapper.Map<GetModApplyModel, GetModApplyResponseViewModel>(dataModel);

            return viewModel;
        }
    }
}
