using System.Collections.Concurrent;

namespace Ahorcado.Mvc
{
    public class MemoryStorageHelper
    {
        private static ConcurrentDictionary<string, object> _cache;

        public static void AddOrReplace(string key, object item)
        {
            EnsureIsInitialized();
            if (_cache.ContainsKey(key))
            {
                _cache[key] = item;
            }
            else
            {
                _cache.TryAdd(key, item);
            }
        }

        public static T GetAs<T>(string key)
        {
            EnsureIsInitialized();
            _cache.TryGetValue(key, out var item);
            return (T)item;
        }

        private static void EnsureIsInitialized()
        {
            if(_cache is null)
            {
                _cache = new ConcurrentDictionary<string, object>();
            }
        }
    }
}
