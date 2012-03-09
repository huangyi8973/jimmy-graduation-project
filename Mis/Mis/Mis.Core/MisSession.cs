using System;
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
        public void SaveSession(LoginModel loginModel)
        {
            UserCacheModel userCacheModel=new UserCacheModel();
            userCacheModel.Id = loginModel.UserId.ToString();
            userCacheModel.UserName = loginModel.UserName;

            RoleDao roleDao=new RoleDao();
            userCacheModel.Role = roleDao.GetRoleByUserId(loginModel.UserId);

            ResourceDao resourceDao=new ResourceDao();
            userCacheModel.PremissionList = resourceDao.GetResourceByRoleId(userCacheModel.Role.Id);

            Cache cache=new Cache();
            cache.Add(loginModel.UserName,userCacheModel);
        }


        public bool SessionStateCheck(HttpSessionStateBase session)
        {
            if (session["UserName"] != null)
                return true;
            return false;
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

    }
}
