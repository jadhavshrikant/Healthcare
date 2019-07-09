#region Namespace
using Healthcare.Models.PatientDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.PatientDetail;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
#endregion

namespace Healthcare.Web.ManagePatient
{
    /// <summary>
    /// PatientList
    /// </summary>
    public partial class PatientList : System.Web.UI.Page
    {
        #region Properties

        /// <summary>
        /// proxyPatientDetailService
        /// </summary>
        ServiceClient<IPatientDetailService> proxyPatientDetailService = null;
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
        /// gvPatientList_PageIndexChanging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPatientList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvPatientList.PageIndex = e.NewPageIndex;
            this.bindPatientList();
        }

        /// <summary>
        /// gvPatientList_RowCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPatientList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int patientId = Convert.ToInt32(Convert.ToString(gvPatientList.DataKeys[rowIndex]["PatientId"]));
                Response.Redirect(string.Format("~/ManagePatient/UpsertPatientDetail.aspx?patientId={0}", patientId));
            }
            else if (e.CommandName == "DeleteRow")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int patientId = Convert.ToInt32(Convert.ToString(gvPatientList.DataKeys[rowIndex]["PatientId"]));

                string result = proxyPatientDetailService.Execute(prxy => prxy.deletetPatientDetail(patientId));

                HtmlControl divErrorControl = (HtmlControl)ucNotification.FindControl("dvError");
                HtmlControl divSuccessControl = (HtmlControl)ucNotification.FindControl("dvSuccess");
                divErrorControl.Visible = divSuccessControl.Visible = false;
                Label lblErrorMessage = (Label)ucNotification.FindControl("lblErrorMessage");
                Label lblSuccessMessage = (Label)ucNotification.FindControl("lblSuccessMessage");
                lblErrorMessage.Text = lblSuccessMessage.Text = "";
                if (!string.IsNullOrEmpty(result) && result == Convert.ToString((int)CommonConstant.ReturnResult.Success))
                {
                    lblSuccessMessage.Visible = true;
                    lblSuccessMessage.Text = "Patient record has been deleted successfully.";
                    bindPatientList();
                }
                else
                {
                    divErrorControl.Visible = true;
                    lblErrorMessage.Text = "Error occurred while processing your request.";
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// loadDefaultMethod
        /// </summary>
        private void loadDefaultMethod()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                  new AuthenticationProperties { RedirectUri = "/" },
                  OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }

<<<<<<< HEAD
            proxyPatientDetailService = new ServiceClient<IPatientDetailService>("PatientDetailService.svc");
=======
            proxyPatientDetailService = new ServiceClient<IPatientDetailService>("IPatientDetailService", "PatientDetailService.svc");
>>>>>>> 9c74699afce7e777e749dcc93555422342078b5b

            if (!this.IsPostBack)
            {
                bindPatientList();
            }
        }

        /// <summary>
        /// bindPatientList
        /// </summary>
        private void bindPatientList()
        {
            List<PatientModel> lstPatients = proxyPatientDetailService.Execute(prxy => prxy.getPatients());
            gvPatientList.DataSource = lstPatients;
            gvPatientList.DataBind();
        }



        #endregion 
    }
}