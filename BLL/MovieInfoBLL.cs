using DAL;
using Model;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MovieInfoBLL
    {
        /// <summary>
        /// 上映
        /// </summary>
        /// <returns></returns>
        public List<MovieInfoModel> SelectMovieInfo()
        {
            return new MovieInfoDAL().SelectMovieInfo();
        }

        /// <summary>
        /// 票房
        /// </summary>
        /// <returns></returns>
        public List<MovieMoneyTopModel> SelectMovieMoneyTopModel()
        {
            return new MovieInfoDAL().SelectMovieMoneyTop();
        }

        public List<MovieInfoModel> search(string v)
        {
            return new MovieInfoDAL().search(v);
        }

        /// <summary>
        /// 未上映
        /// </summary>
        /// <returns></returns>
        public List<MovieInfoModel> SelectNoUpMovieInfo()
        {
            return new MovieInfoDAL().SelectNoUpMovieInfo();
        }

        public List<MovieInfoModel> SelectScoreMovieInfo()
        {
            return new MovieInfoDAL().SelectScoreMovieInfo();
        }

        public List<MovieInfoModel> SelectMovieInfo(int a)
        {
            return new MovieInfoDAL().SelectMovieInfo(a);
        }
    }
}