using Mzl.Common.ConfigHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Config
{
    /// <summary>
    /// ApiController扩展方法
    /// </summary>
    public static class ApiControllerExtensions
    {
        /// <summary>
        /// 获取请求头中的MojoryToken信息
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        /// 
        #region ×××××注释1
        public static string GetToken(this ApiController api)
        {
            return api.Request.Headers.GetValues("MojoryToken").First();
        }

        #endregion
        /// <summary>
        /// 获取请求头中的Cid信息
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static int GetCid(this ApiController api)
        {
            IEnumerable<string> valuesList;
            string cid = "0";
            if (api.Request.Headers.TryGetValues("Cid", out valuesList))
            {
                cid = valuesList.FirstOrDefault();
                if (string.IsNullOrEmpty(cid))
                    cid = "0";
            }
            return Convert.ToInt32(cid);
        }
        /// <summary>
        /// 获取请求头中的Oid信息
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static string GetOid(this ApiController api)
        {
            IEnumerable<string> valuesList;
            string oid = "sys";
            if (api.Request.Headers.TryGetValues("Oid", out valuesList))
            {
                oid = valuesList.FirstOrDefault();
            }
            return oid;
        }
        /// <summary>
        /// 判断请求是否来自线上
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static bool CheckIsFromOnline(this ApiController api)
        {
            bool isFromOnline = false;
            string token = api.Request.Headers.GetValues("MojoryToken").First();
            if (token != AppSettingsHelper.GetAppSettings(AppSettingsEnum.OAToken))
            {
                isFromOnline = true;
            }
            return isFromOnline;
        }
        /// <summary>
        /// 获取订单来源
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static string GetOrderSource(this ApiController api)
        {
            IEnumerable<string> valuesList;
            string orderSource = "O";
            if (api.Request.Headers.TryGetValues("OrderSource", out valuesList))
            {
                orderSource = valuesList.FirstOrDefault();
            }
            return orderSource;
        }
    }
}