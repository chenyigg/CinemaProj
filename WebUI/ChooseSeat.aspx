﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="ChooseSeat.aspx.cs" Inherits="WebUI.ChooseSeat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/ChooseSeatCss/chooseSeat.css" rel="stylesheet" />
    <link href="Content/layout.css" rel="stylesheet" />
    <link href="Content/reset.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/vue.js"></script>
    <script src="Scripts/ChooseSeatJs/chooseSeatJs.js"></script>
    <style>
        chooseSeat_section_body_left_buttom table {
            border: 1px;
        }

        .seatCheckInfo {
            color: red;
            border: 1px solid gray;
            font-size: 20px;
        }

        .sureChanceSeat {
            border: 1px solid black;
            width: 200px;
            height: 50px;
            line-height: 50px;
            border-radius: 25px;
            text-align: center;
            margin-left: 8%;
            background: green;
            color: white;
            font-size: 20px;
        }

            .sureChanceSeat:hover {
                background: red;
                color: white;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section id="chooseSeat_section">
        <div class="chooseSeat_section_header" style="margin-top: 100px;">
            <img src="images/ChooseSeatImg/选座header.png" alt="">
        </div>
        <div class="chooseSeat_section_body row">
            <div class="chooseSeat_section_body_left col-8">
                <div class="chooseSeat_section_body_left_top">
                    <img src="images/ChooseSeatImg/座位状态.png" alt="">
                </div>
                <div class="chooseSeat_section_body_left_buttom" style="padding-right: 20%;">
                    <div style="float: left;line-height:40px;font-size:20px;color:red;display:none;">
                        <p>
                            1
                        </p>
                        <p>
                            2
                        </p>
                        <p>
                            3
                        </p>
                        <p>
                            4
                        </p>
                        <p>
                            5
                        </p>
                        <p>
                            6
                        </p>
                        <p>
                            7
                        </p>
                        <p>
                            8
                        </p>
                        <p>
                            9
                        </p>
                        <p>
                            10
                        </p>
                    </div>
                    <div style="width:720px;height:100%;margin-left:20%;">
                        <div v-for="i in List" style="display:inline-block;">
                            <div v-if="i.IsSeat=='1'">
                                <img class="seatCick" @click="changeSeatBg($event,i.SeatID)" src="images/ChooseSeatImg/seat.png" style="height: 35px; width: 35px;margin-left: 8px;" />
                            </div>
                            <div v-else-if="i.IsSeat=='0'">
                                <img src="images/ChooseSeatImg/seat.png" style="height: 35px; width: 35px;opacity:0;margin-left: 8px;" />
                            </div>
                            <div v-else-if="i.IsSeat=='2'">
                                <img src="images/ChooseSeatImg/seatAlChecked.png" style="height: 35px; width: 35px;margin-left: 8px;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="chooseSeat_section_body_right col-4">
                <div class="chooseSeat_section_body_right_MovieInfo">
                    <div class="chooseSeat_section_body_right_MovieInfo_top row">
                        <div class="chooseSeat_section_body_right_MovieInfo_topImg col-5">
                            <img src="images/ChooseSeatImg/中国机长.png" alt="">
                        </div>
                        <div class="chooseSeat_section_body_right_MovieInfo_topText col-7">
                            <p class="chooseSeat_section_body_right_MovieInfo_topText_title">
                                中国机长
                            </p>
                            <p>
                                <span class="chooseSeat_section_body_right_MovieInfo_topText_type">
                                    类型：
                                </span>
                            </p>
                            <p>
                                <span class="chooseSeat_section_body_right_MovieInfo_topText_des">
                                    时长：
                                </span>
                            </p>
                        </div>
                    </div>
                    <div class="chooseSeat_section_body_right_MovieInfo_buttom">
                        <p>
                            <span class="chooseSeat_section_body_right_MovieInfo_text ">
                                影院:
                            </span> <span class="chooseSeat_section_body_right_MovieInfo_text_yingyuan"></span>
                        </p>
                        <p>
                            <span class="chooseSeat_section_body_right_MovieInfo_text ">
                                影厅:
                            </span> <span class="chooseSeat_section_body_right_MovieInfo_text_yingting"></span>
                        </p>
                        <p>
                            <span class="chooseSeat_section_body_right_MovieInfo_text ">
                                版本:
                            </span> <span class="chooseSeat_section_body_right_MovieInfo_text_banben"></span>
                        </p>
                        <p>
                            <span class="chooseSeat_section_body_right_MovieInfo_text ">
                                场次:
                            </span> <span class="chooseSeat_section_body_right_MovieInfo_text_changci"></span>
                        </p>
                        <p>
                            <span class="chooseSeat_section_body_right_MovieInfo_text ">
                                票价:
                            </span> ￥<span class="chooseSeat_section_body_right_MovieInfo_text_piaojia"></span>/张
                        </p>
                    </div>
                </div>
                <div class="chooseSeat_section_body_right_SeatInfo">
                    <p>
                        座位：
                        <span class="seatCheckInfo"></span>
                    </p>
                    <p>
                        请点击左侧座位图选择座位
                    </p>
                    <p>
                        总价:
                        <span id="Sum" class="chooseSeat_section_body_right_SeatInfo_price">
                            ￥0
                        </span>
                    </p>
                </div>
                <div class="chooseSeat_section_body_right_UserInfo">
                    <p style="opacity:0;">
                        <span>
                            手机号:
                        </span> 18229534024
                    </p>
                    <p>
                        <div @click="sureChooseSeat" class="sureChanceSeat">
                            确认选座
                        </div>
                    </p>
                </div>
            </div>
        </div>
    </section>
    <script src="~/Scripts/ChooseSeatJs/chooseSeatJs.js"></script>
</asp:Content>