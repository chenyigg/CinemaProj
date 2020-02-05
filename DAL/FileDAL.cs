using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class FileDAL
    {
        /// <summary>
        /// 查询所有电影信息
        /// </summary>
        /// <returns></returns>
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
            reader.Close();
            return ls;
        }

        public List<MovieInfoModel> SelectMovieInfo(int i)
        {
            string sql = "select * from MovieInfo where MovieScore>9";
            SqlDataReader reader = SqlHelper.GetSqlDataReader(sql);
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            while (reader.Read())
            {
                MovieInfoModel mov = new MovieInfoModel(reader);
                ls.Add(mov);
            }
            reader.Close();
            reader.Close();
            return ls;
        }

        public List<MovieInfoModel> SelectMovieInfo(int i, int j)
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
            reader.Close();
            return ls;
        }

        /// <summary>
        /// 分页查电影
        /// </summary>
        /// <returns></returns>
        public List<MovieInfoModel> SelectPageMovieInfo(int pageSize, int pageNum, out int pageCount)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@PageSize",System.Data.SqlDbType.Int){Value=pageSize },
                new SqlParameter("@PageNum",System.Data.SqlDbType.Int){Value=pageNum },
            };
            SqlDataReader reader = SqlHelper.ExecuteReader("proc_SelectPageMovieInfo", System.Data.CommandType.StoredProcedure, sqlParameters);
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            pageCount = 0;
            if (reader.Read())
            {
                pageCount = reader.GetInt32(0);
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    MovieInfoModel m = new MovieInfoModel(reader);
                    ls.Add(m);
                }
            }
            reader.Close();
            return ls;
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<MovieInfoModel> SelectPageMovieType(int pageSize, int pageNum, out int pageCount, string MovieType, string MovieArea, string MovieYears)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@PageSize",System.Data.SqlDbType.Int){Value=pageSize },
                new SqlParameter("@PageNum",System.Data.SqlDbType.Int){Value=pageNum },
                 new SqlParameter("@MovieType",System.Data.SqlDbType.NVarChar,50){Value=MovieType },
                   new SqlParameter("@MovieArea",System.Data.SqlDbType.NVarChar,50){Value=MovieArea },
                     new SqlParameter("@MovieYears",System.Data.SqlDbType.NVarChar,50){Value=MovieYears }
            };
            SqlDataReader reader = SqlHelper.ExecuteReader("proc_SelectPageMovieType", System.Data.CommandType.StoredProcedure, sqlParameters);
            List<MovieInfoModel> ls = new List<MovieInfoModel>();
            pageCount = 0;
            if (reader.Read())
            {
                pageCount = reader.GetInt32(0);
            }
            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    MovieInfoModel m = new MovieInfoModel(reader);
                    ls.Add(m);
                }
            }
            reader.Close();
            return ls;
        }
    }
}