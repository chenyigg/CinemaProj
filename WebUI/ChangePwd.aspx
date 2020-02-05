<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="WebUI.ChangePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改密码</title>
    <link href="Content/easyui.css" rel="stylesheet" />
    <link href="Content/icon.css" rel="stylesheet" />
    <link href="Content/demo.css" rel="stylesheet" />
    <link href="Content/ChangePwdCss/ChangePwd.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/ChangePwdJs/ChangePwd.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section id="forgetPwd_Body">
            <div class="forgetPwd_Body_header">
                修改密码
            </div>
            <div class="forgetPwd_Body_input">
                <input id="OldPwd" type="password" placeholder="请输入旧密码" class="form-control " required="required">
                <input id="NewPwd1" type="password " placeholder="请输入新密码" class="form-control btn1" name="New" required="">
                <input id="NewPwd2" type="password" placeholder="请确认新密码 " class="form-control btn2" required="">
                <input id="forgetPwd_Body_btn" type="submit" value="确定" class="form-btn">
            </div>
        </section>
    </form>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
</body>
</html>