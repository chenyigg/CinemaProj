using BLL;
using Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class ChipManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Method"] != null)
            {
                switch (Request["Method"])
                {
                    case "addChipLoadCinema": addChipLoadCinema(); break;
                    case "addChipLoadMovie": addChipLoadMovie(); break;
                    case "addChipLoadCinemaChange": addChipLoadCinemaChange(Request["CinemaName"]); break;
                    case "sureChip":
                        sureChip(Request["CinemaName"], Request["OfficeName"], Request["MovieName"], Convert.ToDateTime(Request["Time"]));
                        break;
                }
            }
        }

        /// <summary>
        /// 排片方法
        /// </summary>
        /// <param name="CinemaName"></param>
        /// <param name="OfficeName"></param>
        /// <param name="MovieName"></param>
        /// <param name="Time"></param>
        private void sureChip(string CinemaName, string OfficeName, string MovieName, DateTime Time)
        {
            int a = new ManageAllBLL().sureChip(CinemaName.Replace("\n", "").Trim(), OfficeName.Replace("\n", "").Trim(), MovieName.Replace("\n", "").Trim(), Time);
            if (a > 1)
            {
                Response.Write("1");
                Response.End();
            }
            else
            {
                Response.Write("0");
                Response.End();
            }
        }

        /// <summary>
        /// 加载所有的电影
        /// </summary>
        private void addChipLoadMovie()
        {
            List<MovieInfoModel> list = new List<MovieInfoModel>();
            list = new ManageAllBLL().selectAllMovie();
            var json = JsonConvert.SerializeObject(list);
            Response.Write(json);
            Response.End();
        }

        /// <summary>
        /// 加载所有影院
        /// </summary>
        private void addChipLoadCinema()
        {
            List<CinemaInfoModel> list = new List<CinemaInfoModel>();
            list = new ManageAllBLL().selectAllCinema();
            var json = JsonConvert.SerializeObject(list);
            Response.Write(json);
            Response.End();
        }

        /// <summary>
        /// 影院值改变
        /// </summary>
        private void addChipLoadCinemaChange(string CinemaName)
        {
            List<OfficeInfoModel> list = new List<OfficeInfoModel>();
            list = new ManageAllBLL().selectCinemaOffice(CinemaName.Trim());
            var json = JsonConvert.SerializeObject(list);
            Response.Write(json);
            Response.End();
        }
    }
}