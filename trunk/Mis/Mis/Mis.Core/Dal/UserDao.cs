using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.DBUtilty;
using Mis.Core.Model;
using System.Data;
using System.Data.SqlClient;
using Mis.Core.Entity;

namespace Mis.Core.Dal
{
    public class UserDao:BaseDao<UserEntity>
    {
        public LoginModel GetLoginData(LoginModel loginModel)
        {
            string sql = "select * from Mis_User where UserName=@username";
            DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text, new SqlParameter("username", loginModel.UserName));
            return BuildLoginModel(dt);
        }

        private LoginModel BuildLoginModel(DataTable dt)
        {
            LoginModel loginModel = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                loginModel=new LoginModel();
                loginModel.UserName = dr["UserName"].ToString();
                loginModel.Password = dr["Password"].ToString();
                loginModel.UserId = Convert.ToInt32(dr["Id"]);
            }
            return loginModel;
        }

        public UserDao()
        {
            this._tableName = "Mis_User";
        }

        protected override void ProcessResult(DataTable dt, ref List<UserEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                UserEntity ue=new UserEntity();
                ue.Id = Convert.ToInt32(dr["Id"]);
                ue.UserName = dr["UserName"].ToString();
                ue.Password = dr["Password"].ToString();
                list.Add(ue);
            }
        }


    }
}
