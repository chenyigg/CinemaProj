<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="ChooseCinema.aspx.cs" Inherits="WebUI.Cinema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/reset.css">
    <link rel="stylesheet" href="Content/layout.css">
    <link rel="stylesheet" href="Content/ionicons.css">
    <link rel="stylesheet" href="Content/ChooseCinemaCss/Cinema.css">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/ChooseCinemaJs/cinema.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="content" class="row">
        <div class="content--top row">
            <div class="content--top__content row">
                <div class="content--top__content--item1 col-7">
                    <dl class="content--top__content--item1__dl">
                        <dt><a href="">
                            <img src="images/MovieCover/<%=mv.MovieCover %>" alt=""></a></dt>
                        <dd><%=mv.MovieName %></dd>
                        <dd style="font-size: 1.4em;">Cinema China</dd>
                        <dd style="padding-top: 10px;"><%=mv.MovieType %></dd>
                        <dd><%=mv.MovieArea %>/<%=mv.MovieDuration %>分钟</dd>
                        <dd><%=mv.MovieReleaseDate.ToString().Substring(0,10) %>  上映</dd>
                        <dd style="padding-top: 56px;" class="content--top__content--item1__dl--a">
                            <a href=""><span class="ion-ios-heart"></span>&nbsp;&nbsp;想看</a>
                            <a href=""><span class="ion-android-star"></span>&nbsp;&nbsp;评分</a>
                        </dd>
                        <dd class="content--top__content--item1__dl--buy"><a href="Details.aspx?MovieID=<%=mv.MovieID %>">查看更多电影详情</a></dd>
                    </dl>
                </div>
                <div class="content--top__content--item2 col-5">
                    <dl>
                        <dd style="padding-top: 165px;">用户评分</dd>
                        <dd><span style="color: orange;"><%=mv.MovieScore %></span>分</dd>
                        <dd>累计票房</dd>
                        <dd><span>1.85</span>亿</dd>
                    </dl>
                </div>
            </div>
        </div>
        <div class="content--select">
            <div class="content--select__date">
                <span class="content--select__text">&nbsp;&nbsp;&nbsp;日期：</span>
                <ul class="content--select__container">
                    <li class="flex-container_item content--select__date--active">
                        <span class="flex-container_item_text">今天12月11日</span>
                    </li>
                    <%--  <li class="flex-container_item">
                        <span class="flex-container_item_text">明天12月12日</span>
                    </li>--%>
                </ul>
            </div>
            <div class="content--select__brand">
                <span class="content--select__text">&nbsp;&nbsp;&nbsp;品牌：</span>
                <ul class="content--select__container">
                    <li class="flex-container_item content--select__brand--active">
                        <span class="flex-container_item_text">全部</span>
                    </li>
                    <%-- <li class="flex-container_item">
                        <span class="flex-container_item_text">tata</span>
                    </li>--%>
                </ul>
            </div>
            <div class="content--select__district">
                <span class="content--select__text">行政区：</span>
                <ul class="content--select__container">
                    <li class="flex-container_item content--select__district--active">
                        <span class="flex-container_item_text">全部</span>
                    </li>
                    <%--  <li class="flex-container_item">
                        <span class="flex-container_item_text">全部</span>
                    </li>--%>
                </ul>
            </div>
            <div class="content--select__special">
                <span class="content--select__text">特殊厅：</span>
                <ul class="content--select__container">
                    <li class="flex-container_item content--select__special--active">
                        <span class="flex-container_item_text">全部</span>
                    </li>
                    <%--<li class="flex-container_item">
                        <span class="flex-container_item_text">全部</span>
                    </li>--%>
                </ul>
            </div>
        </div>
        <div class="content--address">
            <span class="content--address--cinemaadd">影院列表</span>
            <div class="content--address--cinemalist">

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="content--address--cinemalist__item">
                            <ul class="content--address--cinemalist__item--left">
                                <li><%# Eval("CinemaName") %></li>
                                <li>地址：<%# Eval("CinemaAddress") %></li>
                            </ul>
                            <div class="content--address--cinemalist__item--right">
                                <span>&yen;49.9<span style="font-size: 0.8em; color: gray;">起</span></span>
                                <span><a href="ChooseOffice.aspx?MovieID=<%=mv.MovieID %>&CinemaID=<%#Eval("CinemaID") %>">选座购票</a></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>