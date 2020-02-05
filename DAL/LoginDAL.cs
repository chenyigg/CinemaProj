using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginDAL
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户集合</returns>
        public List<UsersInfoModel> SelectUsersInfo()
        {
            string str = "select * from UsersInfo";

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str);

            List<UsersInfoModel> ls = new List<UsersInfoModel>();

            while (reader.Read())
            {
                UsersInfoModel UsersInfo = new UsersInfoModel(reader);
                ls.Add(UsersInfo);
            }
            reader.Close();
            return ls;
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="users">用户对象</param>
        /// <returns>Int</returns>
        public int InsertIntoUser(UsersInfoModel users)
        {
            string str = "insert into [dbo].[UsersInfo]([UserAccount],[UsersPwd],[UserEmail]) values(@UserAccount,@UsersPwd,@UserEmail)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserAccount",SqlDbType.NVarChar,50){ Value=users.UserAccount},
                new SqlParameter("@UsersPwd",SqlDbType.NVarChar,50){ Value=users.UsersPwd},
                new SqlParameter("@UserEmail",SqlDbType.NVarChar,50){ Value=users.UserEmail},
            };
            return SqlHelper.ExecuteNonQuery(str, CommandType.Text, sqlParameters);
        }
    }
}