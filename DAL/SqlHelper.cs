using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    internal class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["conn"].ToString();

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">Sql语句类型</param>
        /// <param name="parameters">Sql语句参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        conn.Close();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///封装一个执行返回单个对象的方法
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">Sql语句参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 返回多行多列的数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">Sql语句参数</param>
        /// <returns></returns>
        public static SqlDataReader GetSqlDataReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                try
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    throw;
                }
            }
        }

        /// <summary>
        /// 执行返回DataTable的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
            {
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// 执行双向查询
        /// </summary>
        /// <param name="cmdText">命令文本：查询语句或者存储过程</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">可选的查询参数</param>
        /// <returns>数据库读取器对象</returns>
        public static SqlDataReader ExecuteReader(
            string cmdText,
            CommandType cmdType,
            params SqlParameter[] cmdParams)
        {
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                if (cmdParams != null)
                {
                    cmd.Parameters.AddRange(cmdParams);
                }
                cmd.CommandType = cmdType;
                conn.Open();
                try
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    throw;
                }
            }
        }
    }
}