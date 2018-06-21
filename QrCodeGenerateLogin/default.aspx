<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="QrCodeGenerateLogin._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录成功</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            欢迎您：<asp:Label ID="lab_msg" runat="server" Text=""></asp:Label>
        </div>
         <asp:Image ID="img_user"  runat="server" />
    </form>
</body>
</html>
