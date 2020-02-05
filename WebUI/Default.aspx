<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/reset.css" />
    <link rel="stylesheet" href="Content/layout.css" />
    <link rel="stylesheet" href="Content/ionicons.css" />
    <link rel="stylesheet" href="Content/MainCss/lunbo.css" />
    <link rel="stylesheet" href="Content/MainCss/content.css">
    <script type="text/javascript" src="Scripts/MainJs/lunbo.js"></script>
    <script src="Scripts/vue.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="content" class="row">
        <div class="content-item__lunbo">
            <div id="drag-container">
                <div id="spin-container">
                    <asp:Repeater ID="Repeater7" runat="server">
                        <ItemTemplate>
                            <a href="Details.aspx?MovieID=<%#Eval("MovieID")%>">
                                <img src="images/MovieCover/<%#Eval("MovieCover") %>" alt=""></a>
                        </ItemTemplate>
                    </asp:Repeater>

                    <p style="font-size: 80px;">灵 犀 影 院</p>
                </div>
                <div id="ground"></div>
            </div>
            <div id="music-container"></div>
        </div>
        <div class="left col-9">
            <div class="content-item">
                <div class="content-item__hot--text text">正在热映<%=IsHot %>部</div>
                <div class="content-item__hot--contains">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <dl>
                                <a style="height: 250px; width: 210px; display: block" href="Details.aspx?MovieID=<%#Eval("MovieID")%>" title='<%#Eval("MovieName")%>'>
                                    <dt style="background-image: url('images/MainCover/<%# Eval("MovieCover") %>'); overflow: hidden">
                                        <span class="content-item__hot--contains__s1"><%#Eval("MovieName") %></span>
                                    </dt>
                                </a>
                                <dd><a style="height: 50px; width: 210px; display: block; border: 1px solid lightgray;" href="ChooseCinema.aspx?MovieID=<%#Eval("MovieID")%>">购票</a></dd>
                            </dl>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="content-item">
                <div class="content-item__future--text text">即将上映<%=NoUp %>部</div>
                <div class="content-item__hot--contains">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <dl>
                                <a style="height: 250px; width: 210px; display: block" href="Details.aspx?MovieID=<%#Eval("MovieID")%>" title='<%#Eval("MovieName")%>'>
                                    <dt style="background-image: url('images/MainCover/<%# Eval("MovieCover") %>'); overflow: hidden">
                                        <span class="content-item__hot--contains__s1"><%#Eval("MovieName") %></span>
                                    </dt>
                                </a>
                                <dd><a style="height: 50px; width: 210px; display: block; border: 1px solid lightgray;" href="ChooseCinema.aspx?MovieID=<%#Eval("MovieID")%>">购票</a></dd>
                            </dl>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="content-item">
                <div class="content-item__classics--text text">经典电影<%=Score %>部</div>
                <div class="content-item__hot--contains">
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <dl>
                                <a style="height: 250px; width: 210px; display: block" href="Details.aspx?MovieID=<%#Eval("MovieID")%>" title='<%#Eval("MovieName")%>'>
                                    <dt style="background-image: url('images/MainCover/<%# Eval("MovieCover") %>'); overflow: hidden">
                                        <span class="content-item__hot--contains__s1"><%#Eval("MovieName") %></span>
                                    </dt>
                                </a>
                                <dd><a style="height: 50px; width: 210px; display: block; border: 1px solid lightgray;" href="ChooseCinema.aspx?MovieID=<%#Eval("MovieID")%>">购票</a></dd>
                            </dl>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="right col-3">
            <div class="content-item__list1 box" style="border: none;">
                <div class="content-item__list1--text">
                    <span class="content-item__list1--text1 texts">今日票房</span>
                    <span class="content-item__list1--text2"><a href="List.aspx">更多</a><span class="ion-chevron-right "></span></span>
                </div>
                <div class="content-item__list1--bang">

                    <asp:Repeater ID="Repeater4" runat="server">
                        <HeaderTemplate>
                            <div class="content-item__list1--bang1 row">
                                <div class="content-item__list1--bang1__tu col-5">
                                    <div class="content-item__list1--bang1__img">
                                        <img src="images/MovieCover/<%=M_MovieCover %>" style="width: 100%; height: 100px;" alt="">
                                    </div>
                                    <div class="content-item__list1--bang1__icon">
                                        <img src="images/MovieImg/今日票房.jpg" alt="">
                                    </div>
                                </div>
                                <div class="content-item__list1--bang1__text col-7">
                                    <div class="content-item__list1--bang1__text1"><%=M_MovieName %></div>
                                    <div class="content-item__list1--bang1__text2"><%=M_SumMoney+"元" %></div>
                                </div>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <ul>
                                <a href="Details.aspx?MovieID=<%#Eval("MovieID") %>" style="display: block; width: 100%;">
                                    <li class="content-item__list1--bangsth row">
                                        <span class="content-item__list1--bangsth__shuzi col-1">&nbsp;<%#Container.ItemIndex+2 %></span>
                                        <span class="content-item__list1--bangsth__text col-8"><%#Eval("MovieName") %></span>
                                        <span class="content-item__list1--bangsth__count col-3"><%#Eval("SumMoney")+"元" %></span>
                                    </li>
                                </a>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="content-item__list2 box">
                <div class="content-item__list1--text">
                    <span class="content-item__list1--no2 texts">最受期待</span>
                    <span class="content-item__list1--text2"><a href="List.aspx">更多</a><span class="ion-chevron-right "></span></span>
                </div>
                <div class="content-item__list1--bang">
                    <div class="content-item__list1--bang">

                        <asp:Repeater ID="Repeater5" runat="server">
                            <HeaderTemplate>
                                <div class="content-item__list1--bang1 row">
                                    <div class="content-item__list1--bang1__tu col-5">
                                        <div class="content-item__list1--bang1__img">
                                            <img src="images/MovieCover/<%=M_MovieCover %>" style="width: 100%; height: 100px;" alt="">
                                        </div>
                                        <div class="content-item__list1--bang1__icon">
                                            <img src="images/MovieImg/最受期待.jpg" alt="">
                                        </div>
                                    </div>
                                    <div class="content-item__list1--bang1__text col-7">
                                        <div class="content-item__list1--bang1__text1"><%=M_MovieName %></div>
                                        <div class="content-item__list1--bang1__text2"><%=M_MovieArea %></div>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <ul>
                                    <a href="Details.aspx?MovieID=<%#Eval("MovieID") %>" style="display: block; width: 100%;">
                                        <li class="content-item__list1--bangsth row">
                                            <span class="content-item__list1--bangsth__shuzi col-1">&nbsp;<%#Container.ItemIndex+2 %></span>
                                            <span class="content-item__list1--bangsth__text col-8"><%#Eval("MovieName") %></span>
                                            <span class="content-item__list1--bangsth__count col-3"><%#Eval("MovieArea") %></span>
                                        </li>
                                    </a>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="content-item__list3 box" style="overflow: hidden">
                    <div class="content-item__list1--text">
                        <span class="content-item__list1--text3 texts">经典Top</span>
                        <span class="content-item__list1--text2"><a href="List.aspx">更多</a><span class="ion-chevron-right "></span></span>
                    </div>
                    <div class="content-item__list1--bang">
                        <div class="content-item__list1--bang">

                            <asp:Repeater ID="Repeater6" runat="server">
                                <HeaderTemplate>
                                    <div class="content-item__list1--bang1 row">
                                        <div class="content-item__list1--bang1__tu col-5">
                                            <div class="content-item__list1--bang1__img">
                                                <img src="images/MovieCover/<%=M_MovieCover %>" style="width: 100%; height: 100px;" alt="">
                                            </div>
                                            <div class="content-item__list1--bang1__icon">
                                                <img src="images/MovieImg/经典top.jpg" alt="">
                                            </div>
                                        </div>
                                        <div class="content-item__list1--bang1__text col-7">
                                            <div class="content-item__list1--bang1__text1"><%=M_MovieName %></div>
                                            <div class="content-item__list1--bang1__text2"><%=M_MovieType %></div>
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <ul>
                                        <a href="Details.aspx?MovieID=<%#Eval("MovieID") %>" style="display: block; width: 100%;">
                                            <li class="content-item__list1--bangsth row">
                                                <span class="content-item__list1--bangsth__shuzi col-1">&nbsp;<%#Container.ItemIndex+2 %></span>
                                                <span class="content-item__list1--bangsth__text col-8"><%#Eval("MovieName") %></span>
                                                <span class="content-item__list1--bangsth__count col-3"><%#Eval("MovieType") %></span>
                                            </li>
                                        </a>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>