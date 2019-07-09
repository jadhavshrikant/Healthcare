<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Healthcare.Web.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap Core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="Content/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="Content/startmin.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="Content/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom Errors -->
    <link href="Content/custom-error.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="error-template">
                        <h1>Oops!</h1>
                        <h2>404 Not Found</h2>
                        <div class="error-details">
                            Sorry, an error has occured, Requested page not found!
                        </div>
                        <div class="error-actions">
                            <asp:HyperLink ID="hlHomeLink" runat="server" CssClass="btn btn-primary btn-lg" NavigateUrl="~/Dashboard.aspx"><span class="glyphicon glyphicon-home"></span>Take Me Home</asp:HyperLink>
                            <asp:HyperLink ID="hlContactSupport" runat="server" CssClass="btn btn-default btn-lg"><span class="glyphicon glyphicon-envelope"></span>Contact Support</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
