using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Login;
using Mzl.DomainModel.Customer.Corp;
using Mzl.UIModel.Customer.Corporation;

namespace Mzl.IApplication.Customer
{
    public interface ICorpIndividuationApplication : IBaseApplication
    {
        ///
        ///用户个性化服务更新
        ///
        int UpdateCorpIndividuation(GetCorpIndividuationRequestViewModel parameter);
    }
}
