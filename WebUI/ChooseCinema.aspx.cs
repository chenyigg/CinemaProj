using BLL;
using Models;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class Cinema1 : System.Web.UI.Page
    {
        public MovieInfoModel mv = new MovieInfoModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["MovieID"]))
            {
                SelectMovieInfo();
            }

            //接受传过来的电影id
            var MovieID = Convert.ToInt32(Request["MovieID"]);
            //找到所有正在播放此电影的影院
            List<CinemaInfoModel> list = new List<CinemaInfoModel>();
            MovieInfoModel model = new MovieInfoModel();
            model.MovieID = MovieID;
            list = new ChooseCinemaBLL().chooseCinema(model);
            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();
        }

        private void SelectMovieInfo()
        {
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);
            mv = new ChooseCinemaBLL().SelectMovieInfo(mi);
        }
    }
}