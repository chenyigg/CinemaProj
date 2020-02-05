using BLL;
using Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        public bool lv;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.remember.Checked = true;
            //UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            //判断回发
            if (!IsPostBack)
            {
                var b = Response.Cookies;
                //if (Request.UrlReferrer != null)  //保存上一次访问地址
                //{
                //    Session["UrlReferrer"] = Request.UrlReferrer.ToString();
                //}
                if (Request.Cookies["UserAccount"] != null && Request.Cookies["UserPwd"] != null)
                {
                    this.login_number.Value = Server.UrlDecode(Request.Cookies["UserAccount"].Value);
                    this.login_password.Attributes.Add("value", Server.UrlDecode(Request.Cookies["UserPwd"].Value));
                    this.remember.Checked = true;
                }
            }

            if (Request["session"] != null)
            {
                if (Request["session"] == "clear")
                {
                    Session.Clear();
                }
            }

            //提交表单注册用户
            if (Request.Form["C_regist_account"] != null && Request.Form["C_regist_account"] != "" && Request.Form["C_regist_password1"] != null && Request.Form["C_regist_password1"] != "")
            {
                UsersInfoModel users = new UsersInfoModel();
                users.UserAccount = Request["C_regist_account"];
                users.UsersPwd = Request["C_regist_password1"];
                users.UserEmail = Request["C_regist_email"];
                int o = new LoginBLL().InsertIntoUser(users);
                if (o > 0)
                {
                    //保存状态
                    Session["UserAccount"] = users.UserAccount;
                    Session["UsersPwd"] = users.UsersPwd;

                    //跳转至首页
                    //if (Session["UrlReferrer"] != null)
                    //{
                    //    Response.Redirect(Session["UrlReferrer"].ToString());
                    //}
                    Response.Redirect("Default.aspx");
                }
            }
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void login_btn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (lv)
                {
                    Response.Redirect("MovieManage.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = LoginTorF();
        }

        protected bool LoginTorF()
        {
            string UserAccound = this.login_number.Value;
            string UserPwd = this.login_password.Text;

            if (!string.IsNullOrEmpty(UserAccound) && !string.IsNullOrEmpty(UserPwd))
            {
                UsersInfoModel UsersInfo = new UsersInfoModel();
                UsersInfo.UserAccount = UserAccound;
                UsersInfo.UsersPwd = UserPwd;

                //调用BLL层
                bool k = new LoginBLL().SelectUsersInfo(UsersInfo, out lv);

                //判断是否与数据库值相匹配
                if (k)
                {
                    //判断是否勾选了记住密码
                    if (this.remember.Checked)
                    {
                        //生成cookie对象并保存
                        HttpCookie CName = new HttpCookie("UserAccount", UserAccound);
                        HttpCookie CPwd = new HttpCookie("UserPwd", UserPwd);

                        //设置保存天数
                        CName.Expires = DateTime.Now.AddDays(1);
                        CPwd.Expires = DateTime.Now.AddDays(1);

                        Response.Cookies.Add(CName);
                        Response.Cookies.Add(CPwd);
                    }

                    //生成会话保存用户状态
                    Session["UserAccount"] = UserAccound;
                    Session["UserPwd"] = UserPwd;
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('账号密码不匹配！')</script>");

                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('账号密码不允许为空！')</script>");
                return false;
            }
        }
    }
}