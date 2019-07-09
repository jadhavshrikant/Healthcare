#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace Healthcare.DataAccessLayer
{
    /// <summary>
    /// SQLDataAccess
    /// </summary>
    public class SQLDataAccess : IDatabaseHandler
    {
        #region Properties
        private string connectionString { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// SQLDataAccess
        /// </summary>
        /// <param name="connectionString"></param>
        public SQLDataAccess(string connectionString) {
            this.connectionString = connectionString;
        }
        #endregion

        #region Methods

        /// <summary>
        /// createConnection
        /// </summary>
        /// <returns></returns>
        public IDbConnection createConnection() {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// closeConnection
        /// </summary>
        /// <param name="dbConnection"></param>
        public void closeConnection(IDbConnection dbConnection) {
            var sqlconnection = (SqlConnection)dbConnection;
            sqlconnection.Close();
            sqlconnection.Dispose();
        }

        /// <summary>
        /// createCommand
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="dbConnection"></param>
        /// <returns></returns>
        public IDbCommand createCommand(string commandText, CommandType commandType, IDbConnection dbConnection)
        {
            return new SqlCommand
            {
                CommandText = commandText,
                Connection = (SqlConnection)dbConnection,
                CommandType = commandType,
            };
        }

        /// <summary>
        /// createAdapter
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public IDataAdapter createAdapter(IDbCommand dbCommand) {
            return new SqlDataAdapter((SqlCommand)dbCommand);
        }

        /// <summary>
        /// createParameter
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public IDataParameter createParameter(IDbCommand dbCommand)
        {
            SqlCommand sqlCommand = (SqlCommand)dbCommand;
            return sqlCommand.CreateParameter();
        }

        #endregion
    }
}
