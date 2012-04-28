using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using Mis.Core.DBUtilty;

namespace Mis.Core.Dal
{
    public abstract class BaseDao<T> : IDao<T>
    {
        protected string _tableName = "";

        /// <summary>
        /// 执行更新操作
        /// </summary>
        /// <param name="obj">实体实例</param>
        /// <returns>受影响的行数</returns>
        public virtual int Update(T obj)
        {
            int result = 0;
            if (null != obj)
            {
                //通过反射获得实例里的字段
                Type type = obj.GetType();
                Hashtable ht = new Hashtable();
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    ht.Add(pi.Name, pi.GetValue(obj, null));
                }

                //开始构建SQL语句
                string sql = String.Format("update {0} set", _tableName);
                List<SqlParameter> par = new List<SqlParameter>();
                foreach (string name in ht.Keys)
                {
                    object o = ht[name];
                    if(o!=null&&!IsEmpty(o)&& !name.Equals("Id"))
                    {
                        sql += String.Format(" [{0}]=@{0},", name);
                        par.Add(new SqlParameter(name, o));
                    }
                }
                sql = sql.Remove(sql.Length - 1, 1);    //删除最后一个逗号
                sql += " where Id=@id";
                par.Add(new SqlParameter("id", Convert.ToInt32(ht["Id"].ToString())));

                result = SQLHelp.ExecuteNoQuery(sql, CommandType.Text, par.ToArray());
            }
            return result;
        }

        /// <summary>
        /// 执行添加操作
        /// </summary>
        /// <param name="obj">实体实例</param>
        /// <returns>受影响的行数</returns>
        public virtual int Add(T obj)
        {
            int result = 0;
            if (null != obj)
            {
                Hashtable ht = GetProperties(obj);

                //开始构建SQL语句
                string sql_a = String.Format("insert into {0}(", _tableName);
                string sql_b = " values(";
                List<SqlParameter> par = new List<SqlParameter>();
                foreach (string name in ht.Keys)
                {
                    object o = ht[name];
                    if (null != o && !name.Equals("Id"))
                    {
                        sql_a += String.Format("[{0}],", name);
                        sql_b += String.Format("@{0},", name);
                        par.Add(new SqlParameter(name, o));
                    }
                }
                sql_a = sql_a.Remove(sql_a.Length - 1, 1);    //删除最后一个逗号
                sql_b = sql_b.Remove(sql_b.Length - 1, 1);    //删除最后一个逗号
                sql_a += ")";
                sql_b += ")";
                string sql = String.Concat(sql_a, sql_b);
                sql += ";select @@identity;";
                result = Convert.ToInt32(SQLHelp.ExecuteScalar(sql, CommandType.Text, par.ToArray()));
            }
            return result;
        }


        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="IdList">ID列表</param>
        /// <returns>受影响的行数</returns>
        public virtual int Del(params int[] IdList)
        {
            int result = 0;
            if (null != IdList && IdList.Length > 0)
            {
                string sql;
                List<SqlParameter> par = new List<SqlParameter>();
                if (IdList.Length == 1)
                {
                    sql = String.Format("delete from {0} where Id=@id", _tableName);
                    par.Add(new SqlParameter("id", IdList[0]));
                }
                else
                {
                    sql = String.Format("delete from {0} where Id in(", _tableName);

                    for (int index = 0; index < IdList.Length; index++)
                    {
                        sql += String.Format("@{0},", index);
                        par.Add(new SqlParameter(index.ToString(), IdList[index]));
                    }
                    sql = sql.Remove(sql.Length - 1, 1); //删除最后一个逗号
                    sql += ")";
                }
                result = SQLHelp.ExecuteNoQuery(sql, CommandType.Text, par.ToArray());
            }
            return result;
        }

        public virtual int Del(T obj)
        {
            int result = 0;
            Hashtable htProperties = GetProperties(obj);
            string sql = "delete from " + this._tableName;
            sql += " where ";

            //where
            List<SqlParameter> par = new List<SqlParameter>();
            foreach (string name in htProperties.Keys)
            {
                object o = htProperties[name];

                if (null!=o&&!IsEmpty(o))
                {
                    sql += string.Format(" {0}=@{0} and", name);
                    par.Add(new SqlParameter(name, o));
                }
            }
            sql = sql.Remove(sql.Length - 3, 3); //删除最后一个and
            result = SQLHelp.ExecuteNoQuery(sql, CommandType.Text, par.ToArray());

            return result;
        }


        private bool IsEmpty(object obj)
        {
            Type valueType = obj.GetType();
            bool result = false;

            switch (valueType.Name)
            {

                case "String":
                    if (String.IsNullOrEmpty(obj.ToString()))
                    {
                        result = true;
                    }
                    break;
                case "Int32":
                    if (Convert.ToInt32(obj) == 0)
                    {
                        result = true;
                    }
                    break;
            }


            return result;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns>数据集</returns>
        public List<T> Find()
        {
            return this.Find(0, 0);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="obj">条件</param>
        /// <returns></returns>
        public List<T> Find(T obj)
        {
            return this.Find(0, 0, obj);
        }
        /// <summary>
        /// 带翻页的查询
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="pagesize">每页的数据条数</param>
        /// <returns>数据集</returns>
        public List<T> Find(int page, int pagesize)
        {
            List<T> list = new List<T>();
            string sql = "";
            if (page == 0 || pagesize == 0)
            {
                sql = "select  * from " + this._tableName;
            }
            else
            {
                sql = "select top " + pagesize + " * from " + this._tableName + " where Id not in (select top " +
                      (page - 1) * pagesize + "Id from " + this._tableName + ")";
            }
            DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text);
            ProcessResult(dt, ref list);
            return list;
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>实体</returns>
        public virtual T GetEntity(int Id)
        {
            List<T> list = new List<T>();
            string sql = String.Format("select * from {0} where Id={1}", _tableName, Id);
            DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text);
            ProcessResult(dt, ref list);
            if (list.Count > 0)
            {
                return list[0];
            }
            return default(T);//指定类型参数的默认值。 这对于引用类型为 null，对于值类型为零
        }

        /// <summary>
        /// 带条件的翻页查询
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="pagesize">每页的数据条数</param>
        /// <param name="obj">查询条件的实体</param>
        /// <returns>数据集</returns>
        public List<T> Find(int page, int pagesize, T obj)
        {
            List<T> list = new List<T>();
            if (null != obj)
            {
                //通过反射获得实例里的字段
                Hashtable htProperties = this.GetProperties(obj);
 

                //开始构建SQL语句
                //构建查询条件
                string sql_where = "";  //由于有两个地方需要用到条件查询，就把条件体单独提取出来，后面在添加进去
                List<SqlParameter> par = new List<SqlParameter>();
                foreach (string name in htProperties.Keys)
                {
                    object o = htProperties[name];
                    if (null != o)
                    {
                        Type valueType = htProperties[name].GetType();
                        switch (valueType.Name)
                        {
                            case "String":
                                sql_where += String.Format(" [{0}] like @{0} and", name);
                                par.Add(new SqlParameter(name, String.Format("%{0}%", o)));
                                break;
                            case "Int32":
                                if ((int)o != 0)
                                {
                                    sql_where += String.Format(" [{0}]=@{0} and", name);
                                    par.Add(new SqlParameter(name, o));
                                }
                                break;
                        }
                    }
                }
                sql_where = sql_where.Remove(sql_where.Length - 3, 3);    //删除最后一个and

                //构建完整SQL语句
                string sql = "";
                if (page == 0 || pagesize == 0)
                {
                    sql = "select  * from " + this._tableName + " where ";
                    sql += sql_where;
                }
                else
                {
                    sql = "select top " + pagesize + " * from " + this._tableName + " where Id not in (select top " + (page - 1) * pagesize + " Id from " + this._tableName + " where ";
                    //把条件添加到SQL语句里面
                    sql += sql_where;
                    sql += ") and ";
                    sql += sql_where;
                }

                //执行SQL语句
                DataTable dt = SQLHelp.ExecuteQuery(sql, CommandType.Text, par.ToArray());
                ProcessResult(dt, ref list);
            }
            return list;
        }

        /// <summary>
        /// 通过反射获得实例里的字段
        /// </summary>
        /// <param name="obj">实例</param>
        /// <returns></returns>
        private Hashtable GetProperties(T obj)
        {
            Type type = obj.GetType();
            Hashtable ht = new Hashtable();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                ht.Add(pi.Name, pi.GetValue(obj, null));
            }
            return ht;
        }

        //查询是否已经存在相同的数据
        public bool IsExist(T obj)
        {
            List<T> list = new List<T>();
            int result = 0;
            if (null != obj)
            {
                //通过反射获得实例里的字段
                Hashtable ht = this.GetProperties(obj);

                //开始构建SQL语句
                //构建查询条件
                string sql_where = "";  //由于有两个地方需要用到条件查询，就把条件体单独提取出来，后面在添加进去
                List<SqlParameter> par = new List<SqlParameter>();
                foreach (string name in ht.Keys)
                {
                    object o = ht[name];
                    if (null != o&&!name.Equals("Id"))
                    {
                        Type valueType = ht[name].GetType();
                        sql_where += String.Format(" [{0}]=@{0} and", name);
                        par.Add(new SqlParameter(name, o));
                    }
                }
                sql_where = sql_where.Remove(sql_where.Length - 3, 3);    //删除最后一个and

                //构建完整SQL语句
                string sql = "";

                    sql = "select  count(*) from " + this._tableName + " where ";
                    sql += sql_where;

                //执行SQL语句
                result = Convert.ToInt32(SQLHelp.ExecuteScalar(sql, CommandType.Text, par.ToArray()));
                
            }
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 查找的数据处理，把DataTable里的数据填充到实体里面，由继承的类实现填充过程
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="list">实体列表</param>
        protected abstract void ProcessResult(DataTable dt, ref List<T> list);
    }
}
