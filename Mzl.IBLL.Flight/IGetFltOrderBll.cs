using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight
{
    public interface IGetFltOrderBll
    {
        SearchCityAportModel AportInfo { set; }
        List<ProjectNameModel> ProjectNameList { set; }
        List<InsuranceCompanyModel> InsuranceCompanyList { set; }
        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        FltOrderInfoModel GetFltOrderById(int orderId);
        List<FltOrderInfoModel> GetFltOrderListById(List<int> orderIdList);
    }
}
