using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            this.Repeater1.DataSource = new OrderDetailsBLL().LoadInfo(Session["UserAccount"].ToString());
            this.Repeater1.DataBind();
        }
    }
}