using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class GetFltDomesticRetApplyViewApplication : BaseApplicationService,IGetFltDomesticRetApplyViewApplication
    {
        private readonly IGetFltDomesticRetApplyViewServiceBll _getFltDomesticRetApplyViewServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;


        public GetFltDomesticRetApplyViewApplication(
            IGetFltDomesticRetApplyViewServiceBll getFltDomesticRetApplyViewServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll) : base()
        {
            _getFltDomesticRetApplyViewServiceBll = getFltDomesticRetApplyViewServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }


        public GetRetApplyResponseViewModel GetRetApplyView(GetRetApplyRequestViewModel request)
        {
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() {"N"});
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            GetRetApplyQueryModel query = Mapper.Map<GetRetApplyRequestViewModel, GetRetApplyQueryModel>(request);
            query.AportInfo = aportModel;
            query.Customer = customerModel;
            if (customerModel.UserID.ToLower() == "administrator" && !string.IsNullOrEmpty(customerModel.CorpID))
            {
               throw new Exception("administrator帐号无法提交退票申请");
            }
            GetRetApplyModel dataModel = _getFltDomesticRetApplyViewServiceBll.GetRetApply(query);

            GetRetApplyResponseViewModel viewModel =
                Mapper.Map<GetRetApplyModel, GetRetApplyResponseViewModel>(dataModel);
            viewModel.ServiceFee = (dataModel.FlightList[0].ServiceFee ?? 0);

            return viewModel;
        }
    }
}
