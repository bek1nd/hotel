using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    /// <summary>
    /// 新增联系人信息
    /// </summary>
    public interface IAddContactApplication : IBaseApplication
    {
        AddContactResponseViewModel AddContact(AddContactRequestViewModel request);
    }
}
