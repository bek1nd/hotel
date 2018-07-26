using Mzl.Common;
using Mzl.Common.CacheHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.Common.RegexHelper;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Customer
{
    public class MobileBindServiceBll : BaseServiceBll, IMobileBindServiceBll
    {
        private readonly ICustomerDal _customerDal;
        public MobileBindServiceBll(ICustomerDal customerDal) {
            this._customerDal = customerDal;
        }

        public bool MobileBind(string verifyCode, string newMobile, int cid)
        {
            var customerInfo = _customerDal.Find<CustomerInfoEntity>(cid);
            var originalMobile = customerInfo.Mobile;

            #region 检测验证码是否正确
            var r = RedisManager.GetData(CacheKeyEnum.CustomerMobileVerifyCode + originalMobile);
            if (r != null && r.Length > 0 && verifyCode == r) { }
            else
            {
                throw new MojoryException(MojoryApiResponseCode.VerifyCodeError);
            }
            #endregion

            #region 验证新手机号码
            if (!RegexHelper.IsMobile(newMobile)) {
                throw new MojoryException(MojoryApiResponseCode.MobileError);
            }
            #endregion

            #region 检测是否有重复的手机
            var c = _customerDal.Query<CustomerInfoEntity>(a => a.Mobile == newMobile && a.IsDel != "T").Count();
            if (c > 0)
            {
                throw new MojoryException(MojoryApiResponseCode.MobileExist);
            }
            #endregion

            #region 更新手机
            customerInfo.Mobile = newMobile;
            _customerDal.Update<CustomerInfoEntity>(customerInfo);
            return true;
            #endregion
        }

        public bool MobileBindClientID(string verifyCode, string clientID, int cid, string clientType)
        {
            var customerInfo = _customerDal.Find<CustomerInfoEntity>(cid);
            var mobile = customerInfo.Mobile;

            #region 检测验证码是否正确
            var r = RedisManager.GetData(CacheKeyEnum.CustomerMobileVerifyCode + mobile);
            if (r != null && r.Length > 0 && verifyCode == r) { }
            else
            {
                throw new MojoryException(MojoryApiResponseCode.VerifyCodeError);
            }
            #endregion

            var clientIdInfo = _customerDal.Query<CustomerAppClientIdEntity>(a => a.Cid == cid);
            if (clientIdInfo.Any())
            {
                var item = clientIdInfo.First();
                item.ClientId = clientID;
                item.ClientType = clientType;

                #region 更新设备信息
                _customerDal.Update<CustomerAppClientIdEntity>(item);
                return true;
                #endregion
            }
            else {
                var item = new CustomerAppClientIdEntity();
                item.Cid = cid;
                item.ClientId = clientID;
                item.ClientType = clientType;
                item.CreateTime = DateTime.Now;
                #region 更新设备信息
                _customerDal.Insert<CustomerAppClientIdEntity>(item);
                return true;
                #endregion
            }
        }

        public void SendVerifyMessage(int cid)
        {
            var customerInfo = _customerDal.Find<CustomerInfoEntity>(cid);
            var mobile = customerInfo.Mobile;

            Random rd = new Random();
            var r = rd.Next(1000, 9999).ToString();
            string msg = "验证码:" + r + " 有效期10分钟，请输入验证码完成重新绑定手机。";
            string sendType = "手工";//"手机验证码发送";
            RedisManager.Set(r.ToString(), CacheKeyEnum.CustomerMobileVerifyCode + mobile, new TimeSpan(0, 15, 0));
            SMSHelper.SMSSendMessage(mobile, msg , sendType);
        }
    }
}
