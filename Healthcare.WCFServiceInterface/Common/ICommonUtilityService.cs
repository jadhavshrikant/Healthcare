#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using Healthcare.WCFServiceInterface.Attributes;
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
        [ValidateToken]
        List<MaritalStatusModel> getMaritals();

        [OperationContract]
        [ValidateToken]
        List<SalutationModel> getSalutations();

        [OperationContract]
        [ValidateToken]
        DashboardModel getDashboardItems();
        #endregion
    }
}
