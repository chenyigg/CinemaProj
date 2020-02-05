using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class ChooseCinemaBLL
    {
        /// <summary>
        /// 查询该电影信息
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public MovieInfoModel SelectMovieInfo(MovieInfoModel mi)
        {
            return new ChooseCinemaDAL().SelectMovieInfo(mi);
        }

        /// <summary>
        /// 查询所有正在放映此电影的影院
        ///  //--查询正在放映此电影的所有电影
            //--电影还未开始播放
        /// </summary>
        /// <param name="model"></param>
        /// <returns> List<CinemaInfoModel></returns>
        public List<CinemaInfoModel> chooseCinema(MovieInfoModel model)
        {
            return new ChooseCinemaDAL().chooseCinema(model);
        }
    }
}