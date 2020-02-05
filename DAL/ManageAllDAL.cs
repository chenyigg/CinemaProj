using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManageAllDAL
    {
        public int InsertMovie(MovieInfoModel model)
        {
            string sql = "insert into MovieInfo values(@MovieName,@MovieCover,@MovieBrief,@MovieMoney,@MovieReleaseDate,@MovieDuration,@MovieDirect,@MovieType,@MovieArea,@MovieYears,@MovieScore,@MoviePeople)";
            int a = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text,
                new System.Data.SqlClient.SqlParameter("@MovieName", model.MovieName),
                 new System.Data.SqlClient.SqlParameter("@MovieCover", model.MovieCover),
                new System.Data.SqlClient.SqlParameter("@MovieBrief", model.MovieBrief),
                new System.Data.SqlClient.SqlParameter("@MovieMoney", model.MovieMoney),
                new System.Data.SqlClient.SqlParameter("@MovieReleaseDate", model.MovieReleaseDate),
                new System.Data.SqlClient.SqlParameter("@MovieDuration", model.MovieDuration),
                new System.Data.SqlClient.SqlParameter("@MovieDirect", model.MovieDirect),
                new System.Data.SqlClient.SqlParameter("@MovieType", model.MovieType),
                new System.Data.SqlClient.SqlParameter("@MovieArea", model.MovieArea),
                new System.Data.SqlClient.SqlParameter("@MovieYears", model.MovieYears),
                new System.Data.SqlClient.SqlParameter("@MovieScore", model.MovieScore),
                new System.Data.SqlClient.SqlParameter("@MoviePeople", model.MoviePeople));
            return a;
        }

        public int sureChip(string cinemaName, string officeName, string movieName, DateTime time)
        {
            string selectMinutes = "select MovieDuration from MovieInfo where MovieName=@movieName";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(selectMinutes, new SqlParameter("@movieName", movieName));
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            int minutes = ls[0].MovieDuration;
            //插入数据
            string sql = "insert into ChipInfo values((select CinemaID from CinemaInfo where CinemaName=@cinemaName),(select officeID from OfficeInfo where OfficeName=@officeName and CinemaID=(select CinemaID from CinemaInfo where CinemaName=@cinemaName)),@movieName,@time,@time2)";
            int a = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text,
               new SqlParameter("@cinemaName", cinemaName.ToString().Trim()),
               new SqlParameter("@officeName", officeName.ToString().Trim()),
               new SqlParameter("@movieName", movieName.ToString().Trim()),
               new SqlParameter("@time", time),
                new SqlParameter("@time2", time.AddMinutes(minutes))
                );
            //调用存储过程生成座位
            ChipInfoModel chipInfoModel = new ChipInfoModel();
            sql = "select top 1 *from ChipInfo order by ChipInfoID desc";
            var read = SqlHelper.GetSqlDataReader(sql);
            while (read.Read())
            {
                chipInfoModel = new ChipInfoModel(read);
            }

            a += SqlHelper.ExecuteNonQuery("proc_CreateSeat", System.Data.CommandType.StoredProcedure, new SqlParameter("@OfficeID", chipInfoModel.OfficeID), new SqlParameter("@ChipID", chipInfoModel.ChipInfoID));
            return a;
        }

        public List<CinemaInfoModel> selectAllCinema()
        {
            string sql = "select *from CinemaInfo";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            List<CinemaInfoModel> ls = new List<CinemaInfoModel>();
            while (reader.Read())
            {
                CinemaInfoModel mov = new CinemaInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

        public List<OfficeInfoModel> selectCinemaOffice(string cinemaName)
        {
            string sql = "  select *from OfficeInfo where CinemaID=(select CinemaID from CinemaInfo where CinemaName=@cinemaName)";
            List<OfficeInfoModel> list = new List<OfficeInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@cinemaName", cinemaName));
            while (reader.Read())
            {
                OfficeInfoModel mov = new OfficeInfoModel(reader);
                list.Add(mov);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 更改电影信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns>int</returns>
        public int SureUpdateMovie(MovieInfoModel model)
        {
            string sql = "update MovieInfo set MovieCover=@MovieCover,MovieBrief=@MovieBrief,MovieMoney=@MovieMoney,MovieDuration=@MovieDuration,MovieDirect=@MovieDirect,MovieType=@MovieType,MovieArea=@MovieArea,MovieYears=@MovieYears,MovieScore=@MovieScore,MoviePeople=@MoviePeople where MovieName=@MovieName";
            int a = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text,
                new SqlParameter("@MovieName", model.MovieName),
                new SqlParameter("@MovieCover", model.MovieCover),
                new SqlParameter("@MovieBrief", model.MovieBrief),
                new SqlParameter("@MovieMoney", model.MovieMoney),
                new SqlParameter("@MovieDuration", model.MovieDuration),
                new SqlParameter("@MovieDirect", model.MovieDirect),
                new SqlParameter("@MovieType", model.MovieType),
                new SqlParameter("@MovieArea", model.MovieArea),
                new SqlParameter("@MovieYears", model.MovieYears),
                new SqlParameter("@MovieScore", model.MovieScore),
                new SqlParameter("@MoviePeople", model.MoviePeople));
            return a;
        }

        public int DeleteMovie(string deleteMovieName)
        {
            string sql = "delete from MovieInfo where MovieName=@MovieName";
            int a = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new System.Data.SqlClient.SqlParameter("@MovieName", deleteMovieName));
            return a;
        }

        public List<MovieInfoModel> SelectMovieInfo()
        {
            string sql = "select * from MovieInfo";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

        public List<MovieInfoModel> SelectMovieInfo(string textbox)
        {
            string sql = string.Format("select * from MovieInfo where MovieName like '%{0}%'", textbox);
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }
    }
}