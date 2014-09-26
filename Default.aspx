<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="My_Retrieval_Page.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to visit the demo</title>
</head>
<body oncontextmenu="return false;" style="width:700px;margin: 0 auto;">
    <img src="multimedia.jpg" width="700" height="150" />
    <div style="text-align:center; margin-top:80px; padding-bottom:20px;">
        <h1>CBIR and Image Aesthetics</h1>
    </div>
        <p style=font-size:18px;>　　Unlike traditional CBIR system which only considers the relevance between returned images and the given query,
         we also care for the aesthetic quality of the returned images.</p>
        <form id="form1" runat="server">
            <!--
            <div>
                <asp:TextBox ID="AddUserName" runat="server"></asp:TextBox>
                <asp:Button ID="btnPath" Text="To Label now!" runat="server" align="center" />
            </div>
            <hr />
            -->
            <h2>Reference:</h2>
            <div style="font-size: 14pt">
                <div>
                    <asp:Image runat="server" ID="BoundImg" ImageUrl="~/Example.jpg" ImageAlign="Middle" width="700" height="136" />
                </div>

                <p style=font-size:18px;>　　As reported in a user investigation in 2011, popular image retrieval systems just considered the relevance regardless of
                the image quality. This could not satisfy the users. Those systems now take the image aesthetics as an important part that should be considered. An
                example is followed.</p>
                <div>
                
                    <asp:Image runat="server" ID="BestImg" ImageUrl="~/AesthSystem.jpg" ImageAlign="Middle" width="500" height="207"/> 
                <!--
                     此处也可以用纯Html语言,<img src="1.jpg" width="104" height="142" /> 

                    <p>Please choose <a style="color: #f00;">3~6</a> best photos per event if possible. </p>

                    -->

                </div>
            </div>
            <asp:HyperLink ID="HyperLink1" runat="server" Text="Begin Now!" NavigateUrl="~/mainpage.aspx" Font-Underline="false"></asp:HyperLink>
        </form>
    <div>
    </div>
</body>
</html>
