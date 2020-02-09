using BLL;
using Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class ChooseOffice : System.Web.UI.Page
    {
        public CinemaInfoModel om;

        protected void Page_Load(object sender, EventArgs e)
        {
            //页面初始化
            if (!IsPostBack)
            {
                CinemaInfoModel oi = new CinemaInfoModel();
                oi.CinemaID = Convert.ToInt32(Request["CinemaID"]);
                om = new ChooseOfficeBLL().FindOffice(oi);

                if (!String.IsNullOrEmpty(Request["CinemaID"]) && !String.IsNullOrEmpty(Request["MovieID"]))
                {
                    //绑定电影封面
                    this.Repeater1.DataSource = new ChooseOfficeBLL().FindMovieInfo(new MovieInfoModel() { MovieID = Convert.ToInt32(Request["MovieID"]) }, oi);
                    this.Repeater1.DataBind();
                }
                if (!String.IsNullOrEmpty(Request["CinemaID"]) && String.IsNullOrEmpty(Request["MovieID"]))
                {
                    //绑定电影封面
                    this.Repeater1.DataSource = new ChooseOfficeBLL().FindMovieInfo(new MovieInfoModel() { MovieID = 0 }, oi);
                    this.Repeater1.DataBind();
                }
            }

            //前端传值加载界面
            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                switch (Request["Method"])
                {
                    case "FindOfficeInfo":
                        FindOfficeInfo();
                        break;

                    case "FindMovieInfo":
                        FindMovieInfo();
                        break;

                    case "FindTom":
                        FindTom();
                        break;

                    case "FindTod":
                        FindTod();
                        break;
                }
            }
        }

        private void FindTod()
        {
            string b = Request["MovieName"].ToString();
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieName = Request["MovieName"].ToString();
            CinemaInfoModel ci = new CinemaInfoModel();
            ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

            List<ShowDetails> sd = new ChooseOfficeBLL().FindTod(mi, ci);
            var jsondata = JsonConvert.SerializeObject(sd);
            Response.Write(jsondata);
            Response.End();
        }

        private void FindTom()
        {
            string b = Request["MovieName"].ToString();
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieName = Request["MovieName"].ToString();
            CinemaInfoModel ci = new CinemaInfoModel();
            ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

            List<ShowDetails> sd = new ChooseOfficeBLL().FindTom(mi, ci);
            var jsondata = JsonConvert.SerializeObject(sd);
            Response.Write(jsondata);
            Response.End();
        }

        private void FindMovieInfo()
        {
            //如果传入的影片ID和影院ID都不为空，
            //证明从电影界面点击进来
            if (!String.IsNullOrEmpty(Request["CinemaID"]) && !String.IsNullOrEmpty(Request["MovieID"]))
            {
                MovieInfoModel mi = new MovieInfoModel();
                mi.MovieID = Convert.ToInt32(Request["MovieID"]);
                CinemaInfoModel ci = new CinemaInfoModel();
                ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

                List<MovieInfoModel> sd = new ChooseOfficeBLL().FindMovieInfo(mi, ci);
                var jsondata = JsonConvert.SerializeObject(sd);
                Response.Write(jsondata);
                Response.End();
            }
            else
            {
                MovieInfoModel mi = new MovieInfoModel();
                mi.MovieID = 0;
                CinemaInfoModel ci = new CinemaInfoModel();
                ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

                List<MovieInfoModel> sd = new ChooseOfficeBLL().FindMovieInfo(mi, ci);
                var jsondata = JsonConvert.SerializeObject(sd);
                Response.Write(jsondata);
                Response.End();
            }
        }

        private void FindOfficeInfo()
        {
            //如果传入的影片ID和影院ID都不为空，
            //证明从电影界面点击进来
            if (!String.IsNullOrEmpty(Request["CinemaID"]) && !String.IsNullOrEmpty(Request["MovieID"]))
            {
                MovieInfoModel mi = new MovieInfoModel();
                mi.MovieID = Convert.ToInt32(Request["MovieID"]);
                CinemaInfoModel ci = new CinemaInfoModel();
                ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

                List<ShowDetails> sd = new ChooseOfficeBLL().FindOffice(mi, ci);
                var jsondata = JsonConvert.SerializeObject(sd);
                Response.Write(jsondata);
                Response.End();
            }
            else
            {
                MovieInfoModel mi = new MovieInfoModel();
                mi.MovieID = 0;
                CinemaInfoModel ci = new CinemaInfoModel();
                ci.CinemaID = Convert.ToInt32(Request["CinemaID"]);

                List<ShowDetails> sd = new ChooseOfficeBLL().FindOffice(mi, ci);
                var jsondata = JsonConvert.SerializeObject(sd);
                Response.Write(jsondata);
                Response.End();
            }
        }
    }
}