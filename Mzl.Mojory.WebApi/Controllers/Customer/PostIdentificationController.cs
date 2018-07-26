using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Identification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    public class PostIdentificationController : ApiController
    {
        public readonly IPostIdentificationApplication _postIdentificationApplication;

        public PostIdentificationController(IPostIdentificationApplication postIdentificationApplication)
        {
            this._postIdentificationApplication = postIdentificationApplication;
        }

        [HttpPost]
        public ResponseBaseViewModel PostIdentification([FromBody] IdentificationViewModel model)
        {

            var result = new ResponseBaseViewModel();
            bool flag  = _postIdentificationApplication.PostIdentification(model, this.GetCid());
            if (flag)
            {
                result.Flag = new ResponseCodeViewModel();
                result.Flag.Code = 0;
            }
            else
            {
                result.Flag.Code = 1;
            }
            return result;
        }
    }
}
