#region Namespace
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.PatientDetail;
using Healthcare.Models.SalutationDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.Common;
using Healthcare.WCFServiceInterface.PatientDetail;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Security.Claims;
using Healthcare.Models.UserDetail;
using Healthcare.Web.App_Code;
#endregion

namespace Healthcare.Web.ManagePatient
{
    /// <summary>
    /// UpsertPatientDetail
    /// </summary>
    public partial class UpsertPatientDetail : BasePage
    {
        #region Properties

        /// <summary>
        /// proxyPatientDetailService
        /// </summary>
        private ServiceClient<IPatientDetailService> proxyPatientDetailService = null;

        /// <summary>
        /// proxyCommonUtilityService
        /// </summary>
        private ServiceClient<ICommonUtilityService> proxyCommonUtilityService = null;

        #endregion

        #region Events

        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDefaultMethod();
        }

        /// <summary>
        /// validateGender
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void validateGender(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rbMale.Checked || rbFemale.Checked;
        }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagePatient/PatientList.aspx");
        }

        /// <summary>
        /// btnAddPatient_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            upsertPatientDetail();
        }

        #endregion

        #region Methods

        /// <summary>
        /// loadDefaultMethod
        /// </summary>
        private void loadDefaultMethod()
        {
            CommonConstant.ServiceAddressURL = ConfigurationManager.AppSettings["ServiceAddressURL"];
            proxyPatientDetailService = new ServiceClient<IPatientDetailService>(CommonConstant.ServiceAddressURL + "PatientDetailService.svc");
            proxyCommonUtilityService = new ServiceClient<ICommonUtilityService>(CommonConstant.ServiceAddressURL + "CommonUtilityService.svc");

            if (!this.IsPostBack)
            {
                bindDropDownList();
                loadPatientDetailsForUpdate();
            }
        }

        /// <summary>
        /// loadPatientDetailsForUpdate
        /// </summary>
        private void loadPatientDetailsForUpdate()
        {
            if (Request.QueryString["patientId"] != null) //For update patient details 
            {
                this.Title = "Update Patient";
                btnAddPatient.Text = "Update Patient";
                lblHeading.InnerText = "Update Patient";
                int patientId = Convert.ToInt32(Request.QueryString["patientId"].ToString());

                PatientModel patientModel = proxyPatientDetailService.Execute(prxy => prxy.getPatientDetail(patientId), token);

                //Assign values to web form controls
                hfPatientId.Value = Convert.ToString(patientModel.PatientId);
                ddlSalutation.SelectedValue = Convert.ToString(patientModel.SalutationId);
                txtFirstName.Text = patientModel.FirstName;
                txtMiddleName.Text = patientModel.MiddleName;
                txtLastName.Text = patientModel.LastName;
                ddlMaritalStatus.SelectedValue = Convert.ToString(patientModel.MaritalStatusId);
                txtDateOfBirth.Text = patientModel.DateOfBirth.HasValue ? patientModel.DateOfBirth.Value.ToString("MM/dd/yyyy") : "";
                if (patientModel.Gender == "M")
                {
                    rbMale.Checked = true;
                }
                else if (patientModel.Gender == "F")
                {
                    rbFemale.Checked = true;
                }
                txtContactNo.Text = patientModel.ContactNo;
                txtOccupation.Text = patientModel.Occupation;
            }
            else //For add new patient details
            {
                this.Title = "Add Patient";
                btnAddPatient.Text = "Add Patient";
                lblHeading.InnerText = "Add Patient";
                hfPatientId.Value = "0";
            }
        }

        /// <summary>
        /// bindDropDownList
        /// </summary>
        private void bindDropDownList()
        {
            List<SalutationModel> lstSalutations = proxyCommonUtilityService.Execute(prxy => prxy.getSalutations(), token);
            ddlSalutation.DataSource = lstSalutations;
            ddlSalutation.DataValueField = "SalutationId";
            ddlSalutation.DataTextField = "Salutation";
            ddlSalutation.DataBind();

            List<MaritalStatusModel> lstMaritalStatuses = proxyCommonUtilityService.Execute(prxy => prxy.getMaritals(), token);
            ddlMaritalStatus.DataSource = lstMaritalStatuses;
            ddlMaritalStatus.DataValueField = "MaritalStatusId";
            ddlMaritalStatus.DataTextField = "MaritalStatus";
            ddlMaritalStatus.DataBind();
        }

        /// <summary>
        /// upsertPatientDetail
        /// </summary>
        public void upsertPatientDetail()
        {
            Page.Validate("PatientDetailForm");
            if (Page.IsValid)
            {
                HtmlControl divControl = (HtmlControl)ucNotification.FindControl("dvError");
                divControl.Visible = false;
                Label lblErrorMessage = (Label)ucNotification.FindControl("lblErrorMessage");
                lblErrorMessage.Text = "";
                if (validatePatientDetails(divControl, lblErrorMessage))
                {
                    PatientModel patientModel = new PatientModel();
                    patientModel.SalutationId = Convert.ToInt32(ddlSalutation.SelectedValue);
                    patientModel.FirstName = txtFirstName.Text;
                    patientModel.MiddleName = txtMiddleName.Text;
                    patientModel.LastName = txtLastName.Text;
                    patientModel.MaritalStatusId = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
                    patientModel.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                    patientModel.Gender = rbMale.Checked ? "M" : rbFemale.Checked ? "F" : "O";
                    patientModel.ContactNo = txtContactNo.Text;
                    patientModel.Occupation = txtOccupation.Text;
                    patientModel.PatientId = Convert.ToInt32(hfPatientId.Value);
                    patientModel.UserId = userId;

                    string result = proxyPatientDetailService.Execute(prxy => prxy.upsertPatientDetail(patientModel), token);

                    if (!string.IsNullOrEmpty(result) && result == Convert.ToString((int)CommonConstant.Notification.Success))
                    {
                        //show success notfication
                        Response.Redirect("~/ManagePatient/PatientList.aspx");
                    }
                    else
                    {
                        divControl.Visible = true;
                        lblErrorMessage.Text = "Please enter valid details and re-submit the details.";
                    }
                }
            }
        }

        /// <summary>
        /// validatePatientDetails
        /// </summary>
        /// <param name="divControl"></param>
        /// <param name="lblErrorMessage"></param>
        /// <returns></returns>
        private bool validatePatientDetails(HtmlControl divControl, Label lblErrorMessage)
        {
            bool isValid = true;
            if (ddlSalutation.SelectedIndex == -1)
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please select Salutation.";
            }
            else if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter First Name.";
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter Last Name.";
            }
            else if (ddlMaritalStatus.SelectedIndex == -1)
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please select Marital Status.";
            }
            else if (string.IsNullOrEmpty(txtDateOfBirth.Text))
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter Date Of Birth.";
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                isValid = false;
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter Contact No.";
            }
            return isValid;
        }
        #endregion
    }
}