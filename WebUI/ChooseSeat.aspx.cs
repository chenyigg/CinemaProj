using BLL;
using Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebUI
{
    public partial class ChooseSeat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                //加载座位方法
                if (Request["Method"] == "loadSeatInfo")
                {
                    loadSeatInfo(Request["OfficeID"].ToString(), Request["ChipInfoID"].ToString());
                }
            }
            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                //确定选座方法
                if (Request["Method"] == "sureChooseSeat")
                {
                    string[] strArray = Request["SeatIDarray"].Replace("[", string.Empty).Replace("]", string.Empty).Split(',');
                    string pp = Request["chipInfoID"];
                    sureChooseSeat(strArray, Request["ChipInfoID"].ToString(), Request["officeID"].ToString(), Request["Money"].ToString());
                }
            }

            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                //加载电影方法
                if (Request["Method"] == "loadMovieInfo")
                {
                    loadMovieInfo(Request["ChipInfoID"].ToString());
                }
            }

            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                //加载厅名方法
                if (Request["Method"] == "loadOffice")
                {
                    loadOffice(Request["ChipInfoID"].ToString());
                }
            }

            if (!String.IsNullOrEmpty(Request["Method"]))
            {
                //加载电影名方法
                if (Request["Method"] == "loadCinema")
                {
                    loadCinema(Request["ChipInfoID"].ToString());
                }
            }
        }

        private void loadCinema(string ChipInfoID)
        {
            //找到影院名
            List<CinemaInfoModel> cinemaModel = new List<CinemaInfoModel>();
            cinemaModel = new ChooseSeatBLL().selectCinemaName(ChipInfoID);
            CinemaInfoModel cinemaModela = cinemaModel[0];
            var jsonList = JsonConvert.SerializeObject(cinemaModela);
            Response.Write(jsonList);
            Response.End();
        }

        private void loadOffice(string ChipInfoID)
        {
            //找到厅名
            List<OfficeInfoModel> officeModel = new List<OfficeInfoModel>();
            officeModel = new ChooseSeatBLL().selectOfficeName(ChipInfoID);
            OfficeInfoModel officeModela = officeModel[0];
            var jsonList = JsonConvert.SerializeObject(officeModela);
            Response.Write(jsonList);
            Response.End();
        }

        private void loadMovieInfo(string ChipInfoID)
        {
            //找到电影对应的电影信息
            List<MovieInfoModel> list = new List<MovieInfoModel>();
            list = new ChooseSeatBLL().selectMovie(ChipInfoID);
            MovieInfoModel model = list[0];
            var jsonList = JsonConvert.SerializeObject(model);
            Response.Write(jsonList);
            Response.End();
        }

        private void sureChooseSeat(string[] strArray, string chipID, string officeID, string money)
        {
            //确定选座方法
            int a = new ChooseSeatBLL().insertSeat(strArray, chipID);

            //生成订单方法
            string orderID = "";
            OrderInfoModel orderInfoModel = new OrderInfoModel();
            orderInfoModel.OrderSumMoney = Convert.ToDecimal((strArray.Length * Convert.ToDouble(Request["Money"])));
            orderInfoModel.IsPay = 0;
            orderInfoModel.PayTime = 900;
            orderInfoModel.OfficeID = Convert.ToInt32(officeID);
            orderInfoModel.UsersID = new ChooseSeatBLL().selectUsersID(Session["UserAccount"].ToString());
            orderInfoModel.ChipInfoID = Convert.ToInt32(chipID);
            orderInfoModel.MovieName = (new ChooseSeatBLL().selectMovie(Request["ChipInfoID"].ToString()))[0].MovieName;
            orderInfoModel.CinemaAddress = (new ChooseSeatBLL().selectCinemaName(Request["ChipInfoID"].ToString()))[0].CinemaAddress;
            int b = new ChooseSeatBLL().insertOrder(orderInfoModel, out orderID);

            //生成订单详情方法
            OrderDetailsModel orderDetailsModel = new OrderDetailsModel();
            orderDetailsModel.OrderID = Convert.ToInt32(orderID);
            orderDetailsModel.OrderDetailsPrice = Double.Parse(money);
            int c = new ChooseSeatBLL().insertOrderDetails(orderDetailsModel, strArray, chipID);
            //判断座位表，订单表，订单详情表是否都插入成功！
            if (c == 1 && b == 1 && a == 1)
            {
                Response.Write("{\"OrderID\":\"" + orderID + "\"}");
                Response.End();
            }
            else
            {
            }
        }

        /// <summary>
        /// 查询对应影院对应厅位对应的座位结构
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="office"></param>
        private void loadSeatInfo(string office, string chipID)
        {
            List<SeatInfoModel> list = new ChooseSeatBLL().loadSeatInfo(office, chipID);
            var jsonList = JsonConvert.SerializeObject(list);
            Response.Write(jsonList);
            Response.End();
        }
    }
}