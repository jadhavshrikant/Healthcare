#region Namespace
using Healthcare.Models.UserDetail;
using System;
using System.Web;
#endregion

namespace Healthcare.Web.App_Code
{
    /// <summary>
    /// SessionManager
    /// </summary>
    public class SessionManager
    {
        #region Methods 

        /// <summary>
        /// getUserId
        /// </summary>
        /// <returns></returns>
        public static int getUserId()
        {
            string sUserId = Convert.ToString(HttpContext.Current.Session["UserId"]);
            return Convert.ToInt32(sUserId);
        }

        /// <summary>
        /// IsSessionExpired
        /// </summary>
        /// <returns></returns>
        public static bool IsSessionExpired()
        {
            if (HttpContext.Current.Session != null)
            {
                string UserId = HttpContext.Current.Session["Username"] as string;
                if (string.IsNullOrEmpty(UserId))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// setUserSession
        /// </summary>
        /// <param name="userModel"></param>
        public static void setUserSession(UserModel userModel)
        {
            HttpContext.Current.Session["UserId"] = userModel.UserId;
            HttpContext.Current.Session["Username"] = userModel.Username;
            HttpContext.Current.Session["FullName"] = userModel.FirstName + " " + userModel.LastName;
        }

        /// <summary>
        /// clearUserSession
        /// </summary>
        public static void clearUserSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
        #endregion
    }
}