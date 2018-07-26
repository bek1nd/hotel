using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.DomainModel.Customer.AppOpinion;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IAddAppOpinionServiceBll : IBaseServiceBll
    {
        AppOpinionDomainModel AddOpinion(AppOpinionModel appOpinionModel);
    }
}
