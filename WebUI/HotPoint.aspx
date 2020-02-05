﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="HotPoint.aspx.cs" Inherits="WebUI.HotPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/layout.css">
    <link rel="stylesheet" href="Content/reset.css">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/MovieCss/menu.css">
    <link rel="stylesheet" href="Content/HotPointCss/HotPoint.css">
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="HotPoint_content">
        <div class="htmleaf-container">
            <div class="tab" role="tabpanel">
                <!-- Nav tabs -->
                <ul style="margin-top: 100px;" class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">新闻资讯</a></li>
                    <li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">预告片</a></li>
                    <li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">热门音乐</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content tabs">
                    <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                        <!-- /*放新闻资讯*/ -->
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <dl class="row">
                                    <dt class="col-2">
                                        <img style="width: 100%; height: 100%;" src="images/NewsImg/<%# Eval("NewsPoster")%>" /></dt>
                                    <div class="col-9">
                                        <dd style="color: black; font-size: 30px;"><%# Eval("NewsSynopsis")%></dd>
                                        <dd><%# Eval("NewsContent")%></dd>
                                        <dd style="margin-top: 40px;"><%# Eval("NewsSource")%> <%# Eval("IssueTime")%></dd>
                                        <dd style="margin-top: 20px;">其他</dd>
                                    </div>
                                </dl>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div role="tabpanel" class="tab-pane fade" id="Section2">

                        <!-- /*放预告片*/ -->
                        <div class="flex_container">
                            <dl class="flex_container_item">
                                <dt>
                                    <video src="video/初音.mp4" controls="controls"></video>
                                </dt>
                                <dd>预告片名</dd>
                                <dd>播放量</dd>
                            </dl>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section3">

                        <!-- /*放热门音乐*/ -->
                        <div class="music_body">
                            <div class="title row">
                                <span class="col-5">歌曲</span>
                                <span class="col-2">时长</span>
                                <span class="col-2">歌手</span>
                                <span class="col-3">播放</span>
                            </div>

                            <div class="music_body_list_item row">
                                <span class="col-5">嚣张</span>
                                <span class="col-2">4:45</span>
                                <span class="col-2">en</span>
                                <span class="col-3">
                                    <audio src="Content/music/嚣张.mp3" controls="controls"></audio>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>