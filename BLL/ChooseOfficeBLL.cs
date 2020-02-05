using DAL;
using Model;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class ChooseOfficeBLL
    {
        /// <summary>
        /// 通过传入的影院ID找该影院所有信息
        /// </summary>
        /// <param name="om"></param>
        /// <returns></returns>
        public CinemaInfoModel FindOffice(CinemaInfoModel om)
        {
            return new ChooseOfficeDAL().FindOffice(om);
        }

        /// <summary>
        /// 通过传入的影片ID和影院ID找厅位放映详情
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<ShowDetails> FindOffice(MovieInfoModel mi, CinemaInfoModel om)
        {
            List<ShowDetails> sd = new ChooseOfficeDAL().FindShowDetails(mi, om);

            //根据地区来选定播放语言
            for (int i = 0; i < sd.Count; i++)
            {
                if (sd[i].Language != "大陆" && sd[i].Language != "中国香港" && sd[i].Language != "中国台湾")
                {
                    sd[i].Language = "英语";
                }
                else
                {
                    sd[i].Language = "国语";
                }

                //不同的影厅价格不一致
                switch (sd[i].OfficeName)
                {
                    case "杜比巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1);
                        break;

                    case "中国巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.8);
                        break;

                    case "激光2D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.3);
                        break;

                    case "激光3D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.6);
                        break;

                    case "IMAX厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1.5);
                        break;
                }
            }

            return sd;
        }

        /// <summary>
        /// 通过传入的影片ID和影院ID找该影院所有排片电影信息
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<MovieInfoModel> FindMovieInfo(MovieInfoModel mi, CinemaInfoModel om)
        {
            return new ChooseOfficeDAL().FindMovieInfo(mi, om);
        }

        /// <summary>
        /// 找明天
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<ShowDetails> FindTom(MovieInfoModel mi, CinemaInfoModel om)
        {
            List<ShowDetails> sd = new ChooseOfficeDAL().FindTom(mi, om);

            //根据地区来选定播放语言
            for (int i = 0; i < sd.Count; i++)
            {
                if (sd[i].Language != "大陆" && sd[i].Language != "中国香港" && sd[i].Language != "中国台湾")
                {
                    sd[i].Language = "英语";
                }
                else
                {
                    sd[i].Language = "国语";
                }

                //不同的影厅价格不一致
                switch (sd[i].OfficeName)
                {
                    case "杜比巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1);
                        break;

                    case "中国巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.8);
                        break;

                    case "激光2D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.3);
                        break;

                    case "激光3D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.6);
                        break;

                    case "IMAX厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1.5);
                        break;
                }
            }

            return sd;
        }

        /// <summary>
        /// 找今天
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="om"></param>
        /// <returns></returns>
        public List<ShowDetails> FindTod(MovieInfoModel mi, CinemaInfoModel om)
        {
            List<ShowDetails> sd = new ChooseOfficeDAL().FindTod(mi, om);

            //根据地区来选定播放语言
            for (int i = 0; i < sd.Count; i++)
            {
                if (sd[i].Language != "大陆" && sd[i].Language != "中国香港" && sd[i].Language != "中国台湾")
                {
                    sd[i].Language = "英语";
                }
                else
                {
                    sd[i].Language = "国语";
                }

                //不同的影厅价格不一致
                switch (sd[i].OfficeName)
                {
                    case "杜比巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1);
                        break;

                    case "中国巨幕厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.8);
                        break;

                    case "激光2D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.3);
                        break;

                    case "激光3D厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 0.6);
                        break;

                    case "IMAX厅":
                        sd[i].Money = sd[i].Money + (sd[i].Money * 1.5);
                        break;
                }
            }

            return sd;
        }
    }
}