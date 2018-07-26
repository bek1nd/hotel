using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
namespace Mzl.Common.PostHelper
{
    public class PostHelper
    {
        public static string ReceivePostInfo()
        {
            string postStr = string.Empty;
            Stream s = HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            postStr = Encoding.UTF8.GetString(b);//POST数据 
            return postStr;
        }
        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="posturl">url</param>
        /// <param name="postData">post数据</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string PostUrl(string posturl, string postData, Encoding encoding)
        {
            //Encoding encoding = Encoding.UTF8;
            var data = encoding.GetBytes(postData);
            
            // 设置参数  
            var request = WebRequest.Create(posturl) as HttpWebRequest;
            var cookieContainer = new CookieContainer();
            if (request == null)
                return string.Empty;
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            string message = "";
            for (int i = 0; i < 5; i++)
            {
                try
                { 
                    using (var outstream = request.GetRequestStream())
                    {
                        outstream.Write(data, 0, data.Length);
                        outstream.Close();
                    }
                    //发送请求并获取相应回应数据  
                    var response = request.GetResponse() as HttpWebResponse;
                    var instream = response?.GetResponseStream();
                    if (instream == null)
                        return string.Empty;
                    using (var sr = new StreamReader(instream, encoding))
                    {
                        var content = sr.ReadToEnd();
                        return content;
                    }

                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    Thread.Sleep(2000);
                }
                
            }

            throw new Exception("请重新尝试连接");

           
        }

    }
}
