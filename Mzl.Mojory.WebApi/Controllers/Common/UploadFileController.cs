using Mzl.IApplication.Flight;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using Mzl.Common.ConfigHelper;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 附件上传
    /// </summary>
    [AllowAnonymous]
    public class UploadFileController : ApiController
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new Exception("上传格式不是multipart/form-data");
                }

                string url = AppSettingsHelper.GetAppSettings(AppSettingsEnum.UploadFile);
                string root = HttpContext.Current.Server.MapPath(url);

                var provider = new MultipartFormDataStreamProvider(root);

                await Request.Content.ReadAsMultipartAsync(provider);

                int maxSize = Convert.ToInt32(AppSettingsHelper.GetAppSettings(AppSettingsEnum.MaxFileSize));


                string filePaths = string.Empty;
                foreach (var file in provider.FileData)
                {
                    string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    if (fileinfo.Length <= 0)
                    {
                        throw new Exception("请选择上传文件");
                    }

                    if (fileinfo.Length > (maxSize * 1024 * 1024))
                    {
                        throw new Exception("上传文件大小超过限制");
                    }

                    string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));
                    fileinfo.CopyTo(Path.Combine(root, fileinfo.Name + fileExt), true);
                    //filePaths.Add("~//UploadFile//" + fileinfo.Name + fileExt);
                    filePaths += fileinfo.Name + fileExt + "|";
                    fileinfo.Delete(); //删除原文件
                }
                if (string.IsNullOrEmpty(filePaths))
                    return Request.CreateResponse(HttpStatusCode.BadGateway, "");

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(filePaths, Encoding.UTF8);

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, "");
            }


        }
    }
}
