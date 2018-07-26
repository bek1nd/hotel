using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Corp;
using Mzl.Framework.Base;
using Mzl.EntityModel.Customer.Corporation.Corp;

namespace Mzl.IBLL.Customer.Corp
{
    public interface IGetCorpServiceBll : IBaseServiceBll
    {
        CorporationModel GetCorp(string corpId);
        int UpdateCorpIndividuation(CorporationModel par);
    }
}
