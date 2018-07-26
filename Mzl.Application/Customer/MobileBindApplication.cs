using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Customer
{
    public class MobileBindApplication : BaseApplicationService, IMobileBindApplication
    {
        private readonly IMobileBindServiceBll _mobileBindServiceBll;

        public MobileBindApplication(IMobileBindServiceBll mobileBindServiceBll) {
            this._mobileBindServiceBll = mobileBindServiceBll;
        }

        public bool MobileBind(string verifyCode, string newMobile, int cid)
        {
            using (var transport = this.Context.Database.BeginTransaction())
            {
                var result = _mobileBindServiceBll.MobileBind(verifyCode, newMobile, cid);
                transport.Commit();
                return result;
            }
        }

        public bool MobileBindClientID(string verifyCode, string clientID, int cid, string clientType)
        {
            using (var transport = this.Context.Database.BeginTransaction())
            {
                var result = _mobileBindServiceBll.MobileBindClientID(verifyCode, clientID, cid, clientType);
                transport.Commit();
                return result;
            }
        }

        public void SendVerifyMessage(int cid)
        {
            _mobileBindServiceBll.SendVerifyMessage(cid);
        }
    }
}
