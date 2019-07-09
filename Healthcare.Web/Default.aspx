<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Healthcare.Web._Default" %>

<%@ Register Src="~/UserControls/NotificationUserControl.ascx" TagPrefix="ucNotification" TagName="Notification" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel">
                    <ucNotification:Notification ID="ucNotification" runat="server" />
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control" ValidationGroup="loginForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ValidationGroup="loginForm" ErrorMessage="Please enter Username" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" ValidationGroup="loginForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="loginForm" ErrorMessage="Please enter Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-lg btn-success btn-block" ValidationGroup="loginForm" OnClick="btnLogin_Click" />
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
