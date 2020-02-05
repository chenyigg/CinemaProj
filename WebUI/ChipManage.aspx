<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="ChipManage.aspx.cs" Inherits="WebUI.ChipManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Content/ManageCss/MovieManage/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/ManageCss/MovieManage/layout.css" rel="stylesheet" />
    <link href="Content/ManageCss/MovieManage/menu.css" rel="stylesheet" />
    <link href="Content/ManageCss/MovieManage/reset.css" rel="stylesheet" />
    <script src="Scripts/ManageJs/MovieManage/jquery-3.4.1.min.js"></script>
    <script src="Scripts/vue.js"></script>
    <script src="Scripts/ManageJs/MovieManage/bootstrap.min.js"></script>
    <style>
        #section {
            margin-left: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="section">
        <div id="head">
            <div class="tab" role="tabpanel">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">添加排片</a></li>
                    <li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">删除排片</a></li>
                    <li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">修改排片信息</a></li>
                    <li role="presentation"><a href="#Section4" aria-controls="messages" role="tab" data-toggle="tab">查询排片信息</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content tabs">
                    <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                        <p>
                            影院：
                            <select id="CinemaSelect" @change="addChipLoadCinemaChange()">
                                <option>选择要排片的影院</option>
                                <option v-for="i in Cinemalist">
                                    {{i.CinemaName}}
                                </option>
                            </select>
                        </p>

                         <p>
                             影厅：
                             <select id="OfficeSelect">
                                    <option>选择要排片的影厅</option>
                                <option  v-for="i in Officelist">
                                    {{i.OfficeName}}
                                </option>
                            </select>
                         </p>

                         <p>
                             电影：
                             <select id="MovieSelect">
                                    <option>选择要排片的电影</option>
                                <option v-for="i in Movielist">
                                    {{i.MovieName}}
                                </option>
                            </select>
                         </p>
                        <input type="datetime-local" id="chipTime">
                        <input id="sureChipBtn" @click="sureChip()"  type="button" value="确定排片" />
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section2">
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section3">
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section4">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        //初始化数据
        var vm = new Vue({
            el: "#section",
            data: {
                Cinemalist:
                    [{
                        CinemaName: ""
                    }],
                Officelist:
                    [{
                        OfficeName: ""
                    }],
                Movielist:
                    [{
                        MovieName: ""
                    }]
            },
            mounted() {
                this.addChipLoadCinema();
                this.addChipLoadMovie();
            },
            methods: {
                addChipLoadCinema() {
                    $.ajax({
                        type: "Post",
                        url: "ChipManage.aspx?Method=addChipLoadCinema",
                        dataType: "json",
                        success: function (data) {
                            //console.log("影院请求成功");
                            vm.Cinemalist = data;
                        }
                    })
                },
                addChipLoadMovie() {
                    $.ajax({
                        type: "Post",
                        url: "ChipManage.aspx?Method=addChipLoadMovie",
                        dataType: "json",
                        data: {

                        },
                        success: function (data) {
                            //alert("电影请求成功");
                            vm.Movielist = data;

                        },
                        error: function () {

                        }
                    })
                },
                addChipLoadCinemaChange() {
                    //alert($('#CinemaSelect option:selected').text());
                    $.ajax({
                        type: "Post",
                        url: "ChipManage.aspx?Method=addChipLoadCinemaChange",
                        dataType: "json",
                        data: {
                            CinemaName: $('#CinemaSelect option:selected').text(),

                        },
                        success: function (data) {
                            vm.Officelist = data;

                        },
                        error: function () {

                        }
                    })
                },
                sureChip() {
                    var $CinemaValue = $('#CinemaSelect option:selected').text();
                    var $OfficeValue = $('#OfficeSelect option:selected').text();
                    var $MovieValue = $('#MovieSelect option:selected').text();
                    var $Time = $('#chipTime').val();
                    $.ajax({
                        type: "Post",
                        url: "ChipManage.aspx?Method=sureChip",
                        dataType: "json",
                        data: {
                            CinemaName: $CinemaValue,
                            OfficeName: $OfficeValue,
                            MovieName: $MovieValue,
                            Time: $Time
                        },
                        success: function (data) {
                            if (data == "1") {
                                alert("拍片成功");
                            }
                            else {
                                alert("拍片失败");
                            }

                        },
                        error: function () {

                        }
                    })
                }
            }
        })
    </script>
</asp:Content>