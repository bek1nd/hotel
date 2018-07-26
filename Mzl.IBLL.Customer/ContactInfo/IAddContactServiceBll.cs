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
    public interface IAddContactServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 新增联系人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AddResultBaseModel<int> Add(AddContactModel model);
    }
}
