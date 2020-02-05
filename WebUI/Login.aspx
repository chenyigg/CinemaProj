<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>注册登录界面</title>

    <link rel="stylesheet" href="Content/bootstrap.min.css">
    <link rel="stylesheet" href="Content/LoginCss/login.css" />
    <link href="Content/easyui.css" rel="stylesheet" />
    <link href="Content/demo.css" rel="stylesheet" />
    <link href="Content/icon.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            //打开会员登录
            function login_() {
                $("#regist_container").hide();
                $("#_close").show();
                $("#_start").animate({
                    left: '350px',
                    height: '520px',
                    width: '400px'
                }, 500, function () {
                    $("#login_container").show(500);
                    $("#_close").animate({
                        height: '40px',
                        width: '40px'
                    }, 500);
                });
            };
            login_();
            //去 注册
            $("#toRegist").click(function () {
                $("#login_container").hide(500);

                $("#regist_container").show(500);
            });
            //去 登录
            $("#toLogin").click(function () {
                $("#regist_container").hide(500);
                $('#regist_account').val("");
                $('#regist_password1').val("");
                $("#login_container").show(500);
            });
        });
    </script>
</head>

<body>
    <div>
        <!-- 会员登录  -->

        <form runat="server" method="post" onkeydown="if(event.keyCode==13){return false;}">
            <div id='_start'>
                <br />
                <!--登录框-->
                <div id="login_container">
                    <div id="lab1">
                        <span id="lab_login">用户登录</span>
                        <span id="lab_toRegist">&emsp;还没有账号&nbsp;
				<span id='toRegist' style="cursor: pointer;">立即注册</span>
                        </span>
                    </div>
                    <div style="width: 330px;">
                        <span id="lab_type1">手机号/账号登录</span>
                    </div>
                    <div id="form_container1">
                        <br />
                        <input type="text" class="form-control" placeholder="账号" id="login_number" runat="server" />

                        <asp:TextBox ID="login_password" CssClass="form-control" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Button runat="server" Text="登录" CssClass="btn btn-success" ID="login_btn" OnClick="login_btn_Click" UseSubmitBehavior="false" />
                        <span id="rememberOrfindPwd">
                            <span>
                                <input id="remember" type="checkbox" style="margin-bottom: -1.5px;" runat="server">
                            </span>
                            <span style="color: #000000">记住密码&emsp;&emsp;&emsp;&emsp;
                            </span>
                            <span style="color: #000000">忘记密码
                            </span>
                        </span>
                    </div>
                </div>

                <!-- 会员注册 -->
                <div id='regist_container' style="display: none;">
                    <div id="lab1">
                        <span id="lab_login">用户注册</span>
                        <span id="lab_toLogin">&emsp;已有账号&nbsp;
				<span id='toLogin' style="cursor: pointer;">立即登录</span>
                        </span>
                    </div>
                    <div id="form_container2" style="padding-top: 25px;">

                        <input type="text" class="form-control" placeholder="账号名" id="regist_account" name="C_regist_account" required />
                        <asp:Label ID="HasUser" runat="server" Text="该账号已被注册哦！"></asp:Label>
                        <input type="password" class="form-control" placeholder="密码" id="regist_password1" name="C_regist_password1" />
                        <input type="password" class="form-control" placeholder="确认密码" id="regist_password2" />
                        <input type="text" class="form-control" name="C_regist_email" placeholder="邮箱号（QQ）" id="regist_phone" />
                        <input type="text" class="form-control" placeholder="验证码" id="regist_vcode" />
                        <input id="getVCode" type="button" class="btn btn-success" value="点击发送验证码" onclick="return sendCode(this)" />

                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>

                    <input type="submit" value="注册" class="btn btn-success" id="regist_btn" />
                </div>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="账号不可为空！" Text="&amp;nbsp;" ControlToValidate="login_number"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不可为空！" Text="&amp;nbsp;" ControlToValidate="login_password"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate">&nbsp;</asp:CustomValidator>
        </form>
        <script type="text/javascript">
            var clock = '';
            var nums = 30;
            var btn;
            var yzm = 0;
            //判断邮箱字符串
            var reg = new RegExp("^[a-z0-9]+@qq[.]com$");  //正则
            $('#HasUser').hide();

            function sendCode(thisBtn) {

                //邮箱输入正确则允许发送验证码
                if (reg.test($('#regist_phone').val())) {
                    $.post("register.ashx?action=GetEmail", { "Email": $('#regist_phone').val() }, function (data) {
                        //alert(data);
                        yzm = data; //将验证码传给客户端
                    })
                    btn = thisBtn;
                    btn.disabled = true; //将按钮置为不可点击
                    btn.value = '重新获取（' + nums + '）';
                    clock = setInterval(doLoop, 1000); //一秒执行一次
                    $('#Label1').text("请注意查收邮件哦");
                }
                else {
                    alert("邮箱格式不正确哦！");
                }
            }

            function doLoop() {
                nums--;
                if (nums > 0) {
                    btn.value = '重新获取（' + nums + '）';
                } else {
                    clearInterval(clock); //清除js定时器
                    btn.disabled = false;
                    btn.value = '点击发送验证码';
                    nums = 30; //重置时间
                    $('#Label1').text("");
                }
            }

            //判断是否有空项
            function isEmpty(obj) {
                if (typeof obj == "undefined" || obj == null || obj == "") {
                    return true;
                } else {
                    return false;
                }
            }

            //设置失焦事件，验证该用户是否被抢注
            $('#regist_account').blur(function () {
                $.post("register.ashx?action=HasUser", { UserAccount: $('#regist_account').val() }, function (data) {
                    if ($.trim(data) == "True") {
                        $('#regist_account').css("box-shadow", "inset 0px 0px 10px 3px red");
                        $('#HasUser').show();
                    } else {
                        $('#regist_account').css("box-shadow", "none");
                        $('#HasUser').hide();
                    }
                })
            })

            $('#regist_btn').click(function () {

                //$.messager.alert('My Title', '请勿留有空项哦!');
                //判断各文本框是否有空值
                var $regist_account = $('#regist_account').val();
                var $regist_password1 = $('#regist_password1').val();
                var $regist_password2 = $('#regist_password2').val();
                var $regist_phone = $('#regist_phone').val();
                var $regist_vcode = $('#regist_vcode').val();
                if (isEmpty($regist_account) || isEmpty($regist_password1) || isEmpty($regist_password2) || isEmpty($regist_phone) || isEmpty($regist_vcode)) {
                    alert("请勿留有空项哦！");

                    return false;
                } else {
                    if ($("#HasUser").is(":visible")) {
                        alert("该用户已被注册请更换用户名哦！");
                        return false;
                    }
                    else if (!($regist_password1 === $regist_password2)) {
                        alert("第一次和第二次输入的密码不一致哦！");
                        return false;
                    }
                    else if (!reg.test($regist_phone)) {
                        alert("邮箱格式不正确哦！");
                        return false;
                    }
                    else if (!($regist_vcode === yzm)) {
                        alert("验证码不正确哦！");
                        return false;
                    }

                }
            })
        </script>
    </div>
</body>
</html>