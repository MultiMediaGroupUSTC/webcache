<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="imgItem.ascx.cs" Inherits="My_Retrieval_Page.imgItem" %>
<link rel="style sheet" type="text/css" href="contents.css" />
<div style="width: 220px; height: 180px; float: left; padding-bottom: 20px;">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div>
                    <asp:ImageButton Width="200" Height="150" runat="server" ID="imgCtrl" CssClass="imgCtrlStyle" 
                        Enabled="true" OnClick="Click_image" />
                    <div class="imgItemStyle">
                    <asp:Label ID="SegmentLabel" runat="server"></asp:Label>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</div>

