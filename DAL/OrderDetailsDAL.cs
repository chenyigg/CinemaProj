using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailsDAL
    {
        /// <summary>
        /// 返回该用户的所有订单
        /// </summary>
        /// <param name="UserAccount"></param>
        /// <returns></returns>
        public List<OrderShow> LoadInfo(string UserAccount)
        {
            string str = " select distinct oi.OrderID,oi.IsPay ,od.StartTime, oi.MovieName,ofi.OfficeName,oi.OrderSumMoney,oi.OrderTime from[dbo].[OrderInfo] oi,[dbo].[OfficeInfo] ofi, [dbo].[CinemaInfo] ci,[dbo].[OrderDetails] od where oi.OfficeID=ofi.OfficeID and ci.CinemaAddress=oi.CinemaAddress and od.OrderID=oi.OrderID and [UsersID] = (select [UsersID] from [dbo].[UsersInfo] where [UserAccount]=@UserAccount)";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@UserAccount",System.Data.SqlDbType.NVarChar){Value=UserAccount }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str,System.Data.CommandType.Text,sqlParameters);

            List<OrderShow> ls = new List<OrderShow>();
            while (reader.Read())
            {
                ls.Add(new OrderShow(reader));
            }
            reader.Close();
            return ls;
        }
    }
}
