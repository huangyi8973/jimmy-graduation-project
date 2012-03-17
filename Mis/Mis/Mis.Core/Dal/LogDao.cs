using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Mis.Core.DBUtilty;
using Mis.Core.Entity;

namespace Mis.Core.Dal
{
    public class LogDao:BaseDao<LogEntity>
    {
        protected override void ProcessResult(System.Data.DataTable dt, ref List<LogEntity> list)
        {
            foreach(DataRow dr in dt.Rows)
            {
                LogEntity logEntity=new LogEntity();
                logEntity.Id = Convert.ToInt32(dr["Id"]);
                logEntity.LogTime = DateTime.Parse(dr["LogTime"].ToString());
                logEntity.UserName = dr["UserName"].ToString();
                logEntity.Message = dr["Message"].ToString();
                list.Add(logEntity);
            }
            list.Reverse();
        }

        public LogDao()
        {
            this._tableName = "Mis_Log";
        }

        public void Clean()
        {
            string sql = "delete from " + this._tableName;
            SQLHelp.ExecuteNoQuery(sql,CommandType.Text);
        }
    }
}
