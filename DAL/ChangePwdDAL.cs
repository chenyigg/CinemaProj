using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChangePwdDAL
    {
        public UsersInfoModel HasPwd(UsersInfoModel use)
        {
            string str = "select * from UsersInfo where [UserAccount]=@UserAccount and [UsersPwd]=@UsersPwd";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@UserAccount",System.Data.SqlDbType.NVarChar){Value=use.UserAccount },
                new SqlParameter("@UsersPwd",System.Data.SqlDbType.NVarChar){ Value=use.UsersPwd}
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            UsersInfoModel us = new UsersInfoModel();
            while (reader.Read())
            {
                us = new UsersInfoModel(reader);
            }
            reader.Close();
            return us;
        }

        public int UpdatePwd(UsersInfoModel use)
        {
            string str = "Update UsersInfo Set UsersPwd = @UsersPwd where [UserAccount]=@UserAccount";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@UserAccount",System.Data.SqlDbType.NVarChar){Value=use.UserAccount },
                new SqlParameter("@UsersPwd",System.Data.SqlDbType.NVarChar){ Value=use.UsersPwd}
            };

            int b = SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, sqlParameters);

            return b;
        }
    }
}