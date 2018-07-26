using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    public interface IUpdateCustomerApplication : IBaseApplication
    {
        /// <summary>
        /// 修改客户头像路径
        /// </summary>
        /// <returns></returns>
        UpdateCustomerHeadPictureResponseViewModel UpdateCustomerHeadPicture(UpdateCustomerHeadPictureRequestViewModel request);
        /// <summary>
        /// 修改客户基本信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateCustomerInfoResponseViewModel UpdateCustomerInfo(UpdateCustomerInfoRequestViewModel request);
    }
}
