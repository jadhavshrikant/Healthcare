#region Namespace
using System;
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Callback
    /// </summary>
    public partial class Callback : System.Web.UI.Page
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
            Response.Redirect("~/Default.aspx");
        }
        #endregion
    }
}