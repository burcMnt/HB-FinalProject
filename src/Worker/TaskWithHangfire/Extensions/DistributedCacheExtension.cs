using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskWithHangfire.Extensions
{
    public static class DistrubutedCacheExtensions
    {
        public static void AddWebApiServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.BuildServiceProvider();
        }
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,                             //unique ıdentifier for this  cached item
            T data,                                     //whatever gonna store in cache
            TimeSpan? absoluteExpireTime = null,       // allows u specify what those values will be
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromHours(1);
            options.SlidingExpiration = unusedExpireTime;
            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData is null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
