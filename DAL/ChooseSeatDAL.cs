using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model
{
    public class ChooseSeatDAL
    {/// <summary>
     /// 按照厅位加载所有的座位
     /// </summary>
     /// <param name="office"></param>
     /// <returns>List<SeatInfoModel></returns>
        public List<SeatInfoModel> loadSeatInfo(string office, string chipID)
        {
            string sql = string.Format("select *from SeatInfo where officeID={0} and ChipInfoID={1}", office, chipID);
            //string sql = "select *from SeatInfo where officeID=@office";
            List<SeatInfoModel> list = new List<SeatInfoModel>();
            //SqlParameter[] sz = new SqlParameter[]
            //{
            //    new SqlParameter("@office",System.Data.SqlDbType.Int) {Value=office }
            //};

            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            while (reader.Read())
            {
                SeatInfoModel m = new SeatInfoModel(reader);
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 找到电影名
        /// </summary>
        /// <param name="chipInfoID"></param>
        /// <returns></returns>
        public List<CinemaInfoModel> selectCinemaName(string chipInfoID)
        {
            string sql = "select CinemaName,CinemaAddress from CinemaInfo where CinemaID=(select CinemaID from ChipInfo where chipInfoID=@chipInfoID)";
            List<CinemaInfoModel> list = new List<CinemaInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@chipInfoID", chipInfoID));
            while (reader.Read())
            {
                CinemaInfoModel m = new CinemaInfoModel(reader);
                list.Add(m);
            }
            return list;
        }

        public int insertOrder(OrderInfoModel orderInfoModel, out string orderID)
        {
            string sql = "insert into OrderInfo values(@money,@id,@time,@movieName,@address,@officeID,@chipID,@isPay,@payTime)";
            int a = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text,
                new SqlParameter("@money", orderInfoModel.OrderSumMoney),
                new SqlParameter("@id", orderInfoModel.UsersID),
                new SqlParameter("@time", DateTime.Now),
                new SqlParameter("@movieName", orderInfoModel.MovieName),
                new SqlParameter("@address", orderInfoModel.CinemaAddress),
                new SqlParameter("@officeID", orderInfoModel.OfficeID),
                new SqlParameter("@chipID", orderInfoModel.OfficeID),
                new SqlParameter("@isPay", orderInfoModel.IsPay),
                new SqlParameter("@payTime", orderInfoModel.PayTime)
                );
            orderID = "-1";
            string sql2 = "  select top 1 * from OrderInfo order by OrderID desc";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql2);
            while (reader.Read())
            {
                OrderInfoModel order = new OrderInfoModel(reader);
                orderID = order.OrderID.ToString();
                break;
            }

            return a;
        }

        public int insertOrderDetails(OrderDetailsModel orderDetailsModel, string[] strArray, string chipID)
        {
            //找到电影的开始时间和结束时间
            string sqlSelectMoiveTime = "select *from ChipInfo where ChipInfoID=@chipID";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sqlSelectMoiveTime, new SqlParameter("@chipID", chipID));
            ChipInfoModel chipInfoModel = new ChipInfoModel();
            while (reader.Read())
            {
                chipInfoModel = new ChipInfoModel(reader);
            }
            orderDetailsModel.StartTime = chipInfoModel.StartTime;
            orderDetailsModel.StopTime = chipInfoModel.StopTime;
            //记录插入的行数
            int sumCount = 0;
            string sql = "insert into OrderDetails values(@ID,@seatID,@Price,@StarTime,@StopTime)";

            //遍历所有的座位
            foreach (var item in strArray)
            {
                orderDetailsModel.SeatID = int.Parse(item);
                sumCount += SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text,
               new SqlParameter("@ID", orderDetailsModel.OrderID),
               new SqlParameter("@seatID", orderDetailsModel.SeatID),
               new SqlParameter("@Price", orderDetailsModel.OrderDetailsPrice),
               new SqlParameter("@StarTime", orderDetailsModel.StartTime),
               new SqlParameter("@StopTime", orderDetailsModel.StopTime));
            }
            //保证每个座位都插入进去了
            if (sumCount == strArray.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int selectUsersID(string userName)
        {
            string sql = "select UsersID from UsersInfo where UserAccount=@userName";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@userName", userName));
            int userID = -1;
            while (reader.Read())
            {
                UsersInfoModel users = new UsersInfoModel(reader);
                userID = users.UsersID;
                break;
            }
            return userID;
        }

        /// <summary>
        /// 找到厅名
        /// </summary>
        /// <param name="chipInfoID"></param>
        /// <returns></returns>
        public List<OfficeInfoModel> selectOfficeName(string chipInfoID)
        {
            string sql = "select OfficeName from OfficeInfo where OfficeID=(select OfficeID from ChipInfo where chipInfoID=@chipInfoID)";
            List<OfficeInfoModel> list = new List<OfficeInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@chipInfoID", chipInfoID));
            while (reader.Read())
            {
                OfficeInfoModel m = new OfficeInfoModel(reader);
                list.Add(m);
            }
            return list;
        }

        public List<MovieInfoModel> selectMovie(string chipInfoID)
        {
            string sql = "select *from MovieInfo where MovieName=(select MovieName from ChipInfo where chipInfoID=@chipInfoID)";
            List<MovieInfoModel> list = new List<MovieInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@chipInfoID", chipInfoID));
            while (reader.Read())
            {
                MovieInfoModel m = new MovieInfoModel(reader);
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 插入购买的所有座位
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public int insertSeat(string[] strArray, string chipID)
        {
            int sum = 0;
            foreach (var item in strArray)
            {
                string str = "update SeatInfo set IsSeat=2 where SeatID=@item and ChipInfoID=@chipID";
                sum += SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, new SqlParameter("@item", item), new SqlParameter("@chipID", chipID));
            }
            if (sum == strArray.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}