<%@ Page Title="Patient List" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="Healthcare.Web.ManagePatient.PatientList" %>

<%@ Register Src="~/UserControls/NotificationUserControl.ascx" TagPrefix="ucNotification" TagName="Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <ucNotification:Notification ID="ucNotification" runat="server" />
            </div>
            <div class="col-lg-12">
                <h1 class="page-header">Manage Patient</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <span class="text-left col-lg-11">Patient List 
                        </span>
                        <span class="text-right">
                            <asp:HyperLink ID="hlAddPatient" runat="server" Text="Add Patient" CssClass="btn btn-primary btn-xs" NavigateUrl="~/ManagePatient/UpsertPatientDetail.aspx"></asp:HyperLink>
                        </span>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:GridView ID="gvPatientList" runat="server" DataKeyNames="PatientId" CssClass="table table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPatientList_PageIndexChanging" OnRowCommand="gvPatientList_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                    <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                                    <asp:BoundField DataField="DateOfBirthString" HeaderText="Date Of Birth" />
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                    <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                                    <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                                    <asp:BoundField DataField="CreatedDateString" HeaderText="Created Date" />
                                    <asp:BoundField DataField="AddedBy" HeaderText="Added By" />
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEditRow" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="EditRow" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="lbDeleteRow" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="DeleteRow" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?');"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</asp:Content>
