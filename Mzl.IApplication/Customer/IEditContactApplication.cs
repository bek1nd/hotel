using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    public interface IEditContactApplication : IBaseApplication
    {
        /// <summary>
        /// 修改联系人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        EditContactResponseViewModel EditContact(EditContactRequestViewModel request);
    }
}
