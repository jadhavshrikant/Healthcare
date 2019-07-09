#region Namespace
using Healthcare.BusinessLayer.PatientDetail;
using Healthcare.Models.PatientDetail;
using Healthcare.WCFServiceInterface.PatientDetail;
using System.Collections.Generic;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// PatientDetailService
    /// </summary>
    public class PatientDetailService : IPatientDetailService
    {
        #region Properties
        private readonly IPatientDetailProvider patientDetailProvider;
        #endregion

        #region Constructor 

        /// <summary>
        /// PatientDetailService
        /// </summary>
        public PatientDetailService()
        {
            this.patientDetailProvider = new PatientDetailProvider();
        }

        #endregion

        #region Methods

        /// <summary>
        /// getPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientModel> getPatients()
        {
            return patientDetailProvider.getPatients();
        }

        /// <summary>
        /// getPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public PatientModel getPatientDetail(int patientId)
        {
            return patientDetailProvider.getPatientDetail(patientId);
        }

        /// <summary>
        /// upsertPatientDetail
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        public string upsertPatientDetail(PatientModel patientModel)
        {
            return patientDetailProvider.upsertPatientDetail(patientModel);
        }

        /// <summary>
        /// deletetPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public string deletetPatientDetail(int patientId)
        {
            return patientDetailProvider.deletetPatientDetail(patientId);
        }
        #endregion
    }
}
