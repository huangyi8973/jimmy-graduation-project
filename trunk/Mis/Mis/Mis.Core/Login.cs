using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Mis.Core.Model;
using System.Data;
using Mis.Core.Dal;
using Mis.Core.Utilty;

namespace Mis.Core
{
    public class Login
    {
        public bool Check(LoginModel loginModel,HttpSessionStateBase session)
        {
            bool isPass = false;
            UserDao userDao=new UserDao();
            LoginModel lm = userDao.GetLoginData(loginModel);
            if(null!=lm)
            {
                if (lm.Password.Equals(MD5Tool.Parse(loginModel.Password)))
                {
                    isPass = true;
                    MisSession misSession = new MisSession();
                    int loginState = misSession.SessionStateCheck(session,lm.UserName);
                    if (loginState== MisSession.NO_LOGIN)
                    {
                        misSession.SaveSession(lm, session);
                    }
                    else
                    {
                        //防止用户重复登录，同一账户后登录的用户可以把先登录的用户踢出系统
                        misSession.RemoveUser(lm.UserName);
                        misSession.SaveSession(lm,session);
                    }
                }
            }
            return isPass;
        }
    }
}
