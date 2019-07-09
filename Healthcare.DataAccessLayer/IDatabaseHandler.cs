#region Namespace
using System.Data;
#endregion

namespace Healthcare.DataAccessLayer
{
    /// <summary>
    /// IDatabaseHandler
    /// </summary>
    public interface IDatabaseHandler
    {
        #region Properties

        IDbConnection createConnection();
        void closeConnection(IDbConnection dbConnection);
        IDbCommand createCommand(string commandText, CommandType commandType, IDbConnection dbConnection);
        IDataAdapter createAdapter(IDbCommand dbCommand);
        IDataParameter createParameter(IDbCommand dbCommand);
        #endregion
    }
}
