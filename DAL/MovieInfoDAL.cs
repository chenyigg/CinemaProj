using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MovieInfoDAL
    {
        /// <summary>
        /// 查询所有电影
        /// </summary>
        /// <returns>电影信息</returns>
        public List<MovieInfoModel> SelectMovieInfo()
        {
            string sql = "select * from MovieInfo where MovieReleaseDate < GETDATE()";
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

        public List<MovieInfoModel> search(string v)
        {
            string sql = "  select * from MovieInfo where MovieName = @MovieName";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql, new SqlParameter("@MovieName", v));
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            return ls;
        }

        /// <summary>
        /// 查询未上映电影
        /// </summary>
        /// <returns>电影信息</returns>
        public List<MovieInfoModel> SelectNoUpMovieInfo()
        {
            string sql = "select * from MovieInfo where MovieReleaseDate > GETDATE()";
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

        public List<MovieInfoModel> SelectScoreMovieInfo()
        {
            string sql = "select Top 10* from [dbo].[MovieInfo] order by MovieScore desc";
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

        /// <summary>
        /// 查询今日票房
        /// </summary>
        /// <returns></returns>
        public List<MovieMoneyTopModel> SelectMovieMoneyTop()
        {
            #region 返回Top10票房最高的电影信息

            string str1 = "select* from[dbo].[MovieInfo] where[MovieName] in(" +
                          "Select top 10 [MovieName] from[dbo].[OrderInfo] where[MovieName] in " +
                          "(Select[MovieName] from [dbo].[MovieInfo]) " +
                          "and [OrderID] in " +
                          "(Select distinct [OrderID] from[dbo].[OrderInfo] where[OrderTime]>" +
                          "(" +
                          "select convert(varchar(10), getdate(), 120)+' 00:00:00')" +
                          ")" +
                          "group by[MovieName] order by Sum([OrderSumMoney]) desc)";

            SqlDataReader reader1 = SqlHelper.GetSqlDataReader(str1);
            List<MovieMoneyTopModel> ls1 = new List<MovieMoneyTopModel>();
            while (reader1.Read())
            {
                MovieMoneyTopModel m1 = new MovieMoneyTopModel(reader1);
                ls1.Add(m1);
            }
            reader1.Close();

            #endregion 返回Top10票房最高的电影信息

            #region 返回Top10票房总价格

            string str2 = "Select top 10[MovieName],Sum([OrderSumMoney]) as SumMoney from[dbo].[OrderInfo] where[MovieName] in" +
                           "(Select[MovieName] from[dbo].[MovieInfo]) " +
                           "and" +
                           "[OrderID] in " +
                           "(" +
                           "Select distinct[OrderID] from[dbo].[OrderInfo] where[OrderTime] >" +
                           "(" +
                           "select convert(varchar(10), getdate(), 120) + ' 00:00:00'" +
                           ")" +
                           ") " +
                           "group by[MovieName] order by Sum([OrderSumMoney]) desc";

            DataTable dt = SqlHelper.ExecuteDataTable(str2);
            for (int i = 0; i < ls1.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    ls1[i].SumMoney = dt.Rows[i]["SumMoney"].ToString();
                }
            }

            return ls1;

            #endregion 返回Top10票房总价格
        }

        public List<MovieInfoModel> SelectMovieInfo(int a)
        {
            string sql = "select top 7 * from MovieInfo";
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