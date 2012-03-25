using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Mis.Core.DBUtilty;
using Mis.Core.Model;
using Mis.Core.Entity;

namespace Mis.Core.Dal
{
    public class RoleDao:BaseDao<RoleEntity>
    {
        public RoleCacheModel GetRoleByUserId(int userId)
        {
            string sql = "select r.Id,r.RoleName from Mis_Role r,Mis_UserToRole ur where ur.UserId=@userid and ur.RoleId=r.Id";
            DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text, new SqlParameter("userid", userId));
            RoleCacheModel roleCacheModel = new RoleCacheModel();
            roleCacheModel.Id = dt.Rows[0]["Id"].ToString();
            roleCacheModel.RoleName = dt.Rows[0]["RoleName"].ToString();
            return roleCacheModel;
        }

        public List<RoleCacheModel> GetRolesByUserId(int userId)
        {
            string sql = "select r.Id,r.RoleName from Mis_Role r,Mis_UserToRole ur where ur.UserId=@userid and ur.RoleId=r.Id";
            DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text, new SqlParameter("userid", userId));
            List<RoleCacheModel> roleCacheModels=new List<RoleCacheModel>();
            foreach(DataRow dr in dt.Rows)
            {
                RoleCacheModel roleCacheModel = new RoleCacheModel();
                roleCacheModel.Id = dr["Id"].ToString();
                roleCacheModel.RoleName = dr["RoleName"].ToString();
                roleCacheModels.Add(roleCacheModel);
            }

            return roleCacheModels;
        }

        public RoleDao()
        {
            this._tableName = "Mis_Role";
        }

        protected override void ProcessResult(DataTable dt, ref List<RoleEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                RoleEntity re = new RoleEntity();
                re.Id = Convert.ToInt32(dr["Id"]);
                re.RoleName = dr["RoleName"].ToString();
                list.Add(re);
            }
        }
    }
}
