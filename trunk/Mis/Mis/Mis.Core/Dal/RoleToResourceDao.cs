using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Mis.Core.Entity;
using Mis.Core.DBUtilty;

namespace Mis.Core.Dal
{
    class RoleToResourceDao : BaseDao<RoleToResourceEntity>
    {
        public RoleToResourceDao()
        {
            this._tableName = "Mis_RoleToResource";
        }
        protected override void ProcessResult(System.Data.DataTable dt, ref List<RoleToResourceEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var entity = new RoleToResourceEntity
                                 {
                                     Id = Convert.ToInt32(dr["Id"]),
                                     RoleId = Convert.ToInt32(dr["RoleId"]),
                                     ResourceId = Convert.ToInt32(dr["ResourceId"]),
                                     Value = Convert.ToInt32(dr["Value"])
                                 };
                list.Add(entity);
            }
        }

        //public List<RoleToResourceEntity> GetEntityWithoutRoleId(int roleId)
        //{
        //    List<RoleToResourceEntity> list=new List<RoleToResourceEntity>();
        //    string sql = "select * from Mis_RoleToResource where RoleId not in(@roleid)";
        //    DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text, new SqlParameter("roleid", roleId));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        RoleToResourceEntity entity = new RoleToResourceEntity
        //                                          {
        //                                              Id = Convert.ToInt32(dr["Id"]),
        //                                              RoleId = Convert.ToInt32(dr["RoleId"]),
        //                                              ResourceId = Convert.ToInt32(dr["ResourceId"])
        //                                          };
        //        list.Add(entity);
        //    }
        //    return list;
        //}
    }
}
