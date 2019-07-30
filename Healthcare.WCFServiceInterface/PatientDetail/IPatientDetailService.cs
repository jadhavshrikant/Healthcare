#region Namespace
using Healthcare.Models.PatientDetail;
using System.Collections.Generic;
using System.ServiceModel;
#endregion

namespace Healthcare.WCFServiceInterface.PatientDetail
{
    /// <summary>
    /// IPatientDetailService
    /// </summary>
    [ServiceContract]
    public interface IPatientDetailService
    {
        #region Methods Declaration
        [OperationContract]
        List<PatientModel> getPatients();

        [OperationContract]
        PatientModel getPatientDetail(int patientId);

        [OperationContract]
        string upsertPatientDetail(PatientModel patientModel);

        [OperationContract]
        string deletetPatientDetail(int patientId);
        #endregion
    }
}
