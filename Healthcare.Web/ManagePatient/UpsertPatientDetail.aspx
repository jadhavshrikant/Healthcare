<%@ Page Title="Add Patient" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UpsertPatientDetail.aspx.cs" Inherits="Healthcare.Web.ManagePatient.UpsertPatientDetail" %>

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
                <h1 class="page-header" id="lblHeading" runat="server">Add Patient</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Salutation</label>
                                    <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="form-control" ValidationGroup="PatientDetailForm"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSalutation" runat="server" ControlToValidate="ddlSalutation" ValidationGroup="PatientDetailForm" ErrorMessage="Please select Salutation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="100" placeholder="First Name" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ValidationGroup="PatientDetailForm" ErrorMessage="Please enter First Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Middle Name</label>
                                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" MaxLength="100" placeholder="Middle Name" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Last Name</label>
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="100" placeholder="Last Name" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ValidationGroup="PatientDetailForm" ErrorMessage="Please select Last Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Marital Status</label>
                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control" ValidationGroup="PatientDetailForm"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvMaritalStatus" runat="server" ControlToValidate="ddlMaritalStatus" ValidationGroup="PatientDetailForm" ErrorMessage="Please select Marital Status" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnAddPatient" runat="server" CssClass="btn btn-primary" Text="Add Patient" CausesValidation="true" ValidationGroup="PatientDetailForm" OnClick="btnAddPatient_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Date Of Birth</label>
                                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" MaxLength="10" placeholder="MM/dd/yyyy" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ValidationGroup="PatientDetailForm" ErrorMessage="Please enter Date Of Birth" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Gender</label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rbMale" runat="server" Text="Male" GroupName="Gender" ValidationGroup="PatientDetailForm" />
                                    </label>
                                    <label class="radio-inline">
                                        <asp:RadioButton ID="rbFemale" runat="server" Text="Female" GroupName="Gender" ValidationGroup="PatientDetailForm" />
                                    </label>
                                    <asp:CustomValidator ID="rfvGender" runat="server" ClientValidationFunction="validateGender" OnServerValidate="validateGender" ValidationGroup="PatientDetailForm" ErrorMessage="Please select Gender" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                                </div>
                                <div class="form-group">
                                    <label>Contact No</label>
                                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" MaxLength="10" placeholder="Contact No" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" ValidationGroup="PatientDetailForm" ErrorMessage="Please enter Contact No" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Occupation</label>
                                    <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control" MaxLength="100" placeholder="Occupation" ValidationGroup="PatientDetailForm"></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
    <asp:HiddenField ID="hfPatientId" runat="server" Value="0" />
</asp:Content>
