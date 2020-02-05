using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class CinemaBLL
    {
        /// <summary>
        /// 返回厅名
        /// </summary>
        /// <returns></returns>
        public List<OfficeInfoModel> FindOfficeName()
        {
            return new CinemaDAL().FindOfficeName();
        }

        /// <summary>
        /// 返回影院
        /// </summary>
        /// <returns></returns>
        public List<CinemaInfoModel> FindCinema()
        {
            return new CinemaDAL().FindCinema();
        }

        public List<CinemaInfoModel> Filtrate(string CinemaArea, string OfficeName)
        {
            if (CinemaArea == "全部")
            {
                CinemaArea = "";
            }
            if (OfficeName == "全部")
            {
                OfficeName = "";
            }
            return new CinemaDAL().Filtrate(CinemaArea, OfficeName);
        }
    }
}