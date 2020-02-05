using BLL;
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
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (Request["Method"] != null)
            {
                switch (Request["Method"])
                {
                    case "HasPwd":
                        HasPwd();
                        break;
                }
            }
            if (!String.IsNullOrEmpty(Request["New"]))
            {
                UpdatePwd();
            }
        }

        private void UpdatePwd()
        {
            UsersInfoModel use = new UsersInfoModel()
            {
                UserAccount = Session["UserAccount"].ToString(),
                UsersPwd = Request["New"]
            };

            int b = new ChangePwdBLL().UpdatePwd(use);

            if (b > 0)
            {
                Response.Write("<script>alert('更改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('更改失败！')</script>");
            }
        }

        private void HasPwd()
        {
            UsersInfoModel use = new UsersInfoModel()
            {
                UserAccount = Session["UserAccount"].ToString(),
                UsersPwd = Request["UserPwd"]
            };

            use = new ChangePwdBLL().HasPwd(use);

            if (String.IsNullOrEmpty(use.UserAccount))
            {
                Response.Write("{\"state\":\"no\"}");
                Response.End();
            }
            else
            {
                Response.Write("{\"state\":\"ok\"}");
                Response.End();
            }
        }
    }
}