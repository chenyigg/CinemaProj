using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class FileBLL
    {
        public List<MovieInfoModel> SelectMovieInfo()
        {
            return new FileDAL().SelectMovieInfo();
        }

        public List<MovieInfoModel> SelectMovieInfo(int i)
        {
            return new FileDAL().SelectMovieInfo(i);
        }

        public List<MovieInfoModel> SelectMovieInfo(int i, int j)
        {
            return new FileDAL().SelectMovieInfo(i, j);
        }

        /// <summary>
        /// 页面加载分页电影信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNum"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<MovieInfoModel> SelectPageMovieInfo(int PageSize, int PageNum, out int Count)
        {
            return new FileDAL().SelectPageMovieInfo(PageSize, PageNum, out Count);
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageCount"></param>
        /// <param name="MovieType"></param>
        /// <param name="MovieArea"></param>
        /// <param name="MovieYears"></param>
        /// <returns></returns>
        public List<MovieInfoModel> SelectPageMovieType(int pageSize, int pageNum, out int pageCount, string MovieType, string MovieArea, string MovieYears)
        {
            if (MovieType == "全部")
            {
                MovieType = "";
            }
            if (MovieArea == "全部")
            {
                MovieArea = "";
            }
            if (MovieYears == "全部")
            {
                MovieYears = "";
            }
            return new FileDAL().SelectPageMovieType(pageSize, pageNum, out pageCount, MovieType, MovieArea, MovieYears);
        }
    }
}