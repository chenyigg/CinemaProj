using BLL;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class File : System.Web.UI.Page
    {
        public static int PageNow = 1;
        public int PageSize = 18;
        public static int PageNum = 0;
        public static int PageCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                switch (Request["Method"])
                {
                    case "loadMovieInfo":
                        loadMovieInfo();
                        break;

                    case "GetPageInfo":
                        GetPageInfo();
                        break;

                    case "FirstPageMovieInfo":
                        FirstPageMovieInfo();
                        break;

                    case "EndPageMovieInfo":
                        EndPageMovieInfo();
                        break;

                    case "PrevPageMovieInfo":
                        PrevPageMovieInfo();
                        break;

                    case "NextPageMovieInfo":
                        NextPageMovieInfo();
                        break;

                    case "jjsy":
                        jjsy();
                        break;

                    case "jddy":
                        jddy();
                        break;
                }
            }
        }

        private void jjsy()
        {
            List<MovieInfoModel> list = new FileBLL().SelectMovieInfo(1);
            var jsondata = JsonConvert.SerializeObject(list);
            Response.Write(jsondata);
            Response.End();
        }

        private void jddy()
        {
            List<MovieInfoModel> list = new FileBLL().SelectMovieInfo(1, 2);
            var jsondata = JsonConvert.SerializeObject(list);
            Response.Write(jsondata);
            Response.End();
        }

        private void GetPageInfo()
        {
            string str = "{\"PageNow\":" + PageNow + ",\"PageCount\":" + PageCount + "}";
            Response.Write(str);
            Response.End();
        }

        private void loadMovieInfo()
        {
            PageNum = 0;
            //记录返回的电影数量
            int Count;
            List<MovieInfoModel> list = new FileBLL().SelectPageMovieType(PageSize, PageNum, out Count,
                Request["MovieType"], Request["MovieArea"], Request["MovieYears"]);

            PageNow = list.Count > 0 ? 1 : 0;
            PageCount = (Count % PageSize) > 0 ? (Count / PageSize) + 1 : (Count / PageSize);

            var jsondata = JsonConvert.SerializeObject(list);
            Response.Write(jsondata);
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        private void FirstPageMovieInfo()
        {
            if (PageNow == 0) return;

            //回零，查询第一页（Top 0）
            PageNum = 0;

            int Count = 0;

            List<MovieInfoModel> ls = new FileBLL().SelectPageMovieInfo(PageSize, PageNum, out Count);

            PageCount = (Count % PageSize) > 0 ? (Count / PageSize) + 1 : Count / PageSize;
            PageNow = ls.Count > 0 ? 1 : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void EndPageMovieInfo()
        {
            if (PageNow == 0) return;
            PageNum = PageSize * (PageCount - 1);

            int Count = 0;

            List<MovieInfoModel> ls = new FileBLL().SelectPageMovieInfo(PageSize, PageNum, out Count);

            PageCount = (Count % PageSize) > 0 ? (Count / PageSize) + 1 : Count / PageSize;
            PageNow = ls.Count > 0 ? PageCount : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void PrevPageMovieInfo()
        {
            //如果没值或者已经是第一页，则直接返回
            if (PageNow == 0 || PageNow == 1) return;

            //不然的话就返回上一页
            PageNum -= PageSize;

            int Count = 0;

            List<MovieInfoModel> ls = new FileBLL().SelectPageMovieInfo(PageSize, PageNum, out Count);

            PageCount = (Count % PageSize) > 0 ? (Count / PageSize) + 1 : Count / PageSize;
            PageNow = ls.Count > 0 ? PageNow - 1 : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }

        private void NextPageMovieInfo()
        {
            //如果没值或者已经是最后一页，则直接返回
            if (PageNow == 0 || PageNow == PageCount) return;

            //不然的话就返回下一页
            PageNum += PageSize;

            int Count = 0;

            List<MovieInfoModel> ls = new FileBLL().SelectPageMovieInfo(PageSize, PageNum, out Count);

            PageCount = (Count % PageSize) > 0 ? (Count / PageSize) + 1 : Count / PageSize;
            PageNow = ls.Count > 0 ? PageNow + 1 : 0;

            var jsondata = JsonConvert.SerializeObject(ls);

            Response.Write(jsondata);
            Response.End();
        }
    }
}