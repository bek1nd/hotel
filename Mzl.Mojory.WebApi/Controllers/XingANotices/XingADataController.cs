using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;
using Mzl.Common.XingAHelper;
using Mzl.DomainModel.XingA;
using Mzl.IApplication.XingA;
using Mzl.UIModel.Base;
using Mzl.Mojory.WebApi.Config;
using System.Web.Script.Serialization;
using System.Web;
using Mzl.Common.LogHelper;

namespace Mzl.Mojory.WebApi.Controllers.XingANotices
{
    /// <summary>
    /// 行啊
    /// </summary>
    [AllowAnonymous]
    public class XingADataController : ApiController
    {
        public IXingAGetDataApplication _XingAApp;
        public XingADataController(IXingAGetDataApplication XingAApp)
        {
            _XingAApp = XingAApp;
        }
        public string guid = System.Guid.NewGuid().ToString().Trim().Replace("-", "");

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <returns>加密结果</returns>
        [HttpPost]
        public IHttpActionResult InsertData([FromBody] BCTktRefundSynVO request)
        {
            try
            {
                string requestIP = "IP为" + System.Web.HttpContext.Current.Request.UserHostAddress+ "端口号为" + System.Web.HttpContext.Current.Request.Url.Port;               
                string str1 = new JavaScriptSerializer().Serialize(request).Trim();
                string str1log = System.DateTime.Now + " " + requestIP + " " + "请求加密数据:" + str1;
                LogHelper.WriteLog(str1log, "XinAGetData");
                string str2 = EnCryptAndDecipher.Encrypt(str1, "miaozhilv@mojory.com", guid);
                string str2log = System.DateTime.Now + " " + "加密完成数据:" + str2;
                LogHelper.WriteLog(str2log, "XinAGetData");
                if (!string.IsNullOrEmpty(str2))
                {
                    return Json(new { SuccessFlag = true, Status = 200, Message = "加密成功!", EncryptGetData = guid + str2 });
                }
                else
                {
                    return Json(new { SuccessFlag = false, Status = 500, Message = "加密失败!" });
                }
            }
            catch (Exception ex)
            {
                string requestIP = "IP为" + System.Web.HttpContext.Current.Request.UserHostAddress + "端口号为" + System.Web.HttpContext.Current.Request.Url.Port;
                string message = System.DateTime.Now + " " + requestIP + "加密异常信息:" + ex.StackTrace + " " + ex.Message;
                throw ex;
            }
        }
        
        /// <summary>
        /// 解密数据并存储数据
        /// </summary>
        /// <param name="data">密文</param>
        /// <returns>解密结果</returns>
        [HttpPost]
        public IHttpActionResult DecryptData([FromBody] BCTktRefundSynVO request)
        {
            try
            {
                //把加密结果解密出来验证解密是否正确
                //string str = HttpUtility.UrlDecode(request.RequestStr.ToString(),System.Text.Encoding.UTF8);
                string requestIP = "IP为" + System.Web.HttpContext.Current.Request.UserHostAddress + "端口号为" + System.Web.HttpContext.Current.Request.Url.Port;
                string data = request.RequestStr;
                string datalog = System.DateTime.Now + " " + requestIP + " " + "请求解密数据:" + data;
                LogHelper.WriteLog(datalog, "XinAGetData");
                string str2 = new JavaScriptSerializer().Serialize(data).Substring(0, 33).Replace("\"","").ToString();
                string str2log = System.DateTime.Now + " " + "请求解密数据公钥:" + str2;
                LogHelper.WriteLog(str2log, "XinAGetData");
                if (!string.IsNullOrEmpty(str2) && str2.Length==32)
                {
                    string str3 = new JavaScriptSerializer().Serialize(data).Remove(0, 33).Replace("\"", "").ToString();
                    string str3log = System.DateTime.Now + " " + "请求解密数据密文:" + str3;
                    LogHelper.WriteLog(str3log, "XinAGetData");
                    if (!string.IsNullOrEmpty(str3))
                    {
                        string str1 = EnCryptAndDecipher.Decrypt(str3, "miaozhilv@mojory.com", str2);
                        string str1log = System.DateTime.Now + " " + "解密成功数据:" + str1;
                        LogHelper.WriteLog(str1log, "XinAGetData");
                        XingAModel model = new XingAModel();
                        model.CreateTime = System.DateTime.Now;
                        model.msgCode = "1";
                        model.errMsg = "测试数据";
                        model.EncryptGetData = data.ToString();
                        model.DecryptGetData = str1;
                        model.IsUseCreateOrder = 0;
                        int result = _XingAApp.AddData(model);
                        if (result > 0)
                        {
                            return Json(new { SuccessFlag = true, Status = 200, Message = "解密成功!" });
                        }
                        else
                        {
                            return Json(new { SuccessFlag = false, Status = 500, Message = "解密失败,请检查解密数据!" });
                        }
                    }
                    else
                    {
                        return Json(new { SuccessFlag = false, Status = 500, Message = "密文异常,请检查密文!" });
                    }
                }
                else
                {
                    return Json(new { SuccessFlag = false, Status = 500, Message = "公钥异常,请检查公钥!" });
                }
            }
            catch (Exception ex)
            {
                string requestIP = "IP为" + System.Web.HttpContext.Current.Request.UserHostAddress + "端口号为" + System.Web.HttpContext.Current.Request.Url.Port;
                string message = System.DateTime.Now + " " + requestIP + "解密异常信息:" + ex.StackTrace + ex.Message;
                LogHelper.WriteLog(message, "XinAGetData");
                throw ex;
            }
        }
    }
}
