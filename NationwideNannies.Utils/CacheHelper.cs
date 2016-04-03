using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NationwideNannies.Utils
{
    public static class CacheHelper
    {
        public static void ClearCache()
        {
            List<string> keys = new List<string>();
            var enumerator = HttpContext.Current.Cache.GetEnumerator();

            // copy all keys that currently exist in Cache
            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            // delete every key from cache
            for (int i = 0; i < keys.Count; i++)
            {
                HttpContext.Current.Cache.Remove(keys[i]);
            }

            HttpContext.Current.Application["MyGuid"] = Guid.NewGuid();
        }
      

        public static bool AddToCache<T>(T itemtToCache, string key)
        {

            if (itemtToCache == null)
            {
                return false;
            }
      
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            double cacheDuration = 60;
            string str = ConfigurationManager.AppSettings["CacheDuration"];
            if (!double.TryParse(str, out cacheDuration))
            {
                return false;
            }
            if (cacheDuration == 0)
            {
                return false;
            }

            HttpContext.Current.Cache.Add(key, itemtToCache, null, DateTime.Now.AddMinutes(cacheDuration), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

            return true;
        }

        public static T GetFromCache<T>(string key)
        {
            T returnVal;

            if (string.IsNullOrEmpty(key))
            {
                returnVal = default(T);
            }
            else
            {
                try
                {
                    returnVal = (T)HttpContext.Current.Cache[key];
                }
                catch (Exception ex)
                {
                    returnVal = default(T);
                }
            }

            return returnVal;
        }      
    }
}
