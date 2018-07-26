using Mzl.Common.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Redis.Token
{
    public class TokenRedisFactory
    {
        private static readonly RedisHelper<string> _helper = new RedisHelper<string>();
        public static string Get(string token)
        {
            return _helper.Get(token);
        }

        public static void Set(string token,string value,TimeSpan validFor)
        {
            _helper.Set(value, token, validFor);
        }

        public static void Expire(string key,int hours)
        {
            _helper.Expire(key, hours * 3600);
        }
        public static void Delete(string key)
        {
            _helper.Delete(key);
        }

    }
}
