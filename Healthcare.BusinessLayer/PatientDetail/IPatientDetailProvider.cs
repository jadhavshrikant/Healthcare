#region Namespace
using Healthcare.Models.PatientDetail;
using System.Collections.Generic;
#endregion

namespace Healthcare.BusinessLayer.PatientDetail
{
    /// <summary>
    /// IPatientDetailProvider
    /// </summary>
    public interface IPatientDetailProvider
    {
        #region Method Declarations
        List<PatientModel> getPatients();
        PatientModel getPatientDetail(int patientId);
        string upsertPatientDetail(PatientModel patientModel);
        string deletetPatientDetail(int patientId);
        #endregion
    }
}
