using Mzl.IApplication.Common;
using Mzl.UIModel.Common.AuditOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Test
{
    public class DoTestController : ApiController
    {
        private readonly IDoTestApplication<AuditOrderResponseViewModel> _application;

        public DoTestController(IDoTestApplication<AuditOrderResponseViewModel> application)
        {
            _application = application;
        }

        [HttpGet]
        public string Hello()
        {
            var model = _application.Get();
            return "1111";
        }
    }
}
