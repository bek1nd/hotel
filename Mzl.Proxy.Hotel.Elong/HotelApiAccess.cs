 using Mzl.Common.JsonHelper;
using Mzl.Common.PostHelper;
using Mzl.EntityModel.Hotel.Elong;
using Mzl.Common.EnumHelper.ElongEnum;
using Mzl.Proxy.Hotel.Elong.Configuraton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Mzl.Common.LogHelper;

namespace Mzl.Proxy.Hotel.Elong
{
    public static class HotelApiAccess
    {
        public static T GetStatic<T>(string url) {
            var res = GetHelper.GetUrl(url, "utf-8");

            res = res.Replace("\n", "");
            res = res.Replace("\r", "");
            //res = res.Replace("?><Result>", "?><ApiResult>");
            //res = res.Substring(0, res.Length - "/Result>".Length) + "/ApiResult>";
            res = Regex.Replace(res, "<\\w+/>", "");
            res = Regex.Replace(res, "<([^>]+)></\\1>", "");

            return XmlDeserialize<T>(res);
        }

        
        private static T XmlDeserialize<T>(string xml)
        {
            T t = default(T);
            XmlSerializer xs = new XmlSerializer(typeof(T));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var rd = new XmlNodeReader(doc.DocumentElement);
            t = (T)xs.Deserialize(rd);

            return t;
        }

        /// <summary>
        /// 请求艺龙接口
        /// </summary>
        /// <typeparam name="TResquest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static BaseResponseEntity<TResponse> Query<TResquest, TResponse>(TResquest request, string method)
        {
            string res = RequestInterface<TResquest>(request, method);
            if (string.IsNullOrEmpty(res)) 
            {
                return new BaseResponseEntity<TResponse>();  
            }
            else
            {
                return JsonHelper.DeserializeJsonToObject<BaseResponseEntity<TResponse>>(res);
            }
        }
        /// <summary>
        /// 请求艺龙接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string Query<T>(T request, string method)
        {
            return RequestInterface<T>(request, method);
        }



        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        private static string DesEncrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            des.Mode = CipherMode.CBC;

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:x2}", b);
            }
            return ret.ToString();
        }

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        private static string DesDecrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }


        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>double</returns>
        private static long ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return (long)intResult;
        }

        /// <summary>
        /// 返回小写的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string MD5(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            string encoded = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
            return encoded.ToLower();
        }

        /// <summary>
        /// 请求艺龙接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private static string RequestInterface<T>(T request,string method)
        {
            var requestContent = new BaseRequestEntity<T>() { Local = EnumLocal.zh_CN, Version = 1.22, Request = request };

            var str = JsonHelper.SerializeObject(requestContent);
            LogHelper.WriteLog("请求信息1：" + str, "ElongHotelInterface");
            DateTime now = DateTime.Now;
            long timestamp = ConvertDateTimeInt(now);
            string sig = MD5(timestamp + MD5(str + ApiGatewayConfig.APPKEY) + ApiGatewayConfig.SECRETKEY);

            StringBuilder sb = new StringBuilder();
            sb.Append("format=").Append("json").Append("&");
            sb.Append("method=").Append(method).Append("&");
            sb.Append("signature=").Append(sig).Append("&");
            sb.Append("user=").Append(ApiGatewayConfig.APIUSER).Append("&");
            sb.Append("timestamp=").Append(timestamp).Append("&");

            str = Uri.EscapeDataString(str);
            sb.Append("data=").Append(str);
            string url = string.Format(ApiGatewayConfig.URL_HTTPS, sb.ToString());
            LogHelper.WriteLog("请求信息2：" + url, "ElongHotelInterface");
            string res = GetHelper.GetUrl(url);
            LogHelper.WriteLog("响应信息：" + res, "ElongHotelInterface");
            return res;
        }
    }
}
