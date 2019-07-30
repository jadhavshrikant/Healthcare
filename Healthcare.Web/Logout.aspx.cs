#region Namespace
using Healthcare.Web.App_Code;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Web;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Logout
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
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
        #endregion

        #region Methods
        /// <summary>
        /// loadDefaultMethod
        /// </summary>
        private void loadDefaultMethod()
        {
            Context.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            SessionManager.clearUserSession();
            Response.Redirect("Default.aspx");
        }
        #endregion
    }
}