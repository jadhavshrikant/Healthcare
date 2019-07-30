#region Namespace
using System;
#endregion

namespace Healthcare.Models.ErrorDetail
{
    /// <summary>
    /// ErrorModel
    /// </summary>
    public class ErrorModel
    {
        #region Properties

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        #endregion
    }
}
