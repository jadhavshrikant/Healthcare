<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotificationUserControl.ascx.cs" Inherits="Healthcare.Web.UserControls.NotificationUserControl" %>

<div id="dvSuccess" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
    <asp:Label ID="lblSuccessMessage" runat="server">Success</asp:Label>
</div>
<div id="dvInfo" runat="server" class="alert alert-info alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
    <asp:Label ID="lblInfoMessage" runat="server">Info</asp:Label>
</div>
<div id="dvWarning" runat="server" class="alert alert-warning alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
    <asp:Label ID="lblWarningMessage" runat="server">Warning</asp:Label>
</div>
<div id="dvError" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
    <asp:Label ID="lblErrorMessage" runat="server">Error</asp:Label>
</div>

