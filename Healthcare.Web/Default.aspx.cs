#region Namespace
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.UserDetail;
using Healthcare.Web.App_Code;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// _Default - Login page 
    /// </summary>
    public partial class _Default : Page
    {
        #region Properties

        /// <summary>
        /// proxyUserDetailService
        /// </summary>
        ServiceClient<IUserDetailService> proxyUserDetailService = null;

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
        /// btnLogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            authenticateUser();
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
            proxyUserDetailService = new ServiceClient<IUserDetailService>("UserDetailService.svc");
        }

        /// <summary>
        /// authenticateUser
        /// </summary>
        private void authenticateUser()
        {
            Page.Validate("loginForm");
            if (Page.IsValid)
            {  
                HtmlControl divControl = (HtmlControl)ucNotification.FindControl("dvError");
                divControl.Visible = false;
                Label lblErrorMessage = (Label)ucNotification.FindControl("lblErrorMessage");
                lblErrorMessage.Text = "";
                if (validateUser(divControl, lblErrorMessage))
                {
                    UserModel userModel = new UserModel();
                    userModel.Username = txtUsername.Text;
                    userModel.Password = txtPassword.Text;
                    userModel = proxyUserDetailService.Execute(prxy => prxy.authenticateUser(userModel));
                    bool isValid = false;
                    if (null != userModel)
                    {
                        if (userModel.ResultType == (int)CommonConstant.ReturnResult.Success) //Valid User
                        {
                            isValid = true;
                            SessionManager.setUserSession(userModel);
                            Response.Redirect("~/Dashboard.aspx");
                        }
                    }
                    if (!isValid)
                    {
                        divControl.Visible = true;
                        lblErrorMessage.Text = "Please enter Username or Password.";
                    }
                }
            }
        }

        /// <summary>
        /// validateUser
        /// </summary>
        /// <param name="divControl"></param>
        /// <param name="lblErrorMessage"></param>
        /// <returns></returns>
        private bool validateUser(HtmlControl divControl, Label lblErrorMessage)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter Username.";
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                divControl.Visible = true;
                lblErrorMessage.Text = "Please enter Password.";
                return false;
            }
            return true;
        }

        #endregion
    }
}