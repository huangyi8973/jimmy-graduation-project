using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using Mis.Core.Model;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Mis.Core.Dal;
namespace Mis.Core
{
    public class MisSession
    {
        public void SaveSession(LoginModel loginModel,HttpSessionStateBase session)
        {
            //获取用户信息
            UserCacheModel userCacheModel=new UserCacheModel();
            userCacheModel.Id = loginModel.UserId.ToString();
            userCacheModel.UserName = loginModel.UserName;
            //获得当前的session id;
            userCacheModel.SessionId = session.SessionID;
            //获取角色信息
            RoleDao roleDao=new RoleDao();
            userCacheModel.Roles = roleDao.GetRolesByUserId(loginModel.UserId);
            //获取权限信息
            ResourceDao resourceDao=new ResourceDao();
            IDictionary<string,ResourceCacheModel> premissionDictionary=new Dictionary<string, ResourceCacheModel>();
            
            //遍历用户所拥有的角色
            foreach(var role in userCacheModel.Roles)
            {
                //获取该角色所拥有的权限
                List<ResourceCacheModel> list = resourceDao.GetResourceByRoleId(role.Id);
                Premission premission=new Premission();
                //遍历权限
                foreach(ResourceCacheModel resourceCache in list)
                {
                    //判断当前资源是否在权限列表中已经存在
                    if(premissionDictionary.ContainsKey(resourceCache.ResourceName))
                    {
                        ResourceCacheModel temp = premissionDictionary[resourceCache.ResourceName];
                        //执行权限值合并操作
                        premission.Merge(ref temp,resourceCache);
                        premissionDictionary[temp.ResourceName] = temp;
                    }
                    else
                    {
                        //把权限添加到权限列表里
                        premissionDictionary.Add(resourceCache.ResourceName,resourceCache);
                    }
                    
                }
            }
            userCacheModel.PremissionList = premissionDictionary.Values.ToList();
            //把信息保存到缓存里
            Cache cache = new Cache();
            cache.Add(loginModel.UserName,userCacheModel);
        }

        //登录状态
        public static int HAVE_LOGIN = 0; //已经登录
        public static int ANOTHER_USER_LOGIN = 1;
        public static int NO_LOGIN = 2;

        public int SessionStateCheck(HttpSessionStateBase session)
        {
            
            if (session["UserName"] != null)
            {
               Cache cache=new Cache();
               if (cache.GetUserCache(session["UserName"].ToString()).SessionId.Equals(session.SessionID))
               {
                   return HAVE_LOGIN;
               }
                return ANOTHER_USER_LOGIN;
            }
            return NO_LOGIN;
        }

        public int SessionStateCheck(HttpSessionStateBase session, String userName)
        {
            Cache cache=new Cache();
           if(cache.GetUserCache(userName)!=null)
           {
               return ANOTHER_USER_LOGIN;
           }
            return SessionStateCheck(session);
        }

        public void RemoveUser(HttpSessionState session)
        {
            Cache cache = new Cache();
            if (session["UserName"] != null)
            {
                cache.Remove(session["UserName"].ToString());
                session.Clear();
            }
        }
        public void RemoveUser(String userName)
        {
            Cache cache = new Cache();
            if(!string.IsNullOrEmpty(userName))
            {
                cache.Remove(userName);
            }
        }

    }
}
