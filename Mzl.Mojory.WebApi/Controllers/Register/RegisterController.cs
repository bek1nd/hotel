using Mzl.Application.Register;
using Mzl.IApplication.Register;
using Mzl.UIModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Register
{
    [AllowAnonymous]
    public class RegisterController : ApiController
    {
        private readonly IRegisterCustomerApplication _registerCustomerApplication;

        //public RegisterController(IRegisterCustomerApplication registerCustomerApplication)
        //{
        //    this._registerCustomerApplication = registerCustomerApplication;
        //}

        public RegisterController()
        {
            this._registerCustomerApplication = new RegisterCustomerApplication();
        }

        /// <summary>
        /// 用户登记
        /// </summary>
        /// <returns></returns>
        // GET: Register

        public Object RegisterCustomer([FromBody]RegisterViewModel request)
        {
            return new { Success = _registerCustomerApplication.RegisterCustomer(request) };
        }
    }
}