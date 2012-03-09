using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;
using System.Data;

namespace Mis.Core.Dal
{
    class UserToRoleDao:BaseDao<UserToRoleEntity>
    {
        public UserToRoleDao()
        {
            this._tableName = "Mis_UserToRole";
        }
        protected override void ProcessResult(System.Data.DataTable dt, ref List<UserToRoleEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                UserToRoleEntity entity=new UserToRoleEntity();
                entity.UserId = Convert.ToInt32(dr["UserId"]);
                entity.RoleId = Convert.ToInt32(dr["RoleId"]);
                entity.Id = Convert.ToInt32(dr["Id"]);
                list.Add(entity);
            }
        }

        public UserToRoleEntity GetEntityByUserId(int userId)
        {
            return this.Find(new UserToRoleEntity
                                 {
                                     UserId = userId
                                 }).FirstOrDefault();
        }

    }
}
