<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationUserControl.ascx.cs" Inherits="Healthcare.Web.UserControls.NavigationUserControl" %>

<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <div class="navbar-header">
        <a class="navbar-brand" href="../Dashboard.aspx">Healthcare Inc.</a>
    </div>
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
    </button>
    <ul class="nav navbar-nav navbar-left navbar-top-links">
        <li><a href="../Dashboard.aspx"><i class="fa fa-home fa-fw"></i>Home</a></li>
    </ul>
    <ul class="nav navbar-right navbar-top-links">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="fa fa-user fa-fw"></i><%: Convert.ToString(HttpContext.Current.Session["FullName"]) %> <b class="caret"></b>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <a href="javascript:void(0);"><i class="fa fa-gear fa-fw"></i>Change Password</a>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx"><i class="fa fa-sign-out fa-fw"></i>Logout</asp:HyperLink>
                </li>
            </ul>
        </li>
    </ul>
    <!-- /.navbar-top-links -->
    <div class="navbar-default sidebar" role="navigation">
        <div class="sidebar-nav navbar-collapse">
            <ul class="nav" id="side-menu">
                <li>
                    <asp:HyperLink ID="hlDashboard" runat="server" NavigateUrl="~/Dashboard.aspx" CssClass="active"><i class="fa fa-dashboard fa-fw"></i>Dashboard</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlManagePatient" runat="server" NavigateUrl="~/ManagePatient/PatientList.aspx"><i class="fa fa-table fa-fw"></i>Manage Patient</asp:HyperLink>
                </li>
            </ul>
        </div>
    </div>
</nav>
