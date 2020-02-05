﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="OrderPay.aspx.cs" Inherits="WebUI.OrderPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/OrderPayCss/zhifu.css">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/vue.js"></script>
    <script src="Scripts/OrderPayJs/OrderPay.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="all">

        <section id="content" class="row">
            <div class="content--item__jindutiao">
                <img src="images/MovieImg/进度条.JPG" alt="">
            </div>
            <div class="content--item__shalou row">
                <span class="col-1 ion-android-pin content--item__shalou-span"></span>
                <ul class="col-11 content--item__shalou-ul">
                    <%int Mint = oh.PayTime / 60;
                        int Sild = oh.PayTime % 60;%>
                    <li>请在&nbsp;<span id="Mint"><%=Mint %></span>&nbsp;分钟&nbsp;<span id="Sild"><%=Sild %></span>&nbsp;秒内完成支付</li>
                    <li>超时将自动取消订单！</li>
                </ul>
            </div>
            <p style="width: 100%;"><span class="ion-android-pin" style="color: orange;"></span>&nbsp;请仔细核对场次信息，出票后将无法退票和改签</p>
            <table class="content--item__table">
                <tr style="background-color: #f7f7f7;">
                    <td>影片</td>
                    <td>时间</td>
                    <td>影院</td>
                    <td>座位</td>
                </tr>
                <tr>
                    <td id="Chip" chip="<%=oh.ChipInfoID %>"><%=oh.MovieName %></td>
                    <td id="OrderID" order="<%=oh.OrderID %>" style="color: rgb(204, 25, 25);"><%=oh.OrderTime %></td>
                    <td><%=oh.CinemaName %></td>
                    <td>
                        <span><%=oh.OfficeName %></span>&nbsp;&nbsp;
                    <span>
                        <%for (int i = 0; i < oh.SeatSum.Length; i++)
                            {
                                Response.Write($"<span class='content--item__shalou-table__span'>{oh.SeatSum[i]}</span>&nbsp;&nbsp;|&nbsp;&nbsp;");
                            } %>
                    </span>
                    </td>
                </tr>
            </table>
            <div class="content--item__zhifu row">
                <div class="col-9"></div>
                <div class="col-3">
                    <div class="content--item__zhifu--div">
                        实际支付：&nbsp;
                    <span style="font-size: 2em;">&yen;</span>
                        <span style="font-size: 3.5em;"><%=oh.OrderSumMoney %></span>
                    </div>
                    <span class="content--item__zhifu--span"><a href="javascript:0" id="Confirm">确认支付</a></span>
                </div>
            </div>
        </section>
    </div>
</asp:Content>