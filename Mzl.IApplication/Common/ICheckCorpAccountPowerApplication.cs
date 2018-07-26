using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Common.CheckAccount;

namespace Mzl.IApplication.Common
{
    /// <summary>
    /// 判断当前帐号是否具有页面权限
    /// </summary>
    public interface ICheckCorpAccountPowerApplication : IBaseApplication
    {
        CheckCorpAccountPowerResponseViewModel CheckCorpAccountPower(CheckCorpAccountPowerRequestViewModel request);
    }
}
