using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;

namespace Mzl.Common.DBHelper
{
    public class RedisHelper<T>
    {
        private static readonly int _port;
        private static readonly string _host;
        private static readonly string _password;

        static RedisHelper()
        {
            System.Collections.IDictionary config = (System.Collections.IDictionary)System.Configuration.ConfigurationManager.GetSection("redisConnection");
            _host = config["host"].ToString();
            _port = int.Parse(config["port"].ToString());
            var pwd = config["password"].ToString();
            if (string.IsNullOrWhiteSpace(pwd))
            {
                _password = null;
            }
        }

        public void Delete(string key)
        {
            try
            {
                using (RedisClient client = new RedisClient(_host, _port, _password))
                {
                    client.Remove(key);
                }
            }
            catch
            { }
        }

        public void Set(T obj, string key, TimeSpan validFor)
        {
            try
            {
                using (RedisClient client = new RedisClient(_host, _port, _password))
                {
                    client.Set<T>(key, obj, validFor);
                }
            }
            catch
            { }
        }

        public void Set(T obj, string key)
        {
            Set(obj, key, TimeSpan.FromHours(1));
        }

        public T Get(string key)
        {
            try
            {
                using (RedisClient client = new RedisClient(_host, _port, _password))
                {
                    return client.Get<T>(key);
                }
            }
            catch
            {
                return default(T);
            }
        }

        public void Expire(string key, int seconds)
        {
            try
            {
                using (RedisClient client = new RedisClient(_host, _port, _password))
                {
                    client.Expire(key, seconds);
                }
            }
            catch
            { }
        }
    }
}
