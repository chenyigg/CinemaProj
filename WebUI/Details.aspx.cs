using BLL;
using Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class Details : System.Web.UI.Page
    {
        public static int pageNow; //当前页
        public static int pageCount; //页面数
        public int pageSize = 5; //页面需要摆放的数量
        public static int pageNum = 0;//页面翻页的变量

        //电影信息
        public MovieInfoModel mz = new MovieInfoModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (Session["UserAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Request["MovieID"] != null)
            {
                SelectMovieInfo();
                //SelectCommentInfo();
            }

            switch (Request["Method"])
            {
                case "SelectCommentInfo":
                    SelectCommentInfo();
                    break;

                case "BtnSayClick":
                    BtnSayClick();
                    break;

                case "GetPageInfo":
                    GetPageInfo();
                    break;

                case "FirstCommentInfo":
                    FirstCommentInfo();
                    break;

                case "EndCommentInfo":
                    EndCommentInfo();
                    break;

                case "PrevCommentInfo":
                    PrevCommentInfo();
                    break;

                case "NextCommentInfo":
                    NextCommentInfo();
                    break;
            }
        }

        private void GetPageInfo()
        {
            string str = "{\"PageNow\":" + pageNow + ",\"PageCount\":" + pageCount + "}";
            Response.Write(str);
            Response.End();
        }

        /// <summary>
        /// 电影详情
        /// </summary>
        private void SelectMovieInfo()
        {
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);
            mz = new DetailsBLL().SelectMovieInfo(mi);
        }

        /// <summary>
        /// 电影评论
        /// </summary>
        private void SelectCommentInfo()
        {
            int Count = 0;
            //每次查询时将要页面翻页的变量重置
            pageNum = 0;
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);

            List<CommentModel> ls = new DetailsBLL().SelectCommentInfo(mi, pageSize, pageNum, out Count);

            pageNow = ls.Count > 0 ? 1 : 0;
            pageCount = (Count % pageSize) > 0 ? (Count / pageSize) + 1 : Count / pageSize;

            var json = JsonConvert.SerializeObject(ls);
            Response.Write(json);
            Response.End();
        }

        /// <summary>
        /// 发表评论
        /// </summary>
        private void BtnSayClick()
        {
            //先获取当前用户信息
            UsersInfoModel use = new UsersInfoModel();
            use.UserAccount = Session["UserAccount"].ToString();
            use = new UserBLL().SelectUserInfoFromAccount(use);

            //进行插入
            CommentModel cm = new CommentModel(Convert.ToInt32(Request["MovieID"]), use.UsersID, use.UserName, use.UserFace, Request["CommentInfo"].ToString(), Convert.ToDateTime(Request["CommentTime"]));
            int i = new DetailsBLL().InsertCommentInfo(cm);
            if (i == 0)
            {
                string str = "\"state\":\"false\"";
                Response.Write(str);
                Response.End();
            }
            else
            {
                SelectCommentInfo();
            }
        }

        private void FirstCommentInfo()
        {
            if (pageNow == 0) return;
            pageNum = 0;

            int Count = 0;
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);

            List<CommentModel> ls = new DetailsBLL().SelectCommentInfo(mi, pageSize, pageNum, out Count);

            pageCount = (Count % pageSize) > 0 ? (Count / pageSize) + 1 : Count / pageSize;
            pageNow = ls.Count > 0 ? 1 : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void EndCommentInfo()
        {
            if (pageNow == 0) return;
            pageNum = pageSize * (pageCount - 1);

            int Count = 0;
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);

            List<CommentModel> ls = new DetailsBLL().SelectCommentInfo(mi, pageSize, pageNum, out Count);

            pageCount = (Count % pageSize) > 0 ? (Count / pageSize) + 1 : Count / pageSize;
            pageNow = ls.Count > 0 ? pageCount : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void PrevCommentInfo()
        {
            //如果没值或者已经是第一页，则直接返回
            if (pageNow == 0 || pageNow == 1) return;

            //不然的话就返回上一页
            pageNum -= pageSize;

            int Count = 0;
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);

            List<CommentModel> ls = new DetailsBLL().SelectCommentInfo(mi, pageSize, pageNum, out Count);

            pageNow = ls.Count > 0 ? pageNow -= 1 : 0;
            pageCount = (Count % pageSize) > 0 ? (Count / pageSize) + 1 : Count / pageSize;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void NextCommentInfo()
        {
            //如果没值或者已经是最后一页，则直接返回
            if (pageNow == 0 || pageNow == pageCount) return;

            //不然的话就返回上一页
            pageNum += pageSize;

            int Count = 0;
            MovieInfoModel mi = new MovieInfoModel();
            mi.MovieID = Convert.ToInt32(Request["MovieID"]);

            List<CommentModel> ls = new DetailsBLL().SelectCommentInfo(mi, pageSize, pageNum, out Count);

            pageNow = ls.Count > 0 ? pageNow += 1 : 0;
            pageCount = (Count % pageSize) > 0 ? (Count / pageSize) + 1 : Count / pageSize;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }
    }
}