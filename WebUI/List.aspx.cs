using BLL;
using Models;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class Cinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MovieInfoModel> li = new ListBLL().SelectMovieInfo();
            this.Repeater1.DataSource = li;
            this.Repeater1.DataBind();

            List<MovieInfoModel> li2 = new ListBLL().SelectMovieInfo2();
            this.Repeater2.DataSource = li2;
            this.Repeater2.DataBind();

            List<MovieInfoModel> li3 = new ListBLL().SelectMovieInfo3();
            this.Repeater3.DataSource = li3;
            this.Repeater3.DataBind();

            List<MovieInfoModel> li4 = new ListBLL().SelectMovieInfo4();
            this.Repeater4.DataSource = li4;
            this.Repeater4.DataBind();

        }
    }
}