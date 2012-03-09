using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;
using System.Data;

namespace Mis.Core.Dal
{
    public class NoticeDao:BaseDao<NoticeEntity>
    {
        public NoticeDao()
        {
            this._tableName = "Mis_Notice";
        }
        protected override void ProcessResult(System.Data.DataTable dt, ref List<NoticeEntity> list)
        {
            foreach (DataRow dr in dt.Rows)
            {
                NoticeEntity entity=new NoticeEntity();
                entity.Id = Convert.ToInt32(dr["Id"]);
                entity.Title = dr["Title"].ToString();
                entity.Content = dr["Content"].ToString();
                entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
                entity.UserName = dr["UserName"].ToString();
                list.Add(entity);
            }
        }
    }
}
