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
    public partial class MovieManage : System.Web.UI.Page
    {
        public static string datetimeSql = "";
        public MovieInfoModel model = new MovieInfoModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<MovieInfoModel> list = new ManageAllBLL().SelectMovieInfo();
                //绑定删除界面的下拉框
                this.DropDownList1.DataSource = list;
                this.DropDownList1.DataValueField = "MovieID";
                this.DropDownList1.DataTextField = "MovieName";
                this.DropDownList1.DataBind();
                //绑定修改界面的下拉框
                this.DropDownList2.DataSource = list;
                this.DropDownList2.DataValueField = "MovieID";
                this.DropDownList2.DataTextField = "MovieName";
                this.DropDownList2.DataBind();
                model = list[0];
                datetimeSql = model.MovieReleaseDate.ToString().Substring(0, model.MovieReleaseDate.ToString().IndexOf(" ") - 1);
            }
            if (Request["Method"] == "updateMovie")
            {
                updateMovie();
            }

            if (Request["Method"] == "SureUpdate")
            {
                SureUpdate();
            }

            if (Request["Method"] == "selectMovie")
            {
                selectMovie(Request["textbox"]);
            }
        }

        private void selectMovie(string textbox)
        {
            List<MovieInfoModel> list = new List<MovieInfoModel>();
            if (textbox == "")
            {
                list = new ManageAllBLL().SelectMovieInfo();
            }
            else
            {
                list = new ManageAllBLL().SelectMovieInfo(textbox);
            }

            var jsonstr = JsonConvert.SerializeObject(list);
            Response.Write(jsonstr);
            Response.End();
        }

        private void SureUpdate()
        {
            MovieInfoModel model = new MovieInfoModel();
            model.MovieName = Request["MovieName"];
            model.MovieCover = Request["MovieCover"];
            model.MovieBrief = Request["MovieBrief"];
            model.MovieMoney = Convert.ToDouble(Request["MovieMoney"]);
            model.MovieDuration = Convert.ToInt32(Request["MovieDuration"]);
            model.MovieDirect = Request["MovieDirect"];
            model.MovieType = Request["MovieType"];
            model.MovieArea = Request["MovieArea"];
            model.MovieYears = Convert.ToInt32(Request["MovieYears"]);
            model.MovieScore = Convert.ToDecimal(Request["MovieScore"]);
            model.MoviePeople = Request["MoviePeople"];
            int a = new ManageAllBLL().SureUpdateMovie(model);
            if (a > 0)
            {
                Response.Write(1);
                Response.End();
            }
            else
            {
                Response.Write(0);
                Response.End();
            }
        }

        private void updateMovie()
        {
            string selectMovie = Request["selectMovie"].ToString();
            List<MovieInfoModel> list = new ManageAllBLL().SelectMovieInfo();
            MovieInfoModel newModel = new MovieInfoModel();
            //找到指定电影的数据
            foreach (var item in list)
            {
                if (item.MovieName == selectMovie)
                {
                    newModel = item;
                    break;
                }
            }

            Response.Write(JsonConvert.SerializeObject(newModel));
            Response.End();
        }

        protected void addBtn_ServerClick(object sender, EventArgs e)
        {
            //将图片文件拷贝到制定目录
            if (this.FileUpload1.HasFile)
            {
                string filename = this.FileUpload1.FileName;
                string fileFix = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();
                if (fileFix == "png" || fileFix == "jpg" || fileFix == "jpeg" || fileFix == "gif")
                {
                    FileUpload1.SaveAs(Server.MapPath("~/images/MovieCover/") + filename);
                }
            }
            else
            {
                Response.Write("<script>alert('请插入图片!')</script>");
                return;
            }
            try
            {
                //将电影插入到数据库
                MovieInfoModel model = new MovieInfoModel();
                model.MovieName = Request["MovieName"].ToString();
                model.MovieCover = this.FileUpload1.FileName;
                model.MovieBrief = Request["MovieBrief"].ToString();
                model.MovieMoney = Convert.ToDouble(Request["MovieMoney"]);
                model.MovieReleaseDate = Convert.ToDateTime(Request["MovieReleaseDate"]);
                model.MovieDuration = Convert.ToInt32(Request["MovieDuration"]);
                model.MovieDirect = Request["MovieDirect"].ToString();
                model.MovieType = Request["MovieType"].ToString();
                model.MovieArea = Request["MovieArea"].ToString();
                model.MovieYears = Convert.ToInt32(Request["MovieYears"]);
                model.MovieScore = Convert.ToDecimal(Request["MovieScore"]);
                model.MoviePeople = Request["MoviePeople"].ToString();
                int a = new ManageAllBLL().InsertMovie(model);
            }
            catch
            {
                Response.Write("<script>alert('请输入完整电影信息!')</script>");
            }
        }

        protected void deleteMovie_ServerClick1(object sender, EventArgs e)
        {
            string deleteMovieName = this.DropDownList1.SelectedItem.Text.ToString();
            int a = new ManageAllBLL().DeleteMovie(deleteMovieName);
            if (a == 1)
            {
                Response.Write("<script>alert('删除成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }
    }
}