<%@ Page Title="" Language="C#" MasterPageFile="~/TopSite.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebUI.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/UserCss/normalize.css" />
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.2.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/UserCss/demo.css" />
    <link rel="stylesheet" type="text/css" href="Content/UserCss/component.css" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/UserJs/classie.js"></script>
    <script src="Scripts/UserJs/Regex.js"></script>
    <meta name="referrer" content="no-referrer" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="content">
            <img src="" id="serverImg" runat="server" alt="头像" style="left: 100px; top: 190px; width: 300px; height: 300px; border: 1px solid black; position: absolute;" />
            <asp:FileUpload ID="FileUpload1" runat="server" href="javascript:void(0);" Style="left: 100px; top: 490px; position: absolute;" BorderStyle="None" ClientIDMode="Static" />

            <span class="input input--hoshi">
                <label class="sss">Name</label>
                <input class="input__field input__field--hoshi Info" type="text" name="UserName" id="input_1" value='<%=UserName %>' required />
                <label class="input__label input__label--hoshi input__label--hoshi-color-1" for="input_1">
                    <span class="input__label-content input__label-content--hoshi" style="font-size: 19px;">Name</span>
                </label>
            </span><span class="form_hint error">请输入正确的中/英文格式哦</span><br />

            <span class="input input--hoshi">
                <label class="sss">Sex</label>
                <input class="input__field input__field--hoshi Info" type="text" name="UserSex" value='<%=UserSex %>' id="input_2" required />
                <label class="input__label input__label--hoshi input__label--hoshi-color-2" for="input_2">
                    <span class="input__label-content input__label-content--hoshi" style="font-size: 19px;">Sex</span>
                </label>
            </span><span class="form_hint error">请输入男/女哦</span><br />

            <span class="input input--hoshi">
                <label class="sss">Tel</label>
                <input class="input__field input__field--hoshi Info" type="text" name="UserPhone" value='<%=UserPhone %>' id="input_3" required />
                <label class="input__label input__label--hoshi input__label--hoshi-color-3" for="input_3">
                    <span class="input__label-content input__label-content--hoshi" style="font-size: 19px;">Tel</span>
                </label>
            </span><span class="form_hint error">请输入正确的电话格式</span><br />

            <span class="input input--hoshi">
                <label class="sss">IDCard</label>
                <input class="input__field input__field--hoshi Info" type="text" name="UserIDCard" value='<%=UserIDCard %>' id="input_4" required />
                <label class="input__label input__label--hoshi input__label--hoshi-color-2" for="input_4">
                    <span class="input__label-content input__label-content--hoshi" style="font-size: 19px;">IDCard</span>
                </label>
            </span><span class="form_hint error">请输入正确的身份证格式</span><br />

            <span class="input input--hoshi">
                <label class="sss">Address</label>
                <input class="input__field input__field--hoshi Info" type="text" name="UserAddress" value='<%=UserAddress %>' id="input_5" required />
                <label class="input__label input__label--hoshi input__label--hoshi-color-2" for="input_5">
                    <span class="input__label-content input__label-content--hoshi" style="font-size: 19px;">Address</span>
                </label>
            </span><span class="form_hint error">请勿输入非法字符</span><br />

            <span class="input input--hoshi">
                <input class="input__field input__field--hoshi button large round white" value="提交" type="submit" id="input-6" />
            </span>

            <p style="margin-top: -20px;">
                感谢您对自身资料的完善
                    <a href="Default.aspx">Return Default</a>
            </p>
        </section>
    </div>
</asp:Content>