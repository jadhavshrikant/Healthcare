#region Namespace
using System;
using System.Data;
#endregion

namespace Healthcare.Models.DashboardDetail
{
    /// <summary>
    /// DashboardModel
    /// </summary>
    public class DashboardModel
    {
        #region Properties
        public int TotalPatient { get; set; }
        public int TotalUser { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// DataRowToObjectMapper
        /// </summary>
        /// <param name="dataTable"></param>
        public void DataRowToObjectMapper(DataRow row)
        {
            this.TotalPatient = row["TOTAL_PATIENTS"] as int? ?? 0;
            this.TotalUser = row["TOTAL_USERS"] as int? ?? 0;
        }

        #endregion
    }
}
