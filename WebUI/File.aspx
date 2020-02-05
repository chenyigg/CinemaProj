<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="File.aspx.cs" Inherits="WebUI.File" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="jquery.min.js"></script>
    <link rel="stylesheet" href="Content/MovieCss/movie.css">
    <link rel="stylesheet" href="Scripts/MovieJs/movie.js">
    <link rel="stylesheet" href="Content/MovieCss/layout.css">
    <link rel="stylesheet" href="Content/MovieCss/reset.css">
    <link href="Content/easyui.css" rel="stylesheet" />
    <link href="Content/icon.css" rel="stylesheet" />
    <link href="Content/demo.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/MovieCss/htmleaf-demo.css">
    <link rel="stylesheet" type="text/css" href="Content/MovieCss/pretty.min.css">
    <link rel="stylesheet" type="text/css" href="Content/MovieCss/xuanxiangka.css">
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <script src="Scripts/MovieJs/jquery-3.4.1.min.js"></script>
    <script src="Scripts/MovieJs/movie.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/vue.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div id="movie_content">
        <div style="margin-top: 100px">
            <div class="htmleaf-container mt">
                <div class="tab" role="tabpanel">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li @click="zjry" role="presentation" class="active"><a href="#Section1" aria-controls="home" role="tab" data-toggle="tab">正在热映</a></li>
                        <li @click="jjsy" role="presentation"><a href="#Section2" aria-controls="profile" role="tab" data-toggle="tab">即将上映</a></li>
                        <li @click="jddy" role="presentation"><a href="#Section3" aria-controls="messages" role="tab" data-toggle="tab">经典电影</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content tabs">
                        <div role="tabpanel" class="tab-pane fade in active" id="Section1">
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="Section2">
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="Section3">
                        </div>
                    </div>
                </div>
                <div class="movie_content_type">
                    <span class="tags-title">类型 :</span>
                    <ul class="tags">
                        <li class="SaixuanActive1">
                            <span class="movie_content_type_item">全部</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">爱情</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">喜剧</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">动画</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">剧情</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">恐怖</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">惊悚</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">科幻</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">动作</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">悬疑</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">犯罪</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">冒险</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">战争</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">奇幻</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">运动</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">家庭</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">古装</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">武侠</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">西部</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">历史</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">传记</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">歌舞</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">黑色电影</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">短片</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">纪录片</span>
                        </li>
                        <li>
                            <span class="movie_content_type_item">其他</span>
                        </li>
                    </ul>
                </div>
                <div class="movie_content_area">
                    <span class="tags-title">区域 :</span>
                    <ul class="tags">
                        <li class="SaixuanActive2">
                            <span class="movie_content_area_item">全部</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">大陆</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">美国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">韩国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">日本</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">中国香港</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">中国台湾</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">泰国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">印度</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">法国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">英国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">俄罗斯</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">意大利</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">西班牙</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">德国</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">波兰</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">澳大利亚</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">伊朗</span>
                        </li>
                        <li>
                            <span class="movie_content_area_item">其他</span>
                        </li>
                    </ul>
                </div>
                <div class="movie_content_years">
                    <span class="tags-title">年代 :</span>
                    <ul class="tags">
                        <li class="SaixuanActive3">
                            <span class="movie_content_years_item">全部</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2019</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2018</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2017</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2016</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2015</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2014</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2013</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2012</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2011</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2010</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2009</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2008</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">2007</span>
                        </li>
                        <li>
                            <span class="movie_content_years_item">更早</span>
                        </li>
                    </ul>
                </div>
            </div>
            <div id="movie_list">
                <div id="movie_list_form pretty">
                    <div class="pretty primary">
                 <%--       <input class="Sradio" type="radio" name="radio18">
                        <label><i class="default"></i>按热门排序</label>
                    </div>
                    <div class="pretty success">
                        <input class="Sradio" type="radio" name="radio18">
                        <label><i class="default"></i>按时间排序</label>
                    </div>
                    <div class="pretty info">
                        <input class="Sradio" type="radio" name="radio18">
                        <label><i class="default"></i>按评价排序</label>
                    </div>--%>
                </div>

                <div id="movie_list_body">
                    <div class="movie_list_body_item" v-for="i in List">
                        <dl>
                            <dt style="height:230px">
                                <a :href="'Details.aspx?MovieID='+i.MovieID" style="width:100%">
                                    <img :src="'images/MovieCover/'+i.MovieCover" :title="i.MovieName"
                                        style="width:100%;height:230px; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                                </a>
                            </dt>
                            <dd>
                                <a href="#" id="namesss" v-cloak style="font-size:16px;font-weight:bold;">
                                    {{i.MovieName}}
                                </a>
                            </dd>
                            <dd class="movie_list_body_item_pingfen" v-cloak style="font-weight:bold;">
                                {{i.MovieScore}}
                            </dd>
                        </dl>
                    </div>
                    <div class="content_Page">
                        <span class="Page_text">当前为第<strong style="color:red">{{PageNow}}</strong>页，总页数<strong
                                style="color:red">{{PageCount}}</strong>页</span>

                        <input type="button" value="首页" @click="FirstCommentInfo" />
                        <input type="button" value="<<" @click="PrevCommentInfo" />

                        <input type="button" value=">>" @click="NextCommentInfo" />
                        <input type="button" value="末页" @click="EndCommentInfo" />
                    </div>
                </div>
            </div>
        </div>
    </div>
       </div>
    <script>
        //初始化数据
        var vm1 = new Vue({
            el: "#movie_content",
            data: {
                PageNow: "",
                PageCount: "",
                List: [{
                    MovieCover: "",
                    MovieName: "",
                    MovieScore: "",
                    MovieID: ""
                }]
            },
            mounted() {
                this.loadMovieInfo();
            },
            methods: {
                //返回当前页及总页数
                getPage() {
                    $.ajax({
                        url: "File.aspx?Method=GetPageInfo",
                        type: "post",
                        dataType: "json",
                        success: function (datainfo) {
                            vm1.PageNow = datainfo.PageNow;
                            vm1.PageCount = datainfo.PageCount;
                        }
                    })
                },
                //页面加载时分页
                loadMovieInfo() {
                    var _this = this;
                    $.ajax({
                        type: "Post",
                        url: "File.aspx?Method=loadMovieInfo",
                        data: {
                            MovieType: $('.SaixuanActive1').children('span').html(),
                            MovieArea: $('.SaixuanActive2').children('span').html(),
                            MovieYears: $('.SaixuanActive3').children('span').html(),
                        },
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            _this.List = data;
                            _this.$options.methods.getPage();
                        }
                    });
                },
                //通过点击筛选
                saixuan() {
                    //当前元素
                    var $type = $(arguments[0]).children('span').html();
                    var $area = $(arguments[1]).children('span').html();
                    var $years = $(arguments[2]).children('span').html();

                    $.ajax({
                        type: "Post",
                        url: "File.aspx?Method=typeChange",
                        data: {
                            type: $type,
                            area: $area,
                            years: $years
                        },
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            vm1.List = null;
                            vm1.List = data;
                        }
                    });
                },
                //首页电影
                FirstCommentInfo() {
                    if (vm1.PageNow == 0) {
                        $.messager.alert("提示", "当前无信息！", "error");
                        return;
                    }
                    if (vm1.PageNow === 1) {
                        $.messager.alert("提示", "已经是第一页了哦", "Info");
                        return;
                    }
                    $.ajax({
                        url: "File.aspx?Method=FirstPageMovieInfo",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                },
                //末页电影
                EndCommentInfo() {
                    if (vm1.PageNow == 0) {
                        $.messager.alert("提示", "当前无信息！", "error");
                        return;
                    }
                    if (vm1.PageNow === vm1.PageCount) {
                        $.messager.alert("提示", "已经是最后一页了哦", "Info");
                        return;
                    }
                    $.ajax({
                        url: "File.aspx?Method=EndPageMovieInfo",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                },
                //上一页电影
                PrevCommentInfo() {
                    if (vm1.PageNow == 0) {
                        $.messager.alert("提示", "当前无信息！", "error");
                        return;
                    }
                    if (vm1.PageNow === 1) {
                        $.messager.alert("提示", "已经是第一页了哦", "Info");
                        return;
                    }
                    $.ajax({
                        url: "File.aspx?Method=PrevPageMovieInfo",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                },
                //下一页电影
                NextCommentInfo() {
                    if (vm1.PageNow == 0) {
                        $.messager.alert("提示", "当前无信息！", "error");
                        return;
                    }
                    if (vm1.PageNow === vm1.PageCount) {
                        $.messager.alert("提示", "已经是最后一页了哦", "Info");
                        return;
                    }
                    $.ajax({
                        url: "File.aspx?Method=NextPageMovieInfo",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                },
                zjry() {
                    this.loadMovieInfo();
                },
                jjsy() {
                    $.ajax({
                        url: "File.aspx?Method=jjsy",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                },
                jddy() {
                    $.ajax({
                        url: "File.aspx?Method=jddy",
                        dataType: "json",
                        success: function (data) {
                            vm1.List = data;
                            vm1.$options.methods.getPage();
                        }
                    })
                }
            }
        })
    </script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
</asp:Content>