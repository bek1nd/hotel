using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.UIModel.Common.SessionManage;
using Mzl.Common.CacheHelper;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// Session管理
    /// </summary>
    public class SessionManageController : ApiController
    {
        /// <summary>
        /// 设置Session值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<SetSessionResponseViewModel> SetSession([FromBody] SetSessionRequestViewModel request)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "");
            RedisManager.Set(request.SessionContent, key + "_" + this.GetToken(), TimeSpan.FromHours(12));

            ResponseBaseViewModel<SetSessionResponseViewModel> v = new ResponseBaseViewModel
                <SetSessionResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = new SetSessionResponseViewModel() {IsSuccessed = true, Key = key}
            };
            return v;

        }

        /// <summary>
        /// 获取Session值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<GetSessionResponseViewModel> GetSession([FromBody] GetSessionRequestViewModel request)
        {
            string value = RedisManager.GetData(request.Key + "_" + this.GetToken());

            ResponseBaseViewModel<GetSessionResponseViewModel> v = new ResponseBaseViewModel
                <GetSessionResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = new GetSessionResponseViewModel() {Key = request.Key, Value = value}
            };
            return v;

        }
    }
}
