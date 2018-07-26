using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Token;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Token
{
    /// <summary>
    /// 获取Token的控制器
    /// </summary>
    public class TokenController : ApiController
    {
      
        /// <summary>
        /// 获取Token信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<string> GetToken()
        {
            string token = this.Request.Headers.GetValues("MojoryToken").First();
            ResponseBaseViewModel<string> responseView = new ResponseBaseViewModel<string>();
            responseView.Flag = new ResponseCodeViewModel()
            {
                Code = 0,
                Message = "",
                MojoryToken = token
            };
            return responseView;
        }


        

    }
}
