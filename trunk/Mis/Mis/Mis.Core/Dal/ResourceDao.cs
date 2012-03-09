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
    public class ResourceDao : BaseDao<ResourceEntity>
    {
        public List<ResourceCacheModel> GetResourceByRoleId(string roleId)
        {
            string sql = "select r.ResourceName,r.Uri,rr.Value,r.CanShowInNav from Mis_Resource r,Mis_RoleToResource rr where rr.RoleId=@roleid and rr.ResourceId=r.Id";
            List<ResourceCacheModel> list = new List<ResourceCacheModel>();
            DataTable dt = SQLHelp.ExecuteQuery(sql,CommandType.Text, new SqlParameter("roleid", Convert.ToInt32(roleId)));
            foreach (DataRow dr in dt.Rows)
            {
                ResourceCacheModel p = new ResourceCacheModel();
                p.ResourceName = dr["ResourceName"].ToString();
                p.Uri = dr["Uri"].ToString();
                p.Value = Convert.ToInt32(dr["Value"]);
                p.CanShowInNav = Convert.ToInt32(dr["CanShowInNav"]).Equals(1);
                list.Add(p);
            }
            return list;
        }

        public ResourceDao()
        {
            this._tableName = "Mis_Resource";
        }

        protected override void ProcessResult(DataTable dt, ref List<ResourceEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ResourceEntity re = new ResourceEntity();
                re.Id = Convert.ToInt32(dr["Id"]);
                re.ResourceName = dr["ResourceName"].ToString();
                re.Uri = dr["Uri"].ToString();
                re.OperateValue = dr["OperateValue"].ToString();
                re.CanShowInNav = Convert.ToInt32(dr["CanShowInNav"]);
                list.Add(re);
            }
        }


        
    }
}
