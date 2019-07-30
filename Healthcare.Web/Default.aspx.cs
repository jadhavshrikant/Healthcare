#region Namespace
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.UserDetail;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
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
            CommonConstant.ServiceAddressURL = ConfigurationManager.AppSettings["ServiceAddressURL"];
            proxyUserDetailService = new ServiceClient<IUserDetailService>(CommonConstant.ServiceAddressURL + "UserDetailService.svc");
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
                        if (userModel.ResultType == (int)CommonConstant.ReturnResult.Success)
                        {
                            var authentication = HttpContext.Current.GetOwinContext().Authentication;
                            authentication.SignIn(
                                    new AuthenticationProperties { IsPersistent = false, AllowRefresh = true },
                                    new ClaimsIdentity(new[] {
                                        new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.Token)},
                                    DefaultAuthenticationTypes.ApplicationCookie)
                                );
                            isValid = true;
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