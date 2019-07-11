#region Namespace
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Security.Claims;
using System.Web;
#endregion

namespace Healthcare.Web.App_Code
{
    /// <summary>
    /// BasePage
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        #region Events

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            validateUserToken();
            base.OnLoad(e);
        }
        #endregion

        #region Methods

        /// <summary>
        /// validateUserToken
        /// </summary>
        private void validateUserToken()
        {
            bool isValid = true;
            var identity = User.Identity as ClaimsIdentity;
            if (!Request.IsAuthenticated || !identity.IsAuthenticated)
            {
                isValid = false;
            }
            if (isValid)
            {
                UserModel userModel = CommonMethod.ConvertJsonStringToObject<UserModel>(identity.Name);
                if (userModel.UserId < 0)
                {
                    isValid = false;
                }
            }
            if (!isValid)
            {
                redirectToLogin();
            }
        }

        /// <summary>
        /// redirectToLogin
        /// </summary>
        private void redirectToLogin()
        {
            HttpContext.Current.GetOwinContext().Authentication.Challenge(
                     new AuthenticationProperties { RedirectUri = "/" },
                     OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }

        #endregion
    }
}