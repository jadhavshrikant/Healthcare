#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
#endregion

namespace Healthcare.DataAccessLayer
{
    /// <summary>
    /// DBManager
    /// </summary>
    public class DBManager
    {
        #region Properties
        private DatabaseHandlerFactory dbFactory;
        private IDatabaseHandler database;
        private string providerName;
        #endregion

        #region Constructor

        /// <summary>
        /// DBManager
        /// </summary>
        /// <param name="connectionStringName"></param>
        public DBManager(string connectionStringName)
        {
            dbFactory = new DatabaseHandlerFactory(connectionStringName);
            database = dbFactory.createDatabase();
            providerName = dbFactory.getProviderName();
        }
        #endregion

        #region Methods

        /// <summary>
        /// GetDatabaseConnection
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetDatabaseConnection()
        {
            return database.createConnection();
        }

        /// <summary>
        /// closeConnection
        /// </summary>
        /// <param name="dbConnection"></param>
        public void closeConnection(IDbConnection dbConnection)
        {
            database.closeConnection(dbConnection);
        }

        /// <summary>
        /// createParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public IDbDataParameter createParameter(string name, object value, DbType dbType)
        {
            return DataParameterManager.createParamter(providerName, name, value, dbType);
        }

        /// <summary>
        /// createParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public IDbDataParameter createParameter(string name, int size, object value, DbType dbType)
        {
            return DataParameterManager.createParamter(providerName, name, size, value, dbType);
        }

        /// <summary>
        /// createParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public IDbDataParameter createParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return DataParameterManager.createParamter(providerName, name, size, value, dbType, direction);
        }

        /// <summary>
        /// getDataTable
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable getDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdapter = database.createAdapter(command);
                    dataAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        /// <summary>
        /// getDataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet getDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdapter = database.createAdapter(command);
                    dataAdapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        /// <summary>
        /// getDataReader
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public IDataReader getDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection)
        {
            IDataReader reader = null;
            connection = database.createConnection();
            connection.Open();
            var command = database.createCommand(commandText, commandType, connection);
            if (null != parameters)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void delete(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void insert(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <param name="lastId"></param>
        /// <returns></returns>
        public int insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int lastId)
        {
            lastId = 0;
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    object newId = command.ExecuteScalar();
                    lastId = Convert.ToInt32(newId);
                }
            }
            return lastId;
        }

        /// <summary>
        /// insertWithTransaction
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void insertWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.createConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// insertWithTransaction
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="isolationLevel"></param>
        /// <param name="parameters"></param>
        public void insertWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters = null)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.createConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction(isolationLevel);
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void update(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// updateWithTransaction
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public void updateWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.createConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// updateWithTransaction
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="isolationLevel"></param>
        /// <param name="parameters"></param>
        public void updateWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters = null)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.createConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction(isolationLevel);
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// getScalarValue
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object getScalarValue(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            string getValue = "0";
            using (var connection = database.createConnection())
            {
                connection.Open();
                using (var command = database.createCommand(commandText, commandType, connection))
                {
                    if (null != parameters)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var result = command.ExecuteScalar();
                    if (null != result)
                    {
                        getValue = Convert.ToString(result);
                    }
                }
            }
            return getValue;
        }

        #endregion
    }
}
