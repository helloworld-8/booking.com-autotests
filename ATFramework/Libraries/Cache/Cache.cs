using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ATFramework.Libraries.Cache
{
    public static class Cache
    {
        public static void SaveToCache(string cacheKey, object savedItem, DateTime absoluteExpiration)
        {
            MemoryCache.Default.Add(cacheKey, savedItem, absoluteExpiration);
        }

        public static T GetFromCache<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default[cacheKey] as T;
        }

        public static void RemoveFromCache(string cacheKey)
        {
            MemoryCache.Default.Remove(cacheKey);
        }

        public static bool IsInCache(string cacheKey)
        {
            return MemoryCache.Default[cacheKey] != null;
        }
    }
}
