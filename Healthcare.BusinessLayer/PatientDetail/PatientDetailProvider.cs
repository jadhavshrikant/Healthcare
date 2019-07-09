#region Namespace
using Healthcare.Models.PatientDetail;
using Healthcare.Repository.Repositories.PatientDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.BusinessLayer.PatientDetail
{
    /// <summary>
    /// PatientDetailProvider
    /// </summary>
    public class PatientDetailProvider : IPatientDetailProvider
    {
        #region Properties
        private readonly IPatientDetailRepository repository;
        #endregion

        #region Constructor

        /// <summary>
        /// PatientDetailProvider
        /// </summary>
        public PatientDetailProvider()
        {
            this.repository = new PatientDetailRepository();
        }
        #endregion

        #region Methods

        /// <summary>
        /// getPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientModel> getPatients()
        {
            return repository.getPatients();
        }

        /// <summary>
        /// getPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public PatientModel getPatientDetail(int patientId)
        {
            return repository.getPatientDetail(patientId);
        }

        /// <summary>
        /// upsertPatientDetail
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        public string upsertPatientDetail(PatientModel patientModel)
        {
            return repository.upsertPatientDetail(patientModel);
        }

        /// <summary>
        /// deletetPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public string deletetPatientDetail(int patientId)
        {
            return repository.deletetPatientDetail(patientId);
        }
        #endregion
    }
}
