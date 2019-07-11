#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceClient;
using Healthcare.WCFServiceInterface.Common;
using Healthcare.Web.App_Code;
using System;
using System.Configuration;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : BasePage
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
            CommonConstant.ServiceAddressURL = ConfigurationManager.AppSettings["ServiceAddressURL"];
            proxyCommonUtilityService = new ServiceClient<ICommonUtilityService>(CommonConstant.ServiceAddressURL + "CommonUtilityService.svc");

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