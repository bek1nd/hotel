using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface IGetContactServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取差旅客户对应信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        GetContactInfoModel GetCorpContactByCid(int cid);
        /// <summary>
        /// 获取客户对应的联系人信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        List<GetContactInfoModel> GetContactByCid(int cid);
    }
}
