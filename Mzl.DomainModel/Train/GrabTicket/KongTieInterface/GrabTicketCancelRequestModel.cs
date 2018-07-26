using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.MD5Helper;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 抢票取消请求
    /// </summary>
    public class GrabTicketCancelRequestModel
    {
        public string qorderid { get; set; }
        public string partnerid => AppSettingsHelper.GetConfig("KongTieAccountConfig.xml", "GrabTicket", "UserName");

        private string _reqtime= DateTime.Now.ToString("yyyyMMddHHmmss");
        public string reqtime
        {
            get { return _reqtime; }
        }

        public string sign
        {
            get
            {
                string key = AppSettingsHelper.GetConfig("KongTieAccountConfig.xml", "GrabTicket", "Key");
                key = MD5Helper.MD5Encrypt(key);
                return MD5Helper.MD5Encrypt(string.Format("{0}{1}{2}", partnerid, _reqtime, key));
            }
        }

       
    }
}
