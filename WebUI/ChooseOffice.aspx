<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="ChooseOffice.aspx.cs" Inherits="WebUI.ChooseOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/ChooseOfficeCss/xuanting.css">
    <!-- Load jQuery -->
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>

    <!-- 必要样式 -->
    <link href="Content/ChooseOfficeCss/mislider.css" rel="stylesheet">
    <link href="Content/ChooseOfficeCss/mislider-skin-cameo.css" rel="stylesheet">

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/ChooseOfficeJs/cinema..js"></script>
    <script src="Scripts/vue.js"></script>

    <script type="text/javascript" src="Scripts/ChooseOfficeJs/mislider.js"></script>
    <script type="text/javascript">
        jQuery(function ($) {
            var slider = $('.mis-stage').miSlider({
                //  The height of the stage in px. Options: false or positive integer. false = height is calculated using maximum slide heights. Default: false
                stageHeight: 380,
                //  Number of slides visible at one time. Options: false or positive integer. false = Fit as many as possible.  Default: 1
                slidesOnStage: false,
                //  The location of the current slide on the stage. Options: 'left', 'right', 'center'. Defualt: 'left'
                slidePosition: 'center',
                //  The slide to start on. Options: 'beg', 'mid', 'end' or slide number starting at 1 - '1','2','3', etc. Defualt: 'beg'
                slideStart: 'top',
                //  The relative percentage scaling factor of the current slide - other slides are scaled down. Options: positive number 100 or higher. 100 = No scaling. Defualt: 100
                slideScaling: 150,
                //  The vertical offset of the slide center as a percentage of slide height. Options:  positive or negative number. Neg value = up. Pos value = down. 0 = No offset. Default: 0
                offsetV: -5,
                //  Center slide contents vertically - Boolean. Default: false
                centerV: true,
                //  Opacity of the prev and next button navigation when not transitioning. Options: Number between 0 and 1. 0 (transparent) - 1 (opaque). Default: .5
                navButtonsOpacity: 1
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" class="row">
        <div class="content--top row">
            <div class="content--top__content row">
                <dl class="content--top__content--dl">
                    <dt>
                        <img src="images/CinemaCover/<%=om.CinemaImg %>" alt="<%=om.CinemaName %>"></dt>
                    <dd style="font-size: 2em;">
                        <%=om.CinemaName%>
                    </dd>
                    <dd>
                        <%=om.CinemaAddress %>
                    </dd>
                    <dd>区域：
                        <%=om.CinemaArea %>
                    </dd>
                    <dd style="padding-top: 40px;">影院服务</dd>
                    <dd>
                        <hr>
                    </dd>
                    <dd><span>儿童优惠</span>&nbsp;&nbsp;1.3米以下2D3D免费，需有一名承认带领</dd>
                    <dd><span>可停车</span>&nbsp;&nbsp;免费停车两小时</dd>
                </dl>
            </div>
        </div>
        <div class="content--lunbo row">
            <div class="mis-stage">
                <ol class="mis-slider">
                    <asp:Repeater id="Repeater1" runat="server">
                        <ItemTemplate>
                            <li class="mis-slide">
                                <a href="javascript:0" class="mis-container">
                                    <figure>
                                        <img src="images/MovieCover/<%#Eval("MovieCover") %>" title="<%#Eval("MovieName") %>" alt="<%#Eval("MovieID") %>"  @click='SelectMovieInfo($event)'>
                                    </figure>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ol>
            </div>
        </div>
        <div class="content--bottom row">
            <div class="content--bottom__top">
                <dl class="content--bottom__top--dl">
                    <dd id="mn" v-cloak>{{MovieName}}</dd>
                    <span style="color: orange; font-size: 1.5em; padding-left: 20px;" v-cloak>{{MovieScore}}</span>分
                    <dd class="content--bottom__top--dl__dd2" v-cloak>
                        时长:<span>{{MovieDuration}}分钟</span>&nbsp;&nbsp;&nbsp; 类型:
                        <span v-cloak>{{MovieType}}</span>&nbsp;&nbsp;&nbsp; 主演:
                        <span v-cloak>{{MoviePeople}}</span>&nbsp;&nbsp;&nbsp;
                    </dd>
                    <dd>
                        <hr>
                    </dd>
                    <dd style="padding-bottom: 10px;" class="content--bottom__top--dl__dd4">观影时间：<span @click="Tod" class="content--bottom__top--dl__dd4-span">今天{{Month}}月{{Day}}日</span><span @click="Tom">明天{{(K2?Month+1:Month)>12?1:(K2?Month+1:Month)}}月{{K2?1:Day+1}}日</span>
                    </dd>
                </dl>
            </div>
            <div class="content--bottom__bottom row" v-for="i in ListShowDetails">
                <div class="content--bottom__bottom--div col-12">
                    <ul class="content--bottom__bottom--ul" style="padding: 10px 0px;">
                        <li>放映时间</li>
                        <li>语言版本</li>
                        <li>放映厅</li>
                        <li>售价(元)</li>
                        <li>选座购票</li>
                    </ul>
                    <ul class="content--bottom__bottom--ul ul-item" style="padding: 10px 0px;">
                        <li class="content--bottom__bottom--ul-li1">
                            <span v-cloak>{{i.StartTime.substring(11,16)}}</span>
                            <span v-cloak>{{i.StopTime.substring(11,16)}}</span>
                        </li>
                        <li v-cloak>{{i.Language}}</li>
                        <li v-cloak>{{i.OfficeName}}</li>
                        <li style="color: red;">&yen;<span style="font-size: 1.2em; font-weight: bold;" v-cloak>{{i.Money}}</span></li>
                        <li>
                               <div v-if="i.Language=='英语'">
                            <a :href="'ChooseSeat.aspx?OfficeID='+i.OfficeID+'&Language='+'english'+'&ChipInfoID='+i.ChipInfoID+'&Money='+i.Money">选座购票</a>
                            </div>
                            <div v-else-if="i.Language=='国语'">
                            <a :href="'ChooseSeat.aspx?OfficeID='+i.OfficeID+'&Language='+'chinese'+'&ChipInfoID='+i.ChipInfoID+'&Money='+i.Money">选座购票</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
</asp:Content>