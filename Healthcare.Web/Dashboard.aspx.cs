#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.Common;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Web;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : System.Web.UI.Page
    {
        #region Properties
        /// <summary>
        /// proxyCommonUtilityService
        /// </summary>
        ServiceClient<ICommonUtilityService> proxyCommonUtilityService = null;
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
        #endregion

        #region Methods
        private void loadDefaultMethod()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                  new AuthenticationProperties { RedirectUri = "/" },
                  OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }

<<<<<<< HEAD
            proxyCommonUtilityService = new ServiceClient<ICommonUtilityService>("CommonUtilityService.svc");
=======
            proxyCommonUtilityService = new ServiceClient<ICommonUtilityService>("ICommonUtilityService", "CommonUtilityService.svc");
>>>>>>> 9c74699afce7e777e749dcc93555422342078b5b

            if (!this.IsPostBack)
            {
                bindDashboardItems();
            }
        }

        /// <summary>
        /// bindDashboardItems
        /// </summary>
        private void bindDashboardItems()
        {
            DashboardModel dashboardModel = proxyCommonUtilityService.Execute(prxy => prxy.getDashboardItems());
            if (null != dashboardModel)
            {
                lblTotalPatient.Text = Convert.ToString(dashboardModel.TotalPatient);
                lblTotalUser.Text = Convert.ToString(dashboardModel.TotalUser);
            }
        }
        #endregion
    }
}