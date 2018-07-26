using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Tool;
using Mzl.IBLL.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Tool
{
    internal class GetB2TFlightNoServiceBll : IGetB2TFlightNoServiceBll
    {
        private EtermCommand.EtermOrderSoapClient _client = new EtermCommand.EtermOrderSoapClient();
        public List<string> GetB2TFlightNo(B2TFlightNoQueryModel query)
        {
            string key = string.Format("{0}{1}{2}", CacheKeyEnum.B2TFlightNo, query.Dport, query.Aport);
            string result=RedisManager.Get(key, Get, query, TimeSpan.FromDays(30));
            if (string.IsNullOrEmpty(result))
                return null;
            return result.Split('/').ToList();
        }

        private string Get(B2TFlightNoQueryModel query)
        {
            string command = string.Format("SK:{0}{1}/MU", query.Dport, query.Aport);
            string result = _client.RAWOrder(command, 1);
            if (string.IsNullOrEmpty(result))
                return null;

            List<string> lineList = result.Split('\n').ToList();
            List<string> flightNoList = new List<string>();
            foreach (var lines in lineList)
            {
                List<string> line = lines.Split(' ').ToList();
                foreach (var l in line)
                {
                    if (l.Length > 2 && l.Contains("MU") && !l.Contains("*"))
                    {
                        flightNoList.Add(l);
                    }
                }
            }
            if (flightNoList.Count == 0)
                return null;

            return string.Concat(flightNoList.Distinct().Select(n => "/" + n).ToList()).Substring(1);
        }
    }

   
}
