<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebUI.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/DetailsCss/details.css">
    <link href="Content/easyui.css" rel="stylesheet" />
    <link href="Content/icon.css" rel="stylesheet" />
    <link href="Content/demo.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>

    <script src="Scripts/DetailsJs/Details.js"></script>
    <script src="Scripts/vue.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" class="row" onselectstart="return false">
        <div class="content--top row">
            <div class="content--top__content row">
                <div class="content--top__content--item1 col-7">
                    <dl class="content--top__content--item1__dl">
                        <dt><a href="">
                                <img src="images/MovieCover/<%=mz.MovieCover %>" alt="<%=mz.MovieName %>"
                                    title="<%=mz.MovieID %>" id="imgone"></a></dt>
                        <dd style="padding-top:5px">
                            <%=mz.MovieName %>
                        </dd>
                        <dd style="font-size: 1.4em;">LinXi Cinema</dd>
                        <dd style="padding-top: 10px;">
                            <%=mz.MovieType %>
                        </dd>
                        <dd>
                            <%=mz.MovieArea %>/
                                <%=mz.MovieDuration %>分钟</dd>
                        <dd>
                            <%=mz.MovieReleaseDate.ToString().Substring(0,10) %> 大陆上映</dd>
                        <dd style="padding-top: 56px;" class="content--top__content--item1__dl--a">
                            <a href=""><span class="ion-ios-heart"></span>&nbsp;&nbsp;想看</a>
                            <a href=""><span class="ion-android-star"></span>&nbsp;&nbsp;评分</a>
                        </dd>
                        <dd class="content--top__content--item1__dl--buy"><a href="ChooseCinema.aspx?MovieID=<%=mz.MovieID %>">特票优惠</a></dd>
                    </dl>
                </div>
                <div class="content--top__content--item2 col-5">
                    <dl>
                        <dd style="padding-top: 165px;">用户评分</dd>
                        <dd><span style="color: orange;"><%=mz.MovieScore %></span>分</dd>
                        <dd>累计票房</dd>
                        <dd><span>1.85</span>亿</dd>
                    </dl>
                </div>
            </div>
        </div>
        <div class="content--bottom row" id="contentbt">
            <span class="content--bottom__juqing">剧情简介</span>
            <div class="content--bottom__juqing--text">
                <%=mz.MovieBrief %>
            </div>

            <div class="content--bottom__reping row">
                <span class="content--bottom__reping--text col-2">热门短评</span>
                <input class="content--bottom__reping--button col-9" type="text" id="txtSee" placeholder="我也想评论">
                <span style="margin-left: 2em;" class="content--bottom__reping--write col-1" id="btnSay" @click="BtnSayClick">发表</span>
            </div>
            <div id="box_List" style="width:100%">
                <div class="content--bottom__reping--item row" style="width: 100%;" v-for="i in List">
                    <dl style="width: 100%;">
                        <dt>
                            <img :src="['images/UserFaceImg/'+ i.UserFace]" :alt="i.UserName">
                        </dt>
                        <span class="ion-android-pin content--bottom__reping--item--span">&nbsp;1164</span>
                        <dd style="font-size: 1.3em;">{{i.UserName}}</dd>
                        <dd>{{i.CommentTime.substring(0,10)}}</dd>
                        <dd style="padding-top: 30px;">{{i.CommentInfo}}</dd>
                    </dl>
                </div>
            </div>
            <div class="content_Page" style="width:100%">
                <span class="Page_text">当前为第<strong style="color:red">{{PageNow}}</strong>页，总页数<strong style="color:red">{{PageCount}}</strong>页</span>

                <input type="button" value="首页" @click="FirstCommentInfo" />
                <input type="button" value="<<" @click="PrevCommentInfo" />

                <input type="button" value=">>" @click="NextCommentInfo" />
                <input type="button" value="末页" @click="EndCommentInfo" />
            </div>
        </div>
    </section>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
</asp:Content>