using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Identification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Customer
{
    public interface IPostIdentificationApplication : IBaseApplication
    {
        bool PostIdentification(IdentificationViewModel model, int cid);
    }
}
