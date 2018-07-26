using Mzl.DomainModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Login;
using Mzl.DomainModel.Events;
using Mzl.DomainModel.Customer.Passenger;

namespace Mzl.IApplication.Customer.Domain
{
    public interface ICustomerDomain
    {
        event EventHandler<TokenEventArgs> TokenEvent;
        /// <summary>
        /// 进行登录,跟据登录信息，验证登录是否合法
        /// </summary>
        CustomerInfoModel DoLogin(CustomerLoginModel loginModel);



        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="cid">用户Cid</param>
        /// <param name="clientId">用户客户</param>
        /// <returns></returns>
        bool AutoLogin(int cid, string clientId);

        /// <summary>
        /// 登出
        /// </summary>
        void DoLoginOut(string token);

        /// <summary>
        /// 根据公司代码和公司对应的部门Id，获取乘机/乘车人信息
        /// </summary>
        /// <param name="cid">客户Id</param>
        /// <param name="departId">部门Id</param>
        /// <param name="searchArgs">查询参数</param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassengerInfoList(int cid, int? departId, string searchArgs = "");
        /// <summary>
        /// 根据Cid获取客户信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        CustomerInfoModel GetCustomerInfo(int cid);
        /// <summary>
        /// 根据cid，获取查询行程视图
        /// </summary>
        /// <param name="cid"></param>
        BaseQueryTravelModel GetQueryTravelView(int cid);
        /// <summary>
        /// 如果联系人id为0，新增联系人信息；如果不为0，则更新
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        int AddContact(ContactInfoModel contactInfo);
        /// <summary>
        /// 添加联系人事件监听
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void AddContactEventListener(object o, CommonEventArgs<List<ContactInfoModel>> e);
    }
}
