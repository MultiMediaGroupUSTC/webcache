<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read Me.aspx.cs" Inherits="My_Retrieval_Page.Read_Me" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Read me</title>
</head>
<body oncontextmenu="return false;" style="width:700px;margin: 0 auto;">
    <div style="text-align:center; margin-top:100px; padding-bottom:20px;">
        <h1>Segmentation Complete!</h1>
        <h1>Thanks for your cooperation.</h1>
    </div>
    <div style="text-align:center;  padding-bottom:20px;">
        <form id="form1" runat="server" style="">
            <asp:HyperLink runat="server" Text="Return to the main page" NavigateUrl="~/Default.aspx" Font-Underline="false"></asp:HyperLink>
        </form>
    </div>
</body>
</html>
