using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.CacheHelper
{
    public class CacheManager
    {
        #region Identity
        private CacheManager()
        { }

        private static ICache _cache = null;

        static CacheManager()
        {
            //可以创建不同的cache对象
            //_cache = (ICache)Activator.CreateInstance(typeof(MemoryCacheCache));// 这里可以根据配置文件来选择
            _cache = (ICache)Activator.CreateInstance(typeof(MemoryCacheCache));
        }
        #endregion Identity

        #region ICache
        /// <summary>
        /// 当前缓存数据项的个数
        /// </summary>
        public static int Count
        {
            get { return _cache.Count; }
        }

        /// <summary>
        /// 如果缓存中已存在数据项键值，则返回true
        /// </summary>
        /// <param name="key">数据项键值</param>
        /// <returns>数据项是否存在</returns>
        public static bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetData<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存的项</param>
        /// <param name="acquire">没有缓存的时候获取数据的方式</param>
        /// <param name="cacheTime">单位分钟  默认30</param>
        /// <returns></returns>
        public static T Get<T>(string key, Func<T> acquire, int cacheTime = 30)
        {
            if (!_cache.Contains(key))
            {
                T result = acquire.Invoke();
                _cache.Add(key, result, cacheTime);
            }
            return GetData<T>(key);
        }

        public static T Get<S,T>(string key, Func<S,T> acquire,S s, int cacheTime = 30)
        {
            if (!_cache.Contains(key))
            {
                T result = acquire.Invoke(s);
                _cache.Add(key, result, cacheTime);
            }
            return GetData<T>(key);
        }

        /// <summary>
        /// 添加缓存数据。
        /// 如果另一个相同键值的数据已经存在，原数据项将被删除，新数据项被添加。
        /// </summary>
        /// <param name="key">缓存数据的键值</param>
        /// <param name="value">缓存的数据，可以为null值</param>
        /// <param name="expiratTime">缓存过期时间间隔(单位：分钟)</param>
        public static void Add(string key, object value, int expiratTime = 30)
        {
            if (Contains(key))
                _cache.Remove(key);
            _cache.Add(key, value, expiratTime);
        }

        /// <summary>
        /// 删除缓存数据项
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// 删除所有缓存数据项
        /// </summary>
        public static void RemoveAll()
        {
            _cache.RemoveAll();
        }
        #endregion

    }
}
