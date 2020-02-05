<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="MovieManage.aspx.cs" Inherits="WebUI.MovieManage" %>

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

        .addMoviePhoto {
            border: 1px solid black;
            text-align: center;
        }

        .photoBox {
            margin: auto auto;
            width: 210px;
            height: 250px;
            border: 1px solid black;
        }

        .addMovieInfo, .updatephotoBox {
            border: 1px solid black;
            height: 250px;
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="section">
        <div id="head">
            <div class="tab" role="tabpanel">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">添加电影</a></li>
                    <%--<li role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">删除电影</a></li>--%>
                    <li role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">修改电影信息</a></li>
                    <li role="presentation"><a href="#Section4" aria-controls="messages" role="tab" data-toggle="tab">查询电影信息</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content tabs">
                    <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                        <div class="row">
                            <div class="addMoviePhoto col-4">
                                <div class="photoBox">
                                    <img id="img" src="" alt="" style="height: 250px; width: 210px">
                                </div>
                                <asp:FileUpload ID="FileUpload1" runat="server" onchange="upImg(this)" />
                            </div>
                            <div class="addMovieInfo col-6">
                                <p>
                                    电影名:
                                    <input type="text" name="MovieName" placeholder="电影名">
                                </p>
                                <p>
                                    电影介绍:
                                    <input type="text" name="MovieBrief" placeholder="电影介绍">
                                </p>
                                <p>
                                    票价:
                                    <input type="text" name="MovieMoney" placeholder="票价">
                                </p>
                                <p>
                                    上映时间:
                                    <input type="date" name="MovieReleaseDate">
                                </p>
                                <p>
                                    时长:
                                    <input type="text" name="MovieDuration" placeholder="时长">
                                </p>
                                <p>
                                    导演:
                                    <input type="text" name="MovieDirect" placeholder="导演">
                                </p>
                                <p>
                                    电影类型:
                                    <input type="text" name="MovieType" placeholder="电影类型">
                                </p>
                                <p>
                                    电影区域:
                                    <input type="text" name="MovieArea" placeholder="电影区域">
                                </p>
                                <p>
                                    电影年代:
                                    <input type="text" name="MovieYears" placeholder="电影年代">
                                </p>
                                <p>
                                    评分:
                                    <input type="text" name="MovieScore" placeholder="评分">
                                </p>
                                <p>
                                    演员:
                                    <input type="text" name="MoviePeople" placeholder="演员">
                                </p>
                                <p>
                                    <input type="submit" value="确定添加" id="addBtn" runat="server" onserverclick="addBtn_ServerClick">
                                </p>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section2">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>

                        <input type="button" value="确定删除" id="deleteMovie" runat="server" onserverclick="deleteMovie_ServerClick1" />
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section3">
                        <div class="row">
                            <div class="updateMoviePhoto col-4">
                                <div class="updatephotoBox">
                                    <img src="images/MovieCover/<%=model.MovieCover %>" alt="">
                                </div>
                                <input type="button" value="点击上传图片">
                            </div>
                            <div class="updateMovieInfo col-6">
                                <p>
                                    电影名:
                                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                                </p>
                                <p>
                                    电影介绍:
                                    <input type="text" placeholder="电影介绍" value="<%=model.MovieBrief %>">
                                </p>
                                <p>
                                    票价:
                                    <input type="text" placeholder="票价" value="<%=model.MovieMoney %>">
                                </p>
                                <p>
                                    上映时间:
                                    <input type="date">
                                </p>
                                <p>
                                    时长:
                                    <input type="text" placeholder="时长" value="<%=model.MovieDuration %>">
                                </p>
                                <p>
                                    导演:
                                    <input type="text" placeholder="导演" value="<%=model.MovieDirect %>">
                                </p>
                                <p>
                                    电影类型:
                                    <input type="text" placeholder="电影类型" value="<%=model.MovieType%>" />
                                <p>
                                <p>
                                    电影区域:
                                    <input type="text" placeholder="电影区域" value="<%=model.MovieArea %>">
                                </p>
                                <p>
                                    电影年代:
                                    <input type="text" placeholder="电影年代" value="<%=model.MovieYears %>">
                                </p>
                                <p>
                                    评分:
                                    <input type="text" placeholder="评分" value="<%=model.MovieScore %>">
                                </p>
                                <p>
                                    演员:
                                    <input type="text" placeholder="演员" value="<%=model.MoviePeople %>">
                                </p>
                                <p>
                                    <input type="button" id="SureUpdate" value="确定修改">
                                </p>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="Section4">
                        <input type="text" id="selectTextbox" placeholder="请输入要查询的电影">
                        <input type="button" value="查询" id="selectAllMovieBtn" @click="selectAllMovieBtnClick">
                        <table border="1">
                            <tr v-for="i in List">
                                <td>电影名：{{i.MovieName}}</td>
                                <td>票价：{{i.MovieMoney}}</td>
                                <td>日期：{{i.MovieReleaseDate}}</td>
                                <td>时长：{{i.MovieDuration}}</td>
                                <td>导演：{{i.MovieDirect}}</td>
                                <td>类型：{{i.MovieType}}</td>
                                <td>区域：{{i.MovieArea}}</td>
                                <td>年代：{{i.MovieYears}}</td>
                                <td>评分：{{i.MovieScore}}</td>
                                <td>演员：{{i.MoviePeople}}</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        $(function () {
            $('#ContentPlaceHolder1_DropDownList2').change(function () {

                var $selectMovie = $('#ContentPlaceHolder1_DropDownList2 option:selected').text();
                //alert($selectMovie);
                $.ajax({
                    type: "Post",
                    url: "MovieManage.aspx?Method=updateMovie",
                    data:
                    {
                        selectMovie: $selectMovie
                    },
                    success: function (data) {
                        var data = JSON.parse(data);
                        $('.updatephotoBox img').attr("src", "images/MovieCover/" + data.MovieCover);
                        $('.updateMovieInfo input:eq(0)').val(data.MovieBrief);
                        $('.updateMovieInfo input:eq(1)').val(data.MovieMoney);
                        $('.updateMovieInfo input:eq(2)').val(data.MovieBrief);
                        $('.updateMovieInfo input:eq(3)').val(data.MovieDuration);
                        $('.updateMovieInfo input:eq(4)').val(data.MovieDirect);
                        $('.updateMovieInfo input:eq(5)').val(data.MovieType);
                        $('.updateMovieInfo input:eq(6)').val(data.MovieArea);
                        $('.updateMovieInfo input:eq(7)').val(data.MovieYears);
                        $('.updateMovieInfo input:eq(8)').val(data.MovieScore);
                        $('.updateMovieInfo input:eq(9)').val(data.MoviePeople);
                    }
                })
            }),
                $('#SureUpdate').click(function () {
                    $.ajax({
                        type: "Post",
                        url: "MovieManage.aspx?Method=SureUpdate",
                        data:
                        {
                            MovieName: $('#ContentPlaceHolder1_DropDownList2 option:selected').html(),
                            MovieCover: $('.updatephotoBox img').attr("src").substring($('.updatephotoBox img').attr("src").lastIndexOf('/') + 1),
                            MovieBrief: $('.updateMovieInfo input:eq(0)').val(),
                            MovieMoney: $('.updateMovieInfo input:eq(1)').val(),

                            MovieReleaseDate: $('.updateMovieInfo input:eq(2)').val(),
                            MovieDuration: $('.updateMovieInfo input:eq(3)').val(),
                            MovieDirect: $('.updateMovieInfo input:eq(4)').val(),
                            MovieType: $('.updateMovieInfo input:eq(5)').val(),
                            MovieArea: $('.updateMovieInfo input:eq(6)').val(),
                            MovieYears: $('.updateMovieInfo input:eq(7)').val(),
                            MovieScore: $('.updateMovieInfo input:eq(8)').val(),
                            MoviePeople: $('.updateMovieInfo input:eq(9)').val()
                        },
                        success: function (data) {
                            alert(data);
                        }
                    })
                })

        })
        //查询电影方法
        var vm = new Vue({
            el: "#Section4",
            data: {
                List: [{
                    MovieName: "",
                    MovieBrief: "",
                    MovieMoney: "",
                    MovieReleaseDate: "",
                    MovieDuration: "",
                    MovieDirect: "",
                    MovieType: "",
                    MovieArea: "",
                    MovieYears: "",
                    MovieScore: "",
                    MoviePeople: ""
                }]
            },
            mounted() {

                //$('#selectAllMovieBtn').click(this.selectAllMovieBtnClick())
            },
            methods:
            {
                selectAllMovieBtnClick() {
                    //alert("进入查询方法");
                    $.ajax({
                        type: "Post",
                        url: "MovieManage.aspx?Method=selectMovie",
                        data:
                        {
                            textbox: $('#selectTextbox').val()
                        },
                        success: function (data) {
                            vm.List = JSON.parse(data);
                            //alert(vm.List);
                        }
                    })
                }
            }
        })

        function upImg(file) {
            if (file.files[0]) {
                var reader = new FileReader(0);
                reader.readAsDataURL(file.files[0]);
                reader.onload = function (a) {
                    document.getElementById("img").src = a.target.result;
                }
            }
        }
    </script>
</asp:Content>