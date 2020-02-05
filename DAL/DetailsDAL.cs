using Model;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DetailsDAL
    {
        /// <summary>
        /// 查询该电影信息
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
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
        /// 插入评论
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public int InsertCommentInfo(CommentModel mi)
        {
            string str = "insert into CommentInfo values(@MovieID,@UsersID,@UserName,@UserFace,@CommentInfo,@CommentTime)";

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@MovieID",System.Data.SqlDbType.Int) {Value=mi.MovieID },
                new SqlParameter("@UsersID",System.Data.SqlDbType.Int) {Value=mi.UsersID },
                new SqlParameter("@UserName",System.Data.SqlDbType.NVarChar,50) {Value=mi.UserName },
                new SqlParameter("@UserFace",System.Data.SqlDbType.NVarChar,50) {Value=mi.UserFace },
                new SqlParameter("@CommentInfo",System.Data.SqlDbType.NVarChar) {Value=mi.CommentInfo },
                new SqlParameter("@CommentTime",System.Data.SqlDbType.NVarChar) {Value=mi.CommentTime }
            };

            return SqlHelper.ExecuteNonQuery(str, System.Data.CommandType.Text, sql);
        }

        /// <summary>
        /// 查询该电影所有评论
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public List<CommentModel> SelectCommentInfo(MovieInfoModel mi, int pageSize, int page, out int pageCount)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@MovieID",System.Data.SqlDbType.Int) {Value=mi.MovieID },
                new SqlParameter("@pageSize",System.Data.SqlDbType.Int) {Value=pageSize },
                new SqlParameter("@page",System.Data.SqlDbType.Int) {Value=page }
            };

            SqlDataReader reader = SqlHelper.ExecuteReader("proc_SelectCommentCount", System.Data.CommandType.StoredProcedure, sql);

            pageCount = 0;

            if (reader.Read())
            {
                pageCount = reader.GetInt32(0);
            }

            List<CommentModel> ls = new List<CommentModel>();

            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    CommentModel us = new CommentModel(reader);
                    ls.Add(us);
                }
            }
            reader.Close();
            return ls;
        }
    }
}