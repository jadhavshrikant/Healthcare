#region Namespace
using Healthcare.Models.PatientDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.Repository.Repositories.PatientDetail
{
    /// <summary>
    /// IPatientDetailRepository
    /// </summary>
    public interface IPatientDetailRepository
    {
        #region Method Declarations
        List<PatientModel> getPatients();
        PatientModel getPatientDetail(int patientId);
        string upsertPatientDetail(PatientModel patientModel);
        string deletetPatientDetail(int patientId);
        #endregion
    }
}
