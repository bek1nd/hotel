using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ContactInfo.BLL
{
    public interface IContactInfoBLL<T> where T : class
    {
        /// <summary>
        /// 获取对应客户下乘机人的联系人信息
        /// </summary>
        /// <returns></returns>
        List<T> GetPassengerContactInfoList(List<int> cidList);
        /// <summary>
        /// 获取当前客户的联系人信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        T GetPassengerContactInfo(int cid);
        /// <summary>
        /// 根据Cid获取联系人信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        List<T> GetPassengerContactInfoList(int cid);
        /// <summary>
        /// 新增联系人信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddContact(T t);

        /// <summary>
        /// 修改联系人信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="paramStrings"></param>
        /// <returns></returns>
        int UpdateContact(T t, string[] paramStrings = null);
    }
}
