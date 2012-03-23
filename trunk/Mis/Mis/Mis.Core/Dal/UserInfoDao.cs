using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Mis.Core.Entity;

namespace Mis.Core.Dal
{
    public class UserInfoDao:BaseDao<UserInfoEntity>
    {
        public UserInfoDao()
        {
            this._tableName = "Mis_UserInfo";
        }

        protected override void ProcessResult(DataTable dt, ref List<UserInfoEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                UserInfoEntity entity = new UserInfoEntity();
                entity.Birthday = Convert.ToDateTime(dr["Birthday"]);
                entity.DeptId = Convert.ToInt32(dr["DeptId"]);
                entity.Id = Convert.ToInt32(dr["Id"]);
                entity.PhoneNumber = dr["PhoneNumber"].ToString();
                entity.Position = dr["Position"].ToString();
                entity.RealName = dr["RealName"].ToString();
                entity.Sex = dr["Sex"].ToString();
                entity.UserId = Convert.ToInt32(dr["UserId"]);
                list.Add(entity);
            }
        }
    }
}
