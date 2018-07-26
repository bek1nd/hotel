using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.CacheHelper
{
    public interface ICache
    {
        T Get<T>(string key);

        void Add(string key, object data, int cacheTime = 30);

        bool Contains(string key);

        void Remove(string key);

        void RemoveAll();

        object this[string key] { get; set; }

        int Count { get; }
    }
}
