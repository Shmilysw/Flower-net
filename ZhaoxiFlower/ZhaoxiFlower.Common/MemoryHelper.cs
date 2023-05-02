using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Common
{
    // 引入缓存的概念，我的验证码生成后存在页面里面
    public class MemoryHelper
    {
        private static IMemoryCache _memoryCache = null;
        static MemoryHelper()
        {
            if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            }
        }
        public static void SetMemory(string key, object value, int expireMins) // 验证码的三个参数，key，value，有效期
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(expireMins));
        }
        public static object GetMemory(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}
