using BLL;
using Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    internal class state
    {
        public string State { get; set; }
        public int MovieID { get; set; }
    }

    public partial class Default : System.Web.UI.Page
    {
        public int IsHot; //正在热映
        public int NoUp;
        public int Score;

        //票房变量

        public int M_MovieID;
        public string M_MovieName;
        public string M_MovieCover;
        public string M_SumMoney;
        public string M_MovieArea;
        public string M_MovieType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //生成正在热映电影信息
                SelectMovieInfo();

                //生成今日票房信息
                SelectMovieMoneyTop();

                //生成最受期待
                SelectScoreMovieInfo();

                //生成经典Top
                SelectMovieInfos();

                //轮播图片加载
                lunboImgLoad();
            }
            //判断是否是登录
            if (Session["UserAccount"] == null || Session["UserAccount"].ToString() == "" || Session["UserPwd"] == null || Session["UserPwd"].ToString() == "")
            {
            }
            if (Request["Method"] == "LoginName")
            {
                LoginName();
            }
            if (Request["Method"] == "HasFace")
            {
                HasFace();
            }
            if (Request["Method"] == "search")
            {
                search();
            }
        }

        private void search()
        {
            List<MovieInfoModel> ls = new MovieInfoBLL().search(Request["MovieName"]);
            if (ls.Count > 0)
            {
                state model = new state();
                model.MovieID = ls[0].MovieID;
                model.State = "ok";

                Response.Write(JsonConvert.SerializeObject(model));
                Response.End();
            }
            else
            {
                state model = new state();
                model.MovieID = 0;
                model.State = "no";

                Response.Write(JsonConvert.SerializeObject(model));
                Response.End();
            }
        }

        private void lunboImgLoad()
        {
            List<MovieInfoModel> list = new List<MovieInfoModel>();
            list = new MovieInfoBLL().SelectMovieInfo(1);
            this.Repeater7.DataSource = list;
            this.Repeater7.DataBind();
        }

        private void SelectMovieInfos()
        {
            List<MovieInfoModel> ls = new MovieInfoBLL().SelectMovieInfo();
            if (ls.Count > 0)
            {
                M_MovieID = ls[0].MovieID;
                M_MovieName = ls[0].MovieName;
                M_MovieCover = ls[0].MovieCover;
                M_MovieArea = ls[0].MovieArea;

                //移出首个
                ls.RemoveAt(0);

                this.Repeater6.DataSource = ls;
                this.Repeater6.DataBind();
            }
        }

        private void SelectScoreMovieInfo()
        {
            List<MovieInfoModel> ls = new MovieInfoBLL().SelectScoreMovieInfo();
            if (ls.Count > 0)
            {
                M_MovieID = ls[0].MovieID;
                M_MovieName = ls[0].MovieName;
                M_MovieCover = ls[0].MovieCover;
                M_MovieType = ls[0].MovieType;

                //移出首个
                ls.RemoveAt(0);

                this.Repeater5.DataSource = ls;
                this.Repeater5.DataBind();
            }
        }

        private void SelectMovieMoneyTop()
        {
            List<MovieMoneyTopModel> ls = new MovieInfoBLL().SelectMovieMoneyTopModel();
            if (ls.Count > 0)
            {
                M_MovieID = ls[0].MovieID;
                M_MovieName = ls[0].MovieName;
                M_MovieCover = ls[0].MovieCover;
                M_SumMoney = ls[0].SumMoney;

                //移出首个
                ls.RemoveAt(0);

                this.Repeater4.DataSource = ls;
                this.Repeater4.DataBind();
            }
        }

        private void HasFace()
        {
            if (Session["UserAccount"] == null || Session["UserAccount"].ToString() == "" || Session["UserPwd"] == null || Session["UserPwd"].ToString() == "")
            {
                string data = "{\"State\":\"no\"}";//无序序列化直接使用
                                                   //string str = "[{\"State\":\"libai\"},{\"name\":\"dufu\"}]";//无序序列化直接使用
                                                   //string data = "{State:no}";(不行)
                                                   //这里包含一个Stu类的对象（需要序列化）
                                                   //Stu stuInfo = new Stu() { StuID = 1, StuInfo = "东方曜" };
                                                   //var jsondata = JsonConvert.SerializeObject(stuInfo);
                Response.Write(data);
            }
            else
            {
                UsersInfoModel User = new UsersInfoModel();
                User.UserAccount = Session["UserAccount"].ToString();
                User = new UserBLL().SelectUserInfoFromAccount(User);
                string data = "{" + $"\"State\":\"ok\",\"UserFace\":\"{User.UserFace}\"" + "}";
                Response.Write(data);
            }
            Response.End();
        }

        private void LoginName()
        {
            if (Session["UserAccount"] == null || Session["UserAccount"].ToString() == "" || Session["UserPwd"] == null || Session["UserPwd"].ToString() == "")
            {
                string data = "{\"State\":\"no\"}";//无序序列化直接使用
                                                   //string str = "[{\"State\":\"libai\"},{\"name\":\"dufu\"}]";//无序序列化直接使用
                                                   //string data = "{State:no}";(不行)
                                                   //这里包含一个Stu类的对象（需要序列化）
                                                   //Stu stuInfo = new Stu() { StuID = 1, StuInfo = "东方曜" };
                                                   //var jsondata = JsonConvert.SerializeObject(stuInfo);
                Response.Write(data);
            }
            else
            {
                string data = "{\"State\":\"ok\"}";
                Response.Write(data);
            }
            Response.End();
        }

        private void SelectMovieInfo()
        {
            List<MovieInfoModel> ls1 = new MovieInfoBLL().SelectMovieInfo();
            List<MovieInfoModel> ls2 = new MovieInfoBLL().SelectNoUpMovieInfo();
            List<MovieInfoModel> ls3 = new MovieInfoBLL().SelectScoreMovieInfo();
            IsHot = ls1.Count;
            NoUp = ls2.Count;
            Score = ls3.Count;
            this.Repeater1.DataSource = ls1;
            this.Repeater1.DataBind();
            this.Repeater2.DataSource = ls2;
            this.Repeater2.DataBind();
            this.Repeater3.DataSource = ls3;
            this.Repeater3.DataBind();
        }
    }
}