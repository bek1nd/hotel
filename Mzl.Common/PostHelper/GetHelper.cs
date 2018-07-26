using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.PostHelper
{
    public class GetHelper
    {
        public static string GetUrl(string urlReg, string encodingType = "utf-8")
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlReg);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                byte[] bytes = new byte[40960];
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding(encodingType));
                string requestReturn = sr.ReadToEnd();
                sr.Close();
                response.Close();
                return requestReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
