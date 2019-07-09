#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
#endregion

namespace Healthcare.DataAccessLayer
{
    /// <summary>
    /// DatabaseHandlerFactory
    /// </summary>
    public class DatabaseHandlerFactory
    {
        #region Properties
        private ConnectionStringSettings connectionStringSettings;
        #endregion

        #region Constructor

        /// <summary>
        /// DatabaseHandlerFactory
        /// </summary>
        /// <param name="connectionStringName"></param>
        public DatabaseHandlerFactory(string connectionStringName) {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }
        #endregion

        #region Methods

        /// <summary>
        /// createDatabase
        /// </summary>
        /// <returns></returns>
        public IDatabaseHandler createDatabase() {
            IDatabaseHandler database = null;
            switch (connectionStringSettings.ProviderName.ToLower()) {
                case "system.data.sqlclient":
                    database = new SQLDataAccess(connectionStringSettings.ConnectionString);
                    break;
            }
            return database;
        }

        /// <summary>
        /// getProviderName
        /// </summary>
        /// <returns></returns>
        public string getProviderName() {
            return connectionStringSettings.ProviderName;
        }

        #endregion
    }
}
