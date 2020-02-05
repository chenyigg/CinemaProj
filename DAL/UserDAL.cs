using Models;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 根据账号判断该用户资料是否完善
        /// </summary>
        /// <param name="User">用户对象</param>
        /// <returns>UserInfo集合</returns>
        public UsersInfoModel SelectUserInfoFromAccount(UsersInfoModel User)
        {
            string str = "select * from UsersInfo where UserAccount=@Account";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Account",System.Data.SqlDbType.NVarChar,50){Value= User.UserAccount}
            };

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str, sqlParameters);

            UsersInfoModel use = null;
            while (reader.Read())
            {
                use = new UsersInfoModel(reader);
            }
            reader.Close();

            return use;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="use">用户对象</param>
        /// <returns>Int</returns>
        public int UpdataUsersInfo(UsersInfoModel use)
        {
            if (!String.IsNullOrEmpty(use.UserFace))
            {
                string str = "update UsersInfo Set UserName=@UserName,UserSex=@UserSex,UserPhone=@UserPhone,UserIDCard=@UserIDCard,UserAddress=@UserAddress,UserFace=@UserFace where UserAccount=@UserAccount";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@UserName",System.Data.SqlDbType.NVarChar,50){ Value=use.UserName},
                     new SqlParameter("@UserAddress",System.Data.SqlDbType.NVarChar,50){ Value=use.UserAddress},
                     new SqlParameter("@UserSex",System.Data.SqlDbType.NVarChar,50){ Value=use.UserSex},
                     new SqlParameter("@UserPhone",System.Data.SqlDbType.NVarChar,50){ Value=use.UserPhone},
                     new SqlParameter("@UserIDCard",System.Data.SqlDbType.NVarChar,50){ Value=use.UserIDCard},
                     new SqlParameter("@UserFace",System.Data.SqlDbType.NVarChar,50){ Value=use.UserFace},
                     new SqlParameter("@UserAccount",System.Data.SqlDbType.NVarChar,50){ Value=use.UserAccount}
                };

                return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, sqlParameters);
            }
            else
            {
                string str = "update UsersInfo Set UserName=@UserName,UserSex=@UserSex,UserPhone=@UserPhone,UserIDCard=@UserIDCard,UserAddress=@UserAddress where UserAccount=@UserAccount";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@UserName",System.Data.SqlDbType.NVarChar,50){ Value=use.UserName},
                     new SqlParameter("@UserAddress",System.Data.SqlDbType.NVarChar,50){ Value=use.UserAddress},
                     new SqlParameter("@UserSex",System.Data.SqlDbType.NVarChar,50){ Value=use.UserSex},
                     new SqlParameter("@UserPhone",System.Data.SqlDbType.NVarChar,50){ Value=use.UserPhone},
                     new SqlParameter("@UserIDCard",System.Data.SqlDbType.NVarChar,50){ Value=use.UserIDCard},
                     new SqlParameter("@UserAccount",System.Data.SqlDbType.NVarChar,50){ Value=use.UserAccount}
                };

                return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, sqlParameters);
            }
        }
    }
}