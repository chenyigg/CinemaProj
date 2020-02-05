$(function () {
    //创建实例
    var vm = new Vue({
        el: '#contentbt',
        data: {
            PageNow: "",
            PageCount: "",
            List: [{ CommentID: "", UsersID: "", UserName: "", UserFace: "", CommentInfo: "", CommentTime: "", MovieID: "", }]
        },
        mounted() {
            this.load();
        },
        methods: {
            //返回当前页及总页数
            getPage() {
                $.ajax(
                    {
                        url: "Details.aspx?Method=GetPageInfo",
                        type: "post",
                        dataType: "json",
                        success: function (datainfo) {
                            vm.PageNow = datainfo.PageNow;
                            vm.PageCount = datainfo.PageCount;
                        }
                    }
                )
            },
            //插入评论
            BtnSayClick() {
                if ($('#txtSee').val().length == 0 || $('#txtSee').val() == "") {
                    return;
                }
                var timer = new Date();
                var year = timer.getFullYear() + "/";
                var month = timer.getMonth() + 1 + "/";
                var day = timer.getDate();
                var str = year + month + day;

                //alert(str);
                $.ajax(
                    {
                        url: "Details.aspx?Method=BtnSayClick",
                        type: "post",
                        data: { CommentInfo: $('#txtSee').val(), CommentTime: str, MovieID: $('#imgone').attr("title") },
                        dataType: "json",
                        success: function (datainfo) {
                            if (datainfo.state == "false") {
                                $.messager.alert('提示', '插入失败', 'error');
                                $('#txtSee').val("");
                            }
                            else {
                                $.messager.alert('提示', '插入成功', 'info');
                                vm.List = datainfo;
                                vm.$options.methods.getPage();
                                $('#txtSee').val("");
                            }
                        }
                    }
                )
            }
            ,
            //加载评论
            load() {
                $.ajax(
                    {
                        url: "Details.aspx?Method=SelectCommentInfo",
                        type: "post",
                        data: { MovieID: $('#imgone').attr("title") },
                        dataType: "json",
                        success: function (datainfo) {
                            vm.List = datainfo;
                            vm.$options.methods.getPage();
                        }
                    }
                )
            },
            //首页评论
            FirstCommentInfo() {
                if (vm.PageNow == 0) {
                    $.messager.alert("提示", "当前无信息！", "error");
                    return;
                }
                if (vm.PageNow === 1) {
                    $.messager.alert("提示", "已经是第一页了哦", "Info");
                    return;
                }
                $.ajax({
                    url: "Details.aspx?Method=FirstCommentInfo",
                    data: { MovieID: $('#imgone').attr("title") },
                    dataType: "json",
                    success: function (data) {
                        vm.List = data;
                        vm.$options.methods.getPage();
                    }
                })
            },
            //末页评论
            EndCommentInfo() {
                if (vm.PageNow == 0) {
                    $.messager.alert("提示", "当前无信息！", "error");
                    return;
                }
                if (vm.PageNow === vm.PageCount) {
                    $.messager.alert("提示", "已经是最后一页了哦", "Info");
                    return;
                }
                $.ajax({
                    url: "Details.aspx?Method=EndCommentInfo",
                    data: { MovieID: $('#imgone').attr("title") },
                    dataType: "json",
                    success: function (data) {
                        vm.List = data;
                        vm.$options.methods.getPage();
                    }
                })
            },
            //上一页评论
            PrevCommentInfo() {
                if (vm.PageNow == 0) {
                    $.messager.alert("提示", "当前无信息！", "error");
                    return;
                }
                if (vm.PageNow === 1) {
                    $.messager.alert("提示", "已经是第一页了哦", "Info");
                    return;
                }
                $.ajax({
                    url: "Details.aspx?Method=PrevCommentInfo",
                    data: { MovieID: $('#imgone').attr("title") },
                    dataType: "json",
                    success: function (data) {
                        vm.List = data;
                        vm.$options.methods.getPage();
                    }
                })
            },
            //下一页评论
            NextCommentInfo() {
                if (vm.PageNow == 0) {
                    $.messager.alert("提示", "当前无信息！", "error");
                    return;
                }
                if (vm.PageNow === vm.PageCount) {
                    $.messager.alert("提示", "已经是最后一页了哦", "Info");
                    return;
                }
                $.ajax({
                    url: "Details.aspx?Method=NextCommentInfo",
                    data: { MovieID: $('#imgone').attr("title") },
                    dataType: "json",
                    success: function (data) {
                        vm.List = data;
                        vm.$options.methods.getPage();
                    }
                })
            }
        }
    })

    $('#btnSay').mouseenter(function () {
        $(this).css("cursor", "pointer");
    });
    $('#txtSee').focus(function () {
        $(this).attr("placeholder", "");
        $(this).css("border", "1px solid red");
    });
    $('#txtSee').blur(function () {
        $(this).attr("placeholder", "我也想评论");
        $(this).css("border", "1px solid black");
    });
})