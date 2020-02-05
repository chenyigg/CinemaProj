using BLL;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class Cinema234 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                switch (Request["Method"])
                {
                    case "FindOfficeName":
                        FindOfficeName();
                        break;

                    case "FindCinema":
                        FindCinema();
                        break;

                    case "Filtrate":
                        Filtrate();
                        break;
                }
            }
        }

        //筛选
        private void Filtrate()
        {
            List<CinemaInfoModel> ls = new CinemaBLL().Filtrate(Request["CinemaArea"].Replace("\n", "").Replace("\t", ""), Request["OfficeName"].Replace("\n", "").Replace("\t", ""));
            var jsondata = JsonConvert.SerializeObject(ls);
            Response.Write(jsondata);
            Response.End();
        }

        //查找厅名
        private void FindOfficeName()
        {
            List<OfficeInfoModel> ls = new CinemaBLL().FindOfficeName();
            var jsondata = JsonConvert.SerializeObject(ls);
            Response.Write(jsondata);
            Response.End();
        }

        //查找电影院
        private void FindCinema()
        {
            List<CinemaInfoModel> ls = new CinemaBLL().FindCinema();
            var jsondata = JsonConvert.SerializeObject(ls);
            Response.Write(jsondata);
            Response.End();
        }
    }
}