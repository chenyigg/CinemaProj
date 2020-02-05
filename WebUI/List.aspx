<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebUI.Cinema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/reset.css">
    <link rel="stylesheet" href="Content/layout.css">
    <link rel="stylesheet" href="Content/ionicons.css">
    <link rel="stylesheet" href="Content/bootstrap.min.css">
    <link rel="stylesheet" href="Content/ListCss/bangdan.css">
    <link rel="stylesheet" href="Content/ListCss/menu.css">
    <link rel="stylesheet" href="Content/ListCss/htmleaf-demo.css">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/ListJs/ListJs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" class="row" style="height:3400px">
        <div class="content--nav">
            <div class="htmleaf-container">
                <div class="tab" role="tabpanel">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a id="asection1" href="#Section1" aria-controls="home" role="tab" data-toggle="tab">热映口碑榜</a></li>
                        <li role="presentation"><a id="asection2" href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">最受期待榜</a></li>
                        <li role="presentation"><a id="asection3" href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">国内票房榜</a></li>
                        <li role="presentation"><a id="asection4" href="#Section4" aria-controls="profile" role="tab" data-toggle="tab">北美票房榜</a></li>
                        <%--<li role="presentation"><a id="asection5" href="#Section5" aria-controls="messages" role="tab" data-toggle="tab">TOP50榜</a></li>--%>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content tabs">
                        <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                            <!-- 内容1 -->
                            <div class="content--container row">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <div class="content--container__item row">
                                            <div class="content--container__item--ranking col-1">
                                                <span style="background-color: orange; color: white"><%# Container.ItemIndex+1 %></span>
                                            </div>
                                            <div class="content--container__item--content col-9">
                                                <dl class="content--container__item--content__dl">
                                                    <dt><a href="">
                                                        <img src="images/MovieCover/<%# Eval("MovieCover") %>" alt=""></a></dt>
                                                    <dd><a href=""><%# Eval("MovieName") %></a></dd>
                                                    <dd>主演：<%# Eval("MoviePeople") %></dd>
                                                    <dd>上映时间：<%# Eval("MovieReleaseDate")%></dd>
                                                </dl>
                                            </div>
                                            <div class="content--container__item--grade col-2">
                                                <div><span style="font-size: 2.8em"><%# Eval("MovieScore").ToString().Substring(0,2)%></span><%# Eval("MovieScore").ToString().Substring(2,1)%></div>
                                                <div class="content--container__item--grade__xiangqing">
                                                    dewky4tbiuqnpmrwcn4tyumq;n3c
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="Section2">
                            <!-- 内容2 -->
                            <div class="content--container row">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <div class="content--container__item row">
                                            <div class="content--container__item--ranking col-1">
                                                <span style="background-color: orange; color: white"><%# Container.ItemIndex+1 %></span>
                                            </div>
                                            <div class="content--container__item--content col-9">
                                                <dl class="content--container__item--content__dl">
                                                    <dt><a href="">
                                                        <img src="images/MovieCover/<%# Eval("MovieCover") %>" alt=""></a></dt>
                                                    <dd><a href=""><%# Eval("MovieName") %></a></dd>
                                                    <dd>主演：<%# Eval("MoviePeople") %></dd>
                                                    <dd>上映时间：<%# Eval("MovieReleaseDate")%></dd>
                                                </dl>
                                            </div>
                                            <div class="content--container__item--grade col-2">
                                                <div><span style="font-size: 2.8em"><%# Eval("MovieScore").ToString().Substring(0,2)%></span><%# Eval("MovieScore").ToString().Substring(2,1)%></div>
                                                <div class="content--container__item--grade__xiangqing">
                                                    dewky4tbiuqnpmrwcn4tyumq;n3c
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="Section3">
                            <!-- 内容3 -->
                            <div class="content--container row">
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <div class="content--container__item row">
                                            <div class="content--container__item--ranking col-1">
                                                <span style="background-color: orange; color: white"><%# Container.ItemIndex+1 %></span>
                                            </div>
                                            <div class="content--container__item--content col-9">
                                                <dl class="content--container__item--content__dl">
                                                    <dt><a href="">
                                                        <img src="images/MovieCover/<%# Eval("MovieCover") %>" alt=""></a></dt>
                                                    <dd><a href=""><%# Eval("MovieName") %></a></dd>
                                                    <dd>主演：<%# Eval("MoviePeople") %></dd>
                                                    <dd>上映时间：<%# Eval("MovieReleaseDate")%></dd>
                                                </dl>
                                            </div>
                                            <div class="content--container__item--grade col-2">
                                                <div><span style="font-size: 2.8em"><%# Eval("MovieScore").ToString().Substring(0,2)%></span><%# Eval("MovieScore").ToString().Substring(2,1)%></div>
                                                <div class="content--container__item--grade__xiangqing">
                                                    dewky4tbiuqnpmrwcn4tyumq;n3c
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="Section4">
                            <!-- 内容4 -->
                            <div class="content--container row">
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <div class="content--container__item row">
                                            <div class="content--container__item--ranking col-1">
                                                <span style="background-color: orange; color: white"><%# Container.ItemIndex+1 %></span>
                                            </div>
                                            <div class="content--container__item--content col-9">
                                                <dl class="content--container__item--content__dl">
                                                    <dt><a href="">
                                                        <img src="images/MovieCover/<%# Eval("MovieCover") %>" alt=""></a></dt>
                                                    <dd><a href=""><%# Eval("MovieName") %></a></dd>
                                                    <dd>主演：<%# Eval("MoviePeople") %></dd>
                                                    <dd>上映时间：<%# Eval("MovieReleaseDate")%></dd>
                                                </dl>
                                            </div>
                                            <div class="content--container__item--grade col-2">
                                                <div><span style="font-size: 2.8em"><%# Eval("MovieScore").ToString().Substring(0,2)%></span><%# Eval("MovieScore").ToString().Substring(2,1)%></div>
                                                <div class="content--container__item--grade__xiangqing">
                                                    dewky4tbiuqnpmrwcn4tyumq;n3c
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                      <%--  <div role="tabpanel" class="tab-pane fade" id="Section5">
                            <!-- 内容5 -->
                            <div class="content--container row">
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <div class="content--container__item row">
                                            <div class="content--container__item--ranking col-1">
                                                <span style="background-color: orange; color: white"><%# Container.ItemIndex+1 %></span>
                                            </div>
                                            <div class="content--container__item--content col-9">
                                                <dl class="content--container__item--content__dl">
                                                    <dt><a href="">
                                                        <img src="images/MovieCover/<%# Eval("MovieCover") %>" alt=""></a></dt>
                                                    <dd><a href=""><%# Eval("MovieName") %></a></dd>
                                                    <dd>主演：<%# Eval("MoviePeople") %></dd>
                                                    <dd>上映时间：<%# Eval("MovieReleaseDate")%></dd>
                                                </dl>
                                            </div>
                                            <div class="content--container__item--grade col-2">
                                                <div><span style="font-size: 2.8em"><%# Eval("MovieScore").ToString().Substring(0,2)%></span><%# Eval("MovieScore").ToString().Substring(2,1)%></div>
                                                <div class="content--container__item--grade__xiangqing">
                                                    dewky4tbiuqnpmrwcn4tyumq;n3c
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
