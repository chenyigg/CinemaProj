using DAL;
using Model;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DetailsBLL
    {
        /// <summary>
        /// 查询该电影信息
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public MovieInfoModel SelectMovieInfo(MovieInfoModel mi)
        {
            return new DetailsDAL().SelectMovieInfo(mi);
        }

        /// <summary>
        /// 查询该电影所有评论
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public List<CommentModel> SelectCommentInfo(MovieInfoModel mi, int pageSize, int pageNum, out int pageCount)
        {
            List<CommentModel> ls = new DetailsDAL().SelectCommentInfo(mi, pageSize, pageNum, out pageCount);
            for (int j = 0; j < ls.Count; j++)
            {
                if (String.IsNullOrEmpty(ls[j].UserFace))
                {
                    ls[j].UserFace = "暂未登录.jpg";
                }
            }
            return ls;
        }

        public int InsertCommentInfo(CommentModel mi)
        {
            return new DetailsDAL().InsertCommentInfo(mi);
        }
    }
}