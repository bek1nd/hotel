using Mzl.Common.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Redis.CityCode
{
    public class CityCodeJson
    {
        private static readonly string RedisCityCode = "CTripCityCode";
        private static readonly RedisHelper<string> _helper = new RedisHelper<string>();
        public static string Get()
        {
            if (_helper.Get(RedisCityCode) == null)
            {

            }
            return _helper.Get(RedisCityCode);
        }

        public static void Set(string json, TimeSpan validFor)
        {
            _helper.Set(json, RedisCityCode, validFor);
        }

        //public static void Expire(string key, int hours)
        //{
        //    _helper.Expire(key, hours * 3600);
        //}
        //public static void Delete(string key)
        //{
        //    _helper.Delete(key);
        //}
    }
}
