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
    /// DataParameterManager
    /// </summary>
    public class DataParameterManager
    {
        #region Methods

        /// <summary>
        /// createParamter
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        public static IDbDataParameter createParamter(string providerName, string name, object value, DbType dbType, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return createSqlParamter(name, value, dbType, parameterDirection);
            }
            return parameter;
        }

        /// <summary>
        /// createParamter
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        public static IDbDataParameter createParamter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return createSqlParamter(name, size, value, dbType, parameterDirection);
            }
            return parameter;
        }

        /// <summary>
        /// createSqlParamter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        private static IDbDataParameter createSqlParamter(string name, object value, DbType dbType, ParameterDirection parameterDirection)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = parameterDirection,
                Value = value
            };
        }

        /// <summary>
        /// createSqlParamter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        private static IDbDataParameter createSqlParamter(string name, int size, object value, DbType dbType, ParameterDirection parameterDirection)
        {
            return new SqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = parameterDirection,
                Value = value
            };
        }

        #endregion
    }
}
