using Mzl.DomainModel.Customer.Identification;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IPostIdentificationServiceBll : IBaseServiceBll
    {
        bool PostIdentification(IdentificationModel model, int cid);
    }
}
