#region Namespace
using Healthcare.Models.PatientDetail;
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.PatientDetail;
using Healthcare.Web.App_Code;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
#endregion

namespace Healthcare.Web.ManagePatient
{
    /// <summary>
    /// PatientList
    /// </summary>
    public partial class PatientList : BasePage
    {
        #region Properties

        /// <summary>
        /// proxyPatientDetailService
        /// </summary>
        ServiceClient<IPatientDetailService> proxyPatientDetailService = null;

        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }
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

                string result = proxyPatientDetailService.Execute(prxy => prxy.deletetPatientDetail(patientId), token);

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

            CommonConstant.ServiceAddressURL = ConfigurationManager.AppSettings["ServiceAddressURL"];
            proxyPatientDetailService = new ServiceClient<IPatientDetailService>(CommonConstant.ServiceAddressURL + "PatientDetailService.svc");

            var identity = User.Identity as ClaimsIdentity;
            token = identity.Name;
            UserModel userModel = CommonMethod.ConvertJsonStringToObject<UserModel>(identity.Name);

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
            List<PatientModel> lstPatients = proxyPatientDetailService.Execute(prxy => prxy.getPatients(), token);
            gvPatientList.DataSource = lstPatients;
            gvPatientList.DataBind();
        }

        #endregion 
    }
}