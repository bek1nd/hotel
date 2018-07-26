using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface IEditContactServiceBll : IBaseServiceBll
    {
        AddResultBaseModel<int> Edit(EditContactModel model);
    }
}
