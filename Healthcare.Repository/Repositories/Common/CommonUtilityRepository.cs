#region Namespace
using Healthcare.DataAccessLayer;
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
#endregion

namespace Healthcare.Repository.Repositories.Common
{
    /// <summary>
    /// CommonUtilityRepository
    /// </summary>
    public class CommonUtilityRepository : ICommonUtilityRepository
    {
        #region Properties
        private ConnectionStringSettings connectionStringSettings;
        #endregion

        #region Constructor

        /// <summary>
        /// CommonUtilityRepository
        /// </summary>
        public CommonUtilityRepository()
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings["HealthcareDBString"];
        }
        #endregion

        #region Methods

        /// <summary>
        /// getMaritals
        /// </summary>
        /// <returns></returns>
        public List<MaritalStatusModel> getMaritals()
        {
            List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();
            try
            {
                var dbManager = new DBManager(connectionStringSettings.Name);
                var dataTable = dbManager.getDataTable("SP_GET_MARITAL_STATUS", CommandType.StoredProcedure);
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    MaritalStatusModel maritalStatusModel = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        maritalStatusModel = new MaritalStatusModel();
                        maritalStatusModel.MaritalStatusId = row["MARITAL_STATUS_ID"] as int? ?? 0;
                        maritalStatusModel.MaritalStatus = row["MARITAL_STATUS"] as string ?? string.Empty;
                        maritalStatusList.Add(maritalStatusModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return maritalStatusList;
        }

        /// <summary>
        /// getSalutations
        /// </summary>
        /// <returns></returns>
        public List<SalutationModel> getSalutations()
        {
            List<SalutationModel> salutationList = new List<SalutationModel>();
            try
            {
                var dbManager = new DBManager(connectionStringSettings.Name);
                var dataTable = dbManager.getDataTable("SP_GET_SALUTATIONS", CommandType.StoredProcedure);
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    SalutationModel salutationModel = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        salutationModel = new SalutationModel();
                        salutationModel.SalutationId = row["SALUTATION_ID"] as int? ?? 0;
                        salutationModel.Salutation = row["SALUTATION"] as string ?? string.Empty;
                        salutationList.Add(salutationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salutationList;
        }

        /// <summary>
        /// getDashboardItems
        /// </summary>
        /// <returns></returns>
        public DashboardModel getDashboardItems()
        {
            DashboardModel dashboardModel = null;
            var dbManager = new DBManager(connectionStringSettings.Name);
            var dataTable = dbManager.getDataTable("SP_GET_DASHBOARD_ITEMS", CommandType.StoredProcedure);
            try
            {
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    dashboardModel = new DashboardModel();
                    dashboardModel.DataRowToObjectMapper(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dashboardModel;
        }

        #endregion
    }
}
