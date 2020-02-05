using BLL;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class TopSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["Method"] != null)
            //{
            //    switch (Request["Method"])
            //    {
            //        case "search": search(); break;
            //    }
            //}
        }

        //private void search()
        //{
        //    List<MovieInfoModel> ls = new MovieInfoBLL().search(Request["MovieName"]);
        //    if (ls.Count > 0)
        //    {
        //        Response.Redirect($"Details.aspx?MovieID={ls[0].MovieID}");
        //    }
        //    else
        //    {
        //        Response.Write(JsonConvert.SerializeObject("no"));
        //        Response.End();
        //    }
        //}
    }
}