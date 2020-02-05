using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UrlMsgInfoDAL
    {
        public int Update()
        {
            string str = "update UrlCountInnfo Set Msg = Msg+1";
            int k = SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text);
            str = "select Msg from UrlCountInnfo";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(str);
            while (reader.Read())
            {
                k = reader.GetInt32(0);
            }
            return k;
        }
    }
}