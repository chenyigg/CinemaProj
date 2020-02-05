using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class ChooseCinemaDAL
    {
        public MovieInfoModel SelectMovieInfo(MovieInfoModel mi)
        {
            string str = "select * from MovieInfo where MovieID=@MovieID";

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@MovieID",System.Data.SqlDbType.Int) {Value=mi.MovieID }
            };

            SqlDataReader reader = SqlHelper.GetSqlDataReader(str, sql);

            MovieInfoModel us = null;

            while (reader.Read())
            {
                us = new MovieInfoModel(reader);
            }
            reader.Close();
            return us;
        }

        /// <summary>
        /// 查询所有正在放映此电影的影院
        /// </summary>
        /// <param name="model"></param>
        /// <returns> List<CinemaInfoModel></returns>
        public List<CinemaInfoModel> chooseCinema(MovieInfoModel model)
        {
            //--查询正在放映此电影的所有电影
            //--开场十五分钟前
            string sql = "select * from CinemaInfo where CinemaID in (select CinemaID from ChipInfo where MovieName = (select MovieName from MovieInfo where MovieID = @MovieID) and datediff(MINUTE, getdate(), StartTime) > 15)";
            List<CinemaInfoModel> list = new List<CinemaInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@MovieID", model.MovieID));
            while (reader.Read())
            {
                CinemaInfoModel m = new CinemaInfoModel(reader);
                list.Add(m);
            }
            return list;
        }
    }
}