<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QrCodeGenerateLogin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PC扫码登录测试</title>
    <script src="Scripts/jquery-1.8.2.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Img_qrcode" AlternateText="qrcode" runat="server" />

        <asp:HiddenField ID="IsFirstLoad" runat="server" />
        <script type="text/javascript">
            //这个页面描述的是在与服务器交互中，如果服务器没有响应扫码成功的话前端会在这次请求完再次发起一次请求
            var qrcode = $("#Img_qrcode")[0].alt;
            console.log(qrcode);
            var url = "http://172.31.35.26:6060/verification.ashx";
            var authid = '1Q2W3E4R5T'; +Math.floor(Math.random() * 1000);

            var date = { "uuid": qrcode };
            $.get(url, date, auth);
            function auth(obj) {
                var json = JSON.parse(obj);
                if (json.errorcode == 408 || json.errorcode == "408") {
                    //debugger
                    $.get(url, date, auth);
                } else if (json.errorcode == 200 || json.errorcode == "200") {
                    debugger
                    location.href = 'default.aspx?uuid=' + json.qrcode;
                }
            }
        </script>

    </form>
</body>
</html>
