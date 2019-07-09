#region Namespace
using System;
#endregion

namespace Healthcare.Web.UserControls
{
    /// <summary>
    /// NotificationUserControl
    /// </summary>
    public partial class NotificationUserControl : System.Web.UI.UserControl
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

        private void loadDefaultMethod()
        {
            dvSuccess.Visible = dvInfo.Visible = dvWarning.Visible = dvError.Visible = false;
        }

        #endregion
    }
}