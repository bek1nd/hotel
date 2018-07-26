using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IMobileBindServiceBll
    {
        /// <summary>
        /// 发送手机验证短信
        /// </summary>
        /// <param name="cid">客户编号</param>
        void SendVerifyMessage(int cid);

        /// <summary>
        /// 绑定手机号码
        /// </summary>
        /// <param name="verifyCode">验证码</param>
        /// <param name="newMobile">新手机号码</param>
        /// <param name="cid">客户id</param>
        /// <returns></returns>
        bool MobileBind(string verifyCode,  string newMobile, int cid);

        /// <summary>
        /// 绑定客户设备ID
        /// </summary>
        /// <param name="verifyCode">验证码</param>
        /// <param name="clientID">设备ID</param>
        /// <param name="cid">客户id</param>
        /// <param name="clientType">客户端设备类型</param>
        bool MobileBindClientID(string verifyCode, string clientID, int cid, string clientType);
    }
}
