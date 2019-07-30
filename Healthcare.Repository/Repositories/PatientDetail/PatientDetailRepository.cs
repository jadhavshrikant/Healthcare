#region Namespace
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.DataAccessLayer;
using Healthcare.Models.PatientDetail;
#endregion

namespace Healthcare.Repository.Repositories.PatientDetail
{
    /// <summary>
    /// PatientDetailRepository
    /// </summary>
    public class PatientDetailRepository : IPatientDetailRepository
    {
        #region Properties
        private ConnectionStringSettings connectionStringSettings;
        #endregion

        #region Constructor

        /// <summary>
        /// PatientDetailRepository
        /// </summary>
        public PatientDetailRepository()
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings["HealthcareDBString"];
        }
        #endregion

        #region Methods

        /// <summary>
        /// getPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientModel> getPatients()
        {
            List<PatientModel> patientList = new List<PatientModel>();
            try
            {
                var dbManager = new DBManager(connectionStringSettings.Name);
                var dataTable = dbManager.getDataTable("SP_GET_PATIENTS", CommandType.StoredProcedure);
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    PatientModel patientModel = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        patientModel = new PatientModel();
                        patientModel.PatientId = row["PATIENT_ID"] as int? ?? 0;
                        patientModel.FullName = row["FULLNAME"] as string ?? string.Empty;
                        patientModel.MaritalStatus = row["MARITAL_STATUS"] as string ?? string.Empty;
                        patientModel.DateOfBirthString = row["DATE_OF_BIRTH"] as string ?? string.Empty;
                        patientModel.Gender = row["GENDER"] as string ?? string.Empty;
                        patientModel.ContactNo = row["CONTACT_NO"] as string ?? string.Empty;
                        patientModel.Occupation = row["OCCUPATION"] as string ?? string.Empty;
                        patientModel.CreatedDateString = row["CREATE_DATE"] as string ?? string.Empty;
                        patientModel.AddedBy = row["ADDED_BY"] as string ?? string.Empty;
                        patientModel.IsActive = row["IS_ACTIVE"] as string ?? string.Empty;
                        patientList.Add(patientModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientList;
        }

        /// <summary>
        /// getPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public PatientModel getPatientDetail(int patientId)
        {
            PatientModel patientModel = null;
            var dbManager = new DBManager(connectionStringSettings.Name);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.createParameter("@PATIENT_ID", patientId, DbType.Int32));
            var dataTable = dbManager.getDataTable("SP_GET_PATIENT_DETAIL", CommandType.StoredProcedure, parameters.ToArray());
            try
            {
                if (null != dataTable && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    patientModel = new PatientModel();
                    patientModel.DataRowToObjectMapper(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientModel;
        }

        /// <summary>
        /// upsertPatientDetail
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        public string upsertPatientDetail(PatientModel patientModel)
        {
            string returnValue = "0";
            var dbManager = new DBManager(connectionStringSettings.Name);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.createParameter("@USER_ID", patientModel.UserId, DbType.Int32));
            parameters.Add(dbManager.createParameter("@PATIENT_ID", patientModel.PatientId, DbType.Int32));
            parameters.Add(dbManager.createParameter("@SALUTATION_ID", patientModel.SalutationId, DbType.Int32));
            parameters.Add(dbManager.createParameter("@FIRST_NAME", 100, patientModel.FirstName, DbType.String));
            parameters.Add(dbManager.createParameter("@MIDDLE_NAME", 100, patientModel.MiddleName, DbType.String));
            parameters.Add(dbManager.createParameter("@LAST_NAME", 100, patientModel.LastName, DbType.String));
            parameters.Add(dbManager.createParameter("@MARITAL_STATUS_ID", patientModel.MaritalStatusId, DbType.Int32));
            parameters.Add(dbManager.createParameter("@DATE_OF_BIRTH", patientModel.DateOfBirth, DbType.DateTime));
            parameters.Add(dbManager.createParameter("@GENDER", 1, patientModel.Gender, DbType.String));
            parameters.Add(dbManager.createParameter("@CONTACT_NO", 10, patientModel.ContactNo, DbType.String));
            parameters.Add(dbManager.createParameter("@OCCUPATION", 100, patientModel.Occupation, DbType.String));
            try
            {
                dbManager.update("SP_UPSERT_PATIENT_DETAILS", CommandType.StoredProcedure, parameters.ToArray());
                returnValue = "1";
            }
            catch (Exception ex)
            {
                returnValue = "0";
                throw ex;
            }
            return returnValue;
        }

        /// <summary>
        /// deletetPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public string deletetPatientDetail(int patientId)
        {
            string returnValue = "0";
            var dbManager = new DBManager(connectionStringSettings.Name);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.createParameter("@PATIENT_ID", patientId, DbType.Int32));
            try
            {
                dbManager.delete("SP_DELETE_PATIENT_DETAIL", CommandType.StoredProcedure, parameters.ToArray());
                returnValue = "1";
            }
            catch (Exception ex)
            {
                returnValue = "0";
                throw ex;
            }
            return returnValue;
        }
        #endregion
    }
}
