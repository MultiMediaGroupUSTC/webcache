<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imgDisplay.aspx.cs" Inherits="My_Retrieval_Page.imgDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left; margin-left:10px">
        <asp:Image ID="ImgDis" runat="server" ImageUrl="~/images/x.jpg" ImageAlign="left"/>
        <asp:TextBox ID="ImageInfor" runat="server" style="text-align:left" TextMode="MultiLine" Width="300" Height="250"></asp:TextBox>
    </div>
    </form>
</body>
</html>
