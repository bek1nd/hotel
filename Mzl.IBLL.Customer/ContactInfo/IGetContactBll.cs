using Mzl.DomainModel.Customer.ContactInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface IGetContactBll
    {
        List<ContactInfoModel> GetContactByContactId(List<int> contactIdList);
        /// <summary>
        /// 获取差旅客户对应信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        ContactInfoModel GetCorpContactByCid(int cid);
        /// <summary>
        /// 获取差旅客户对应信息
        /// </summary>
        /// <param name="cidList"></param>
        /// <returns></returns>
        List<ContactInfoModel> GetCorpContactByCid(List<int> cidList);
        /// <summary>
        /// 查询当前用户下的联系人信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        List<ContactInfoModel> GetContactByCid(int cid);

        /// <summary>
        /// 查询当前用户下的联系人信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="args">搜索条件</param>
        /// <returns></returns>
        List<ContactInfoModel> GetContactByCid(int cid,string args);
        /// <summary>
        /// 查询当前用户下的联系人信息
        /// </summary>
        /// <param name="cidList"></param>
        /// <returns></returns>
        List<ContactInfoModel> GetContactByCid(List<int> cidList);
        /// <summary>
        /// 查询当前用户下的联系人信息
        /// </summary>
        /// <param name="cidList"></param>
        /// <param name="args">搜索条件</param>
        /// <returns></returns>
        List<ContactInfoModel> GetContactByCid(List<int> cidList, string args);
    }
}
