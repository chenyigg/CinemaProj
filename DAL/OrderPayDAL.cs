using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderPayDAL
    {
        public OrderShow LoadInfo(OrderInfoModel om)
        {
            string str = "select oi.MovieName,oi.OrderID,oi.OrderTime,oi.PayTime,oi.OrderSumMoney,ci.CinemaName,ofi.OfficeName,od.SeatID,oi.ChipInfoID,ofi.NullColOne,ofi.NullColTwo from[dbo].[OrderInfo] oi,[dbo].[OrderDetails] od ,[dbo].[CinemaInfo] ci,[dbo].[OfficeInfo] ofi where oi.OrderID=od.OrderID and oi.CinemaAddress=ci.CinemaAddress and oi.OfficeID=ofi.OfficeID and oi.OrderID=@OrderID and oi.IsPay=0";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@OrderID",System.Data.SqlDbType.Int){Value=om.OrderID }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(str, System.Data.CommandType.Text, sqlParameters);

            List<OrderShow> ls = new List<OrderShow>();
            while (reader.Read())
            {
                ls.Add(new OrderShow(reader));
            }
            reader.Close();
            ls[0].SeatSum = new string[ls.Count];
            for (int i = 0; i < ls.Count; i++)
            {
                ls[0].SeatSum[i] = ls[i].SeatID;
            }
            return ls[0];
        }

        public int SelectIsPay()
        {
            string str = "select Msg from UrlCountInnfo";

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str);

            int k = 0;
            while (reader.Read())
            {
                k = reader.GetInt32(0);
            }
            reader.Close();

            return k;
        }

        public int UpdateSeat(string v)
        {
            string str = "update [dbo].[OrderInfo] Set IsPay = 1  where [dbo].[OrderInfo].OrderID = @OrderID ";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@OrderID",System.Data.SqlDbType.Int){Value=Convert.ToInt32(v) }
            };
            return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, sqlParameters);
        }
    }
}