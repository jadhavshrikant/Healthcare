#region Namespace
using Healthcare.Logging;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Global
    /// </summary>
    public class Global : HttpApplication
    {
        #region Events

        /// <summary>
        /// Application_Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogHelper.Configure();
            
        }

        /// <summary>
        /// Page_Error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            LogHelper.Error(Ex.Message, Ex);
            Server.ClearError();
            Server.Transfer("~/Error.aspx");
        }
        #endregion
    }
}