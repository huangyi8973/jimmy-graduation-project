using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Mis.Core.DBUtilty
{
    public class SQLHelp
    {
        //读取配置文件
        private static readonly string connString = WebConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
        

        //自己的电脑
        //private const string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\mycode\csharp\jimmygraduation\Mis\Mis\App_Data\Mis.mdf;Integrated Security=True;User Instance=True";

        //公司
        //private const string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\mycode\jimmygraduation\Mis\Mis\App_Data\Mis.mdf;Integrated Security=True;User Instance=True";
        /// <summary>
        /// 执行非查询的语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="par">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNoQuery(string sql, CommandType commandType, params SqlParameter[] par)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, sql, par);
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }


        /// <summary>
        /// 执行查询语句，参数可选
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="commandType">command的类型</param>
        /// <param name="par">参数</param>
        /// <returns>结果表</returns>
        public static DataTable ExecuteQuery(string sql, CommandType commandType, params SqlParameter[] par)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, sql, par);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        public static Object ExecuteScalar(string sql, CommandType commandType, params SqlParameter[] par)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, sql, par);
                    object obj=cmd.ExecuteScalar();
                    return obj;
                }
            }
        }
        /// <summary>
        /// 给command提供参数
        /// </summary>
        /// <param name="cmd">command实例</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="par">参数</param>
        private static void PrepareCommand(SqlCommand cmd,string sql, params SqlParameter[] par)
        {
            cmd.CommandText = sql;
            if (null != par && par.Length > 0)
            {
                //before add parameter to command,must be clear parameter
                cmd.Parameters.Clear();
                foreach (SqlParameter p in par)
                {
                    cmd.Parameters.Add(p);
                }
            }
        }
        
        
    }
}
