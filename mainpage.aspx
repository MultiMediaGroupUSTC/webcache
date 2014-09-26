<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainpage.aspx.cs" Inherits="My_Retrieval_Page.mainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head id="Head1" runat="server">
    <title>Adaptive Image Aesthetics</title>
</head>

<body style="margin: 0 auto; width: 1120px; text-align: center; margin-top: 20px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h1>Adaptive Image Aesthetics</h1>
        <hr />

        <div style="float:left; margin-left:10px">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/2.jpg" Width="200" Height="150" ImageAlign="left"/>
                <div style="margin-top: 10px; margin-left:10px">
                <input id="InputFile" style="width: 399px; margin-left:10px" type="file" runat="server" />
                <asp:Button ID="FileUpload_Button" runat="server" Text="Upload the Image" OnClick="FileUpload_Button_Click" />
                </div>
                <div  style="float:left; margin-top: 20px; margin-left:10px ">
                <asp:TextBox ID="AesthQuality" runat="server" Width="100px" style="text-align:center"></asp:TextBox>
                <asp:Button ID="Retrieval" runat="server" Text="Retrieval" OnClick="Retrieval_Click" />
                <asp:Button ID="GetQuality" runat="server" Text="Assess" OnClick="Assess_Click" />
                </div>
        </div>

        <asp:Image ID="Image2" runat="server" ImageUrl="~/Back.jpg" Width="1120" Height="20" ImageAlign="left"/>

        <div style="padding-top: 20px; padding-bottom: 20px;">
            <asp:Panel runat="server" ID="imgPanel">
            </asp:Panel>
        </div>
        <div style="clear: both;"></div>
        <div style="padding-bottom: 20px;">
            <asp:TextBox ID="GoToPage" runat="server" Width="30px"></asp:TextBox>
            <asp:Button ID="btnGoToPage" Text="Go" OnClick="btn_GoClick" runat="server" />
            <asp:Button ID="btnForward" Text="Previous" OnClick="btnForward_Click" runat="server" />
            <asp:Button ID="btnFinish" Text="Next" OnClick="btnNext_Click" runat="server" />
        </div>
    </form>
    <br />
    <br />
</body>
</html>
