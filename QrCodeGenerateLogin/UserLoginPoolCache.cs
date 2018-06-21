using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrCodeGenerateLogin
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginPoolCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="sptime"></param>
        public static void SetCache(string key, object value, TimeSpan sptime)
        {
            SetCache(key, value, System.Web.Caching.Cache.NoAbsoluteExpiration, sptime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dt"></param>
        public static void SetCache(string key, object value, DateTime dt)
        {
            SetCache(key, value, dt, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dt"></param>
        /// <param name="sptime"></param>
        public static void SetCache(string key, object value, DateTime dt, TimeSpan sptime)
        {
            HttpRuntime.Cache.Insert(key, value, null, dt, sptime);
        }


        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string cacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(cacheKey);
        }


        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}