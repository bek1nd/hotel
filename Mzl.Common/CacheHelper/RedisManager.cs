using Mzl.Common.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mzl.Common.CacheHelper
{
    public class RedisManager
    {
        private static readonly RedisHelper<string> _helper = null;

        static RedisManager()
        {
            _helper = new RedisHelper<string>();
        }

        public static string GetData(string key)
        {
            return _helper.Get(key);
        }

        public static string Get<T>(string key, Func<T, string> acquire, T t, TimeSpan validFor)
        {
            string result = GetData(key);
            if (!string.IsNullOrEmpty(result))
                return result;
            result = acquire.Invoke(t);
            _helper.Set(result, key, validFor);
            return result;
        }

        public static T Get<T>(string key, Func<T> acquire,TimeSpan validFor)
        {
            string result = GetData(key);//从redis获取数据
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            //如果redis没数据,则干活去，将干活的结果存入缓存
            T t = acquire.Invoke();

            result = JsonConvert.SerializeObject(t);

            _helper.Set(result, key, validFor);

            return t;
        }

        public static void Set(string obj, string key, TimeSpan validFor)
        {
            _helper.Set(obj, key, validFor);
        }
    }
}
