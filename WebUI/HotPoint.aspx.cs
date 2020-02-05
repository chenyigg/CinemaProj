using BLL;
using Models;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class HotPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<NewsInfoModel> list = new HotPointBLL().selectNews();
            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();
        }
    }
}