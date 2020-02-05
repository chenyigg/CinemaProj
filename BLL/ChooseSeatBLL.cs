using Model;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ChooseSeatBLL
    {
        /// <summary>
        /// 按照厅位加载所有的座位
        /// </summary>
        /// <param name="office"></param>
        /// <returns>List<SeatInfoModel></returns>
        public List<SeatInfoModel> loadSeatInfo(string office, string chipID)
        {
            return new ChooseSeatDAL().loadSeatInfo(office, chipID);
        }

        /// <summary>
        /// 插入购买的所有座位
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public int insertSeat(string[] strArray, string chipID)
        {
            return new ChooseSeatDAL().insertSeat(strArray, chipID);
        }

        /// <summary>
        /// 查询所有电影
        /// </summary>
        /// <param name="ChipInfoID"></param>
        /// <returns></returns>
        public List<MovieInfoModel> selectMovie(string ChipInfoID)
        {
            return new ChooseSeatDAL().selectMovie(ChipInfoID);
        }

        /// <summary>
        /// 查询厅位名
        /// </summary>
        /// <param name="ChipInfoID"></param>
        /// <returns></returns>
        public List<OfficeInfoModel> selectOfficeName(string ChipInfoID)
        {
            return new ChooseSeatDAL().selectOfficeName(ChipInfoID);
        }

        /// <summary>
        /// 查询影院名
        /// </summary>
        /// <param name="chipInfoID"></param>
        /// <returns></returns>
        public List<CinemaInfoModel> selectCinemaName(string chipInfoID)
        {
            return new ChooseSeatDAL().selectCinemaName(chipInfoID);
        }

        public int insertOrder(OrderInfoModel orderInfoModel, out string orderID)
        {
            return new ChooseSeatDAL().insertOrder(orderInfoModel, out orderID);
        }

        /// <summary>
        /// 通过账号去找到用户id
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int selectUsersID(string userName)
        {
            return new ChooseSeatDAL().selectUsersID(userName);
        }

        public int insertOrderDetails(OrderDetailsModel orderDetailsModel, string[] strArray, string chipID)
        {
            return new ChooseSeatDAL().insertOrderDetails(orderDetailsModel, strArray, chipID);
        }
    }
}