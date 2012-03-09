using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Mis.Core.Model;
namespace Mis.Core
{
    public class Cache
    {
        public UserCacheModel GetUserCache(string userName)
        {
            UserCacheModel userCacheModel = (UserCacheModel)HttpRuntime.Cache[userName];
            return userCacheModel;
        }

        public void SetUserCache(string userName,UserCacheModel userCacheModel)
        {
            HttpRuntime.Cache[userName] = userCacheModel;
        }

        public void Add(string key,object value)
        {
            HttpRuntime.Cache[key] = value;
        }

        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}
