<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="WebUI.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/OrderDetailsCss/dianyingxiangqing.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" class="row" style="height: 100%">
        <div class="content--left col-2">
            <div class="content--left__div">个人中心</div>
            <ul>
                <li class="content--left__ul--li content--left--active">我的订单</li>
            </ul>
        </div>
        <div class="content--right col-10" style="height: 100%">
            <div class="content--right__top">
                我的订单
            </div>
            <div class="content--right__bottom">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="content--right__bottom--item">
                            <div class="content--right__bottom--item__top row">
                                <span class="col-3" style="padding-left: 1em;"><%# Eval("OrderTime").ToString().Substring(0,10) %></span>
                                <div class="col-8" style="color: gray;">订单编号：<span><%# Eval("OrderID") %></span></div>
                                <span class="ion-android-home col-1"></span>
                            </div>
                            <div class="content--right__bottom--item__bottom row">
                                <div class="col-8 content--right__bottom--item__bottom-div1">
                                    <dl class="content--right__bottom--item__bottom--dl">
                                        <dt>
                                            <img src="images/MovieCover/中国机长.jpg" alt=""></dt>
                                        <dd>《<%# Eval("MovieName") %>》</dd>
                                        <dd><%# Eval("CinemaName") %></dd>
                                        <dd>&nbsp;&nbsp;<%# Eval("OfficeName") %></dd>
                                        <dd style="margin-top: 20px"><%# Eval("StartTime").ToString().Substring(0,19) %></dd>
                                    </dl>
                                </div>
                                <div class="col-1 content--right__bottom--item__bottom-div">&yen;<span><%# Eval("OrderSumMoney") %></span></div>

                                <%# DataBinder.Eval(Container.DataItem, "IsPay").ToString()== "0"?
                                        " <div class='col-2 content--right__bottom--item__bottom-div' style='text-align: center; color: rgb(212, 29, 29);'>待支付</div>" +
                                        "<div class='col-1' style='font-size: 1.3em; text-align: center;'>" +
                                        "<span class='fukuan--span fukuan'>" +
                                        "<a href='javascript:0'>付款</a>" +
                                        "</span>" +
                                        "</div>"
                                        :"<div class='col-2 content--right__bottom--item__bottom-div' style='text-align: center;'>已付款</div>"%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <script>
            $(function () {
                $('.fukuan').click(function () {
                    console.log($(this).parent().parent().prev().children("div").children("span").html());
                    window.location.href = "OrderPay.aspx?OrderID=" + $(this).parent().parent().prev().children("div").children("span").html();
                });
                var $height = $('.content--right').css("height");
                $('.content--left').css("height", $height);
            })
        </script>
    </section>
</asp:Content>