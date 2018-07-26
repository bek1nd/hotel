using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.IApplication.Customer;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    public class MobileBindController : ApiController
    {
        public readonly IMobileBindApplication _mobileBindApplication;

        public MobileBindController(IMobileBindApplication mobileBindApplication) {
            _mobileBindApplication = mobileBindApplication;
        }

        public async Task<ResponseBaseViewModel> SendVerifyMessage() 
{
            try
            {
                
                _mobileBindApplication.SendVerifyMessage(this.GetCid());
            }
            catch (MojoryException ex) {
                return new ResponseBaseViewModel()
                {
                    Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)ex.Code,
                        Message = ex.Code.ToDescription()
                    }
                };
            }
            return new ResponseBaseViewModel()
            {
                Flag = new ResponseCodeViewModel()
                {
                    Code = (int)MojoryApiResponseCode.Success
                }
            };
        }

        public async Task<ResponseBaseViewModel> MobileBind(MobileBindRequestViewModel request) {
            try
            {
                _mobileBindApplication.MobileBind(request.VerifyCode, request.NewMobile, this.GetCid());
                return new ResponseBaseViewModel()
                {
                    Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)MojoryApiResponseCode.Success
                    }
                };
            }
            catch (MojoryException ex) {
                return new ResponseBaseViewModel()
                {
                    Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)ex.Code,
                        Message = ex.Code.ToDescription()
                    }
                };
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
        }

        public async Task<ResponseBaseViewModel> MobileBindClientID(MobileBindClientIDRequestViewModel request) {
            try { 
                _mobileBindApplication.MobileBindClientID(request.VerifyCode, request.ClientID, this.GetCid(), this.GetOrderSource());
                return new ResponseBaseViewModel()
                {
                    Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)MojoryApiResponseCode.Success
                    }
                };
            }
            catch (MojoryException ex)
            {
                return new ResponseBaseViewModel()
                {
                    Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)ex.Code,
                        Message = ex.Code.ToDescription()
                    }
                };
            }
        }

    }
}