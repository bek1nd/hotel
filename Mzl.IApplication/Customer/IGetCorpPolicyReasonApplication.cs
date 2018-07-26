using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Corporation;

namespace Mzl.IApplication.Customer
{
    public interface IGetCorpPolicyReasonApplication: IBaseApplication
    {
        /// <summary>
        /// 根据公司Id获取差旅政策选择原因
        /// </summary>
        /// <returns></returns>
        GetCorpPolicyReasonResponseViewModel GetCorpPolicyReasonByCorpId(GetCorpPolicyReasonRequestViewModel request);
    }
}
