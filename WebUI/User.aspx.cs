using BLL;
using Models;
using System;
using System.IO;
using System.Web.UI;

namespace WebUI
{
    public partial class User : System.Web.UI.Page
    {
        public int UserID;
        public string UserName;
        public string UserSex;
        public string UserPhone;
        public string UserIDCard;
        public string UserAddress;
        public string UserFaces;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["UserName"] != null)
            {
                //进入判断，获取该用户是否资料已完善
                UsersInfoModel use = new UsersInfoModel();
                use.UserName = Request["UserName"];
                use.UserSex = Request["UserSex"];
                use.UserPhone = Request["UserPhone"];
                use.UserIDCard = Request["UserIDCard"];
                use.UserAddress = Request["UserAddress"];
                use.UserAccount = Session["UserAccount"].ToString();
                if (UploadImg())
                {
                    use.UserFace = this.FileUpload1.FileName;
                }
                int i = UpdataUsersInfo(use);
                AlertAndRedirect("更新成功", "#", this);
            }
            Bind();
        }

        public bool UploadImg()
        {
            if (this.FileUpload1.HasFile)
            {
                //获取文件名
                string fileName = FileUpload1.FileName;
                string fullPath = Path.GetFullPath(FileUpload1.PostedFile.FileName); //获取文件的绝对路径
                //获取后缀名
                string extension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                if (extension == "png" || extension == "jpg" || extension == "jpeg" || extension == "gif")
                {
                    this.FileUpload1.SaveAs(Server.MapPath("~/images/UserFaceImg/") + fileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void AlertAndRedirect(string message, string toURL, Page page)
        {
            #region
            string js = "<script language=javascript>$.alert('{0}');window.location.replace('{1}')</script>";

            page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndRedirect", string.Format(js, message, toURL));

            #endregion
        }

        private int UpdataUsersInfo(UsersInfoModel use)
        {
            return new UserBLL().UpdataUsersInfo(use);
        }

        private UsersInfoModel SelectUserInfoFromAccount(UsersInfoModel use)
        {
            return new UserBLL().SelectUserInfoFromAccount(use);
        }

        private void Bind()
        {
            //进入判断，获取该用户是否资料已完善
            UsersInfoModel uses = new UsersInfoModel();
            if (Session["UserAccount"] != null)
            {
                uses.UserAccount = Session["UserAccount"].ToString();
                uses = SelectUserInfoFromAccount(uses);

                //如果有值 ，则肯定是已经完善了数据，则将数据填充至控件
                if (!String.IsNullOrEmpty(uses.UserName))
                {
                    UserName = uses.UserName;
                    UserSex = uses.UserSex;
                    UserPhone = uses.UserPhone;
                    UserIDCard = uses.UserIDCard;
                    UserAddress = uses.UserAddress;

                    if (!String.IsNullOrEmpty(uses.UserFace))
                    {
                        UserFaces = "images/UserFaceImg/" + uses.UserFace;
                        serverImg.Src = UserFaces;
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }
    }
}