using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ContactInfo.BLL
{
    public interface IContactIdentificationInfoBLL<T> where T : class
    {
        /// <summary>
        /// 根据联系人Id获取证件信息几号
        /// </summary>
        /// <param name="contactIdList"></param>
        /// <returns></returns>
        List<T> GetIdentificationInfoByContactId(List<int> contactIdList);
        /// <summary>
        /// 新增联系人证件信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddIdentificationInfo(T t);
        /// <summary>
        /// 修改联系人证件信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="paramStrings"></param>
        /// <returns></returns>
        int UpdateIdentificationInfo(T t, string[] paramStrings = null);
    }
}
