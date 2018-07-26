using Mzl.Framework.Base;
using Mzl.UIModel.Common.Insurance;

namespace Mzl.IApplication.Common
{
    public interface IGetInsuranceProductApplication : IBaseApplication
    {
        /// <summary>
        /// 获取线上保险信息
        /// </summary>
        /// <returns></returns>
        InsuranceProductResponseViewModel GetOnlineInsuranceProductList();
    }
}
