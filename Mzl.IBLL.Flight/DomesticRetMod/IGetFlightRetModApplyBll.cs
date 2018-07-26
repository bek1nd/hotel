using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    public interface IGetFlightRetModApplyBll
    {
        SearchCityAportModel AportInfo { set; }
        /// <summary>
        /// 违反差旅政策原因
        /// </summary>
        List<ChoiceReasonModel> PolicyReasonList { set; }
        /// <summary>
        /// 根据申请Id获取改签/退票申请信息
        /// </summary>
        /// <param name="rmid"></param>
        /// <returns></returns>
        FltRetModApplyModel GetRetModApply(int rmid);
        /// <summary>
        /// 根据多个申请Id获取多个改签/退票申请信息
        /// </summary>
        /// <param name="rmid"></param>
        /// <returns></returns>
        List<FltRetModApplyModel> GetRetModApply(List<int> rmid);
    }
}
