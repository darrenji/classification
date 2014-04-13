using System;
using System.Runtime.Caching;

namespace Car.Test.Cache
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return Cache[key] != null;
        }

        public void InValidate(string key)
        {
            Cache.Remove(key);
        }
    }
}