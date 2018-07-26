using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IGetAppOpinionListServiceBll:IBaseServiceBll
    {
        AppOpinionDomainModelList GetAppOpinionList(QueryAppOpinionDomainModel query);
    }
}
