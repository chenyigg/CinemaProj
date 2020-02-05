using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL;

namespace WebUI
{
    public partial class UrlMsgInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int k = new UrlMsgInfoBLL().Update();
        }
    }
}