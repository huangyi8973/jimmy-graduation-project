using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Mis.Core.Model;
using System.Data;
using Mis.Core.Dal;

namespace Mis.Core
{
    public class Login
    {
        public bool Check(LoginModel loginModel)
        {
            bool isPass = false;
            UserDao userDao=new UserDao();
            LoginModel lm = userDao.GetLoginData(loginModel);
            if(null!=lm)
            {
                if (lm.Password.Equals(loginModel.Password))
                {
                    isPass = true;
                    MisSession session = new MisSession();
                    session.SaveSession(lm);
                }
            }
            return isPass;
        }
    }
}
