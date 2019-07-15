#region Namespace
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
#endregion

namespace Healthcare.WCFServiceInterface
{
    /// <summary>
    /// TokenValidator
    /// </summary>
    public class TokenValidator
    {
        private const int aliveDurationMinutes = 15;

        /// <summary>
        /// Checks if the token is still alive with a 1-second tolerance.
        /// </summary>
        private static bool CheckTokenAlive(DateTime created, DateTime timeToCompare)
        {
            TimeSpan elapsedTime = timeToCompare - created;

            return (elapsedTime.TotalSeconds > -1 && elapsedTime.TotalSeconds < 0) // up to 1 second before
                   || (elapsedTime.TotalSeconds >= 0 && Math.Floor(elapsedTime.TotalSeconds) <= aliveDurationMinutes * 60); // up to 15 minutes later
        }

        /// <summary>
        /// validateUser
        /// </summary>
        /// <returns></returns>
        public static bool validateUser()
        {
            bool isValid = true;
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string encUserDetail = headers["X-Token"];
            if (!string.IsNullOrEmpty(encUserDetail))
            {
                UserModel userModel = CommonMethod.ConvertJsonStringToObject<UserModel>(encUserDetail);
                if (null == userModel || userModel.UserId == 0)
                {
                    isValid = false;
                }
                else if (!CheckTokenAlive(userModel.TokenCreated, DateTime.Now))
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }
            if (!isValid)
                throw new FaultException("Service Authorization can not be done for unauthenticated user.");
            return isValid;
        }
    }
}