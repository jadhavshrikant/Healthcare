#region Namespace
using System;
#endregion

namespace Healthcare.Utilities
{
    /// <summary>
    /// CommonConstant
    /// </summary>
    public static class CommonConstant
    {
        #region Properties
        /// <summary>
        /// ServiceAddressURL
        /// </summary>
        public static string ServiceAddressURL { get; set; }
        #endregion

        #region Enums

        /// <summary>
        /// ReturnResult
        /// </summary>
        public enum ReturnResult
        {
            Error = 0,
            Success = 1,
        }

        /// <summary>
        /// Notification
        /// </summary>
        public enum Notification
        {
            None = 0,
            Success = 1,
            Error = 2,
            Info = 3,
            Warning = 4
        }

        /// <summary>
        /// MaritalStatus
        /// </summary>
        public enum MaritalStatus
        {
            Married = 1,
            Single = 2,
            Divorced = 3,
            Widowed = 4
        }

        /// <summary>
        /// Salutaion
        /// </summary>
        public enum Salutaion
        {
            Mr = 1,
            Mrs = 2,
            Miss = 3,
            Dr = 4
        }

        #endregion
    }
}
