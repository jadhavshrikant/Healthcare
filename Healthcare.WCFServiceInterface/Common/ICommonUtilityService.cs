#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using System.Collections.Generic;
using System.ServiceModel;
#endregion

namespace Healthcare.WCFServiceInterface.Common
{
    /// <summary>
    /// ICommonUtilityService
    /// </summary>
    [ServiceContract]
    public interface ICommonUtilityService
    {
        #region Method Declarations
        [OperationContract]
        List<MaritalStatusModel> getMaritals();

        [OperationContract]
        List<SalutationModel> getSalutations();

        [OperationContract]
        DashboardModel getDashboardItems();
        #endregion
    }
}
