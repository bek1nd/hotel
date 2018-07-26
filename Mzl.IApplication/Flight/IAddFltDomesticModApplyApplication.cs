using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface IAddFltDomesticModApplyApplication : IBaseApplication
    {
        /// <summary>
        /// 添加改签申请
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddModApplyResponseViewModel AddModApply(AddModApplyRequestViewModel request);
    }
}
