<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="ChooseSeat.aspx.cs" Inherits="WebUI.ChooseSeat" %>

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
    <script>
        //获取浏览器传过来的值
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }
        var chipInfoID = GetQueryString("ChipInfoID");
        var officeID = GetQueryString("OfficeID");
        var Language = GetQueryString("Language");
        if (Language == 'english') Language = "英语";
        else Language = "国语";
        var Money = GetQueryString("Money");
        //初始化数据
        var vm = new Vue({
            el: "#chooseSeat_section",
            data: {
                List: [{
                    SeatID: "",
                    OfficeID: "",
                    IsSeat: ""
                }],
                konglie1: 5,
                konglie2: 12,
                SeatIDarray: []
            },
            mounted() {
                this.loadMovieInfo(),
                    this.loatSeat(),
                    this.loadCinema(),
                    this.loadOffice();
            },
            methods: {
                sureChooseSeat() {
                    $.ajax({
                        type: "Post",
                        async: false,
                        dataType: "json",
                        //url: "ChooseSeat.aspx?Method=sureChooseSeat&SeatIDarray=" + vm.SeatIDarray,
                        url: "ChooseSeat.aspx?Method=sureChooseSeat",
                        data: {
                            'SeatIDarray': JSON.stringify(vm.SeatIDarray),
                            ChipInfoID: chipInfoID,
                            Money: Money,
                            officeID: officeID
                        },
                        success: function (data) {
                            alert("选座成功!");
                            setTimeout(function () {
                                window.location.href = "OrderPay.aspx?OrderID=" + data.OrderID;
                            }, 1000)
                        },
                        Error: function () {
                            alert("购买失败!");
                        }
                    })
                },
                loatSeat: function () {
                    $.ajax({
                        type: "Post",
                        url: "ChooseSeat.aspx?Method=loadSeatInfo",
                        data: {
                            OfficeID: officeID,
                            chipInfoID: chipInfoID
                        },
                        success: function (data) {
                            var jsondata = JSON.parse(data);
                            //alert("转化成功");
                            vm.List = jsondata;
                            //alert(vm.List);
                            $.each(jsondata,
                                function (index, value) {
                                    if (value.IsSeat == 0 && value.SeatID % 160 % 16 < 8) {
                                        this.konglie1 = value.SeatID % 160 % 16;
                                        //alert(this.konglie1);
                                    } else if (value.IsSeat == 0 && value.SeatID % 160 %
                                        16 > 8) {
                                        this.konglie2 = value.SeatID % 160 % 16;
                                        //alert(this.konglie2);
                                    }
                                })
                        }
                    });
                },
                loadMovieInfo: function () {
                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "ChooseSeat.aspx?Method=loadMovieInfo",
                        data: {
                            ChipInfoID: chipInfoID
                        },
                        success: function (data) {
                            var jsondata = JSON.parse(data);
                            //alert("转化成功");
                            $('.chooseSeat_section_body_right_MovieInfo_topImg').children('img').attr("src", "images/MovieCover/" + jsondata.MovieCover);
                            $('.chooseSeat_section_body_right_MovieInfo_topText_title').html(jsondata.MovieName);
                            $('.chooseSeat_section_body_right_MovieInfo_topText_type').html("类型：" + jsondata.MovieType);
                            $('.chooseSeat_section_body_right_MovieInfo_topText_des').html("时长：" + jsondata.MovieDuration + "分钟");
                            $('.chooseSeat_section_body_right_MovieInfo_text_banben').html(Language);
                            $('.chooseSeat_section_body_right_MovieInfo_text_piaojia').html(Money);
                        }
                    });
                },
                loadCinema: function () {
                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "ChooseSeat.aspx?Method=loadCinema",
                        data: {
                            ChipInfoID: chipInfoID
                        },
                        success: function (data) {
                            var jsondata = JSON.parse(data);
                            $('.chooseSeat_section_body_right_MovieInfo_text_yingyuan').html(jsondata.CinemaName);
                            $('.chooseSeat_section_body_right_MovieInfo_text_changci').html(jsondata.CinemaName);
                        }
                    });
                }, loadOffice: function () {
                    $.ajax({
                        type: "Post",
                        async: false,
                        url: "ChooseSeat.aspx?Method=loadOffice",
                        data: {
                            ChipInfoID: chipInfoID
                        },
                        success: function (data) {
                            var jsondata = JSON.parse(data);
                            $('.chooseSeat_section_body_right_MovieInfo_text_yingting').html(jsondata.OfficeName);

                        }
                    });
                },
                changeSeatBg(event, SeatID) {
                    /*5代表第五列，空列，也就是非座位列*/
                    /*12代表第十二列，空列，也就是非座位列*/
                    //alert(konglie1);
                    //alert(konglie2);
                    var i = SeatID;
                    var zuowei = ""
                    if (i % 160 % 16 < vm.konglie1) {
                        //alert("1"+SeatID);
                        zuowei = (parseInt(SeatID % 160 / 16) + 1) + "排" + (i % 160 % 16) + "座";
                        if (i % 160 % 16 == 0) {
                            zuowei = (parseInt(SeatID % 160 / 16)) + "排" + "14" + "座";
                        }
                        //alert(zuowei);
                    } else if (i % 160 % 16 < vm.konglie2) {
                        //alert("2"+SeatID);
                        zuowei = (parseInt(SeatID % 160 / 16) + 1) + "排" + (i % 160 % 16 - 1) + "座";
                        //alert(zuowei);
                    } else if (i % 160 % 16 < 16) {
                        //alert("3"+SeatID);
                        zuowei = (parseInt(SeatID % 160 / 16) + 1) + "排" + (i % 160 % 16 - 2) + "座";
                        //alert(zuowei);
                    }
                    var el = event.currentTarget;
                    //alert("当前对象的内容：" + el.src);
                    var host = "https://" + window.location.host;

                    var piao = $('.seatCheckInfo').html();
                    if (el.src == host + "/images/ChooseSeatImg/seat.png") {
                        el.src = host + "/images/ChooseSeatImg/seatChecked.png";
                        piao = piao + "  " + zuowei;
                        $('.seatCheckInfo').html(piao);
                        vm.SeatIDarray.push(SeatID);
                    } else if (el.src == host + "/images/ChooseSeatImg/seatChecked.png") {
                        el.src = host + "/images/ChooseSeatImg/seat.png";
                        piao = piao.replace(zuowei, "");
                        $('.seatCheckInfo').html(piao);
                        //删除数组中指定元素
                        vm.SeatIDarray.splice($.inArray(SeatID, vm.SeatIDarray), 1);

                    }

                }
            }

        })

        var timer = setInterval(function () {
            if (vm.SeatIDarray != null) {
                $('#Sum').html("￥" + (vm.SeatIDarray.length * Money));
            }
        }, 500);
    </script>
</asp:Content>