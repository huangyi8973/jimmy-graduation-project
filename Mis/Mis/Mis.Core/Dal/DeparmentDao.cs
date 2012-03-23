using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Mis.Core.Entity;

namespace Mis.Core.Dal
{
    public class DeparmentDao:BaseDao<DeparmentEntity>
    {
        public DeparmentDao()
        {
            this._tableName = "Mis_Deparment";
        }

        protected override void ProcessResult(System.Data.DataTable dt, ref List<DeparmentEntity> list)
        {
            foreach(DataRow dr in dt.Rows)
            {
                DeparmentEntity entity=new DeparmentEntity();
                entity.Id = Convert.ToInt32(dr["Id"]);
                entity.DeptName = dr["DeptName"].ToString();
                list.Add(entity);
            }
        }
    }
}
