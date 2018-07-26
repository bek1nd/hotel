using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.AppOpinion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Customer
{
    public interface IGetAppOpinionListApplication:IBaseApplication
    {
        GetAppOpinionListResponseViewModel GetAppinionList(GetAppOpinionListRequestViewModel query);
    }
}
