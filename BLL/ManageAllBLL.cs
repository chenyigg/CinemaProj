using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ManageAllBLL
    {
        #region 电影管理

        /// <summary>
        /// 添加电影
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMovie(MovieInfoModel model)
        {
            return new ManageAllDAL().InsertMovie(model);
        }

        /// <summary>
        /// 查询所有电影
        /// </summary>
        /// <returns></returns>
        public List<MovieInfoModel> SelectMovieInfo()
        {
            return new ManageAllDAL().SelectMovieInfo();
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="textbox"></param>
        /// <returns></returns>
        public List<MovieInfoModel> SelectMovieInfo(string textbox)
        {
            return new ManageAllDAL().SelectMovieInfo(textbox);
        }

        /// <summary>
        /// 查询所有的影院
        /// </summary>
        /// <returns></returns>
        public List<CinemaInfoModel> selectAllCinema()
        {
            return new ManageAllDAL().selectAllCinema();
        }

        public int sureChip(string cinemaName, string officeName, string movieName, DateTime time)
        {
            return new ManageAllDAL().sureChip(cinemaName, officeName, movieName, time);
        }

        /// <summary>
        /// 查询所有的电影
        /// </summary>
        /// <returns></returns>
        public List<MovieInfoModel> selectAllMovie()
        {
            return new ManageAllDAL().SelectMovieInfo();
        }

        /// <summary>
        /// 删除电影
        /// </summary>
        /// <param name="deleteMovieName"></param>
        /// <returns></returns>
        public int DeleteMovie(string deleteMovieName)
        {
            return new ManageAllDAL().DeleteMovie(deleteMovieName);
        }

        /// <summary>
        /// 找寻影院对应的影厅
        /// </summary>
        /// <param name="cinemaName"></param>
        /// <returns></returns>
        public List<OfficeInfoModel> selectCinemaOffice(string cinemaName)
        {
            return new ManageAllDAL().selectCinemaOffice(cinemaName);
        }

        /// <summary>
        /// 更新电影
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SureUpdateMovie(MovieInfoModel model)
        {
            return new ManageAllDAL().SureUpdateMovie(model);
        }

        #endregion 电影管理
    }
}