#region Namespace
using Healthcare.DataAccessLayer;
using Healthcare.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
#endregion

namespace Healthcare.Repository.Repositories.UserDetail
{
    /// <summary>
    /// UserDetailRepository
    /// </summary>
    public class UserDetailRepository : IUserDetailRepository
    {
        #region Properties
        private ConnectionStringSettings connectionStringSettings;
        #endregion

        #region Constructor

        /// <summary>
        /// UserDetailRepository
        /// </summary>
        public UserDetailRepository()
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings["HealthcareDBString"];
        }
        #endregion

        #region Methods

        /// <summary>
        /// authenticateUser
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns></returns>
        public UserModel authenticateUser(UserModel userDetail)
        {
            var dbManager = new DBManager(connectionStringSettings.Name);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.createParameter("@USERNAME", 100, userDetail.Username, DbType.String));
            var dataTable = dbManager.getDataTable("SP_AUTHENTICATE_USER", CommandType.StoredProcedure, parameters.ToArray());
            try
            {
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    string currentPassword = Convert.ToString(row["PASSWORD"]);
                    userDetail.ResultType = 2;
                    if (userDetail.Password.Equals(currentPassword))
                    {
                        userDetail.UserId = row["USER_ID"] as int? ?? 0;
                        userDetail.ResultType = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userDetail;
        }

        #endregion
    }
}
