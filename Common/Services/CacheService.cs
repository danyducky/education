using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Common.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache cache;

        public CacheService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public T Get<T>(string key)
        {
            var value = cache.GetString(key);

            if (value == null)
                return default(T);

            return JsonConvert.DeserializeObject<T>(value);
        }

        public T Set<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            cache.SetString(key, JsonConvert.SerializeObject(value), options);

            return value;
        }
    }
}
