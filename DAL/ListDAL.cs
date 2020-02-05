using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class ListDAL
    {
        public List<MovieInfoModel> SelectMovieInfo()
        {
            string sql = "select top 10 * from MovieInfo order by MovieScore desc";
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

        public List<MovieInfoModel> SelectMovieInfo4()
        {
            string sql = "  select top 10 * from MovieInfo where MovieArea not in( '大陆' , '中国香港') ";
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

       

        public List<MovieInfoModel> SelectMovieInfo3()
        {
            string sql = "select top 10 * from MovieInfo order by MovieType desc";
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

        public List<MovieInfoModel> SelectMovieInfo2()
        {
            string sql = "  select top 10 * from MovieInfo where MovieArea in( '大陆' , '中国香港') ";
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
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