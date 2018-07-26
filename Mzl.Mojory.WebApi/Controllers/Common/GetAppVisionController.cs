using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.Vision;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 获取APP允许版本号
    /// </summary>
    [AllowAnonymous]
    public class GetAppVisionController : ApiController
    {
        /// <summary>
        /// 检查app允许版本号
        /// </summary>
        [HttpPost]
        public ResponseBaseViewModel<CheckAppVisionResponseViewModel> CheckAllAppVision([FromBody] CheckAppVisionRequestViewModel request)
        {
            string appVision = request.Vision.Split('.')[0];
            if(string.IsNullOrEmpty(appVision))
                throw new Exception("版本号格式不正确");

            int vision = Convert.ToInt32(AppSettingsHelper.GetAppSettings(AppSettingsEnum.AllowAppVision));

            ResponseBaseViewModel<CheckAppVisionResponseViewModel> v =
                new ResponseBaseViewModel<CheckAppVisionResponseViewModel>();
            if (vision > Convert.ToInt32(appVision))
            {
                v.Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()};
                v.Data = new CheckAppVisionResponseViewModel()
                {
                    Code = (int) MojoryApiResponseCode.NoAllowVision,
                    AndroidUrl = AppSettingsHelper.GetAppSettings(AppSettingsEnum.VisionAndroidUrl),
                    IosUrl = AppSettingsHelper.GetAppSettings(AppSettingsEnum.VisionIosUrl),
                    Message = AppSettingsHelper.GetAppSettings(AppSettingsEnum.VisionMessage)
                };
            }
            else
            {
                v.Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()};
                v.Data = new CheckAppVisionResponseViewModel() {Code = 0};
            }

            return v;
        }
    }
}
