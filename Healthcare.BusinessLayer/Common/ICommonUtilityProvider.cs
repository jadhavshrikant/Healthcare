#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using System.Collections.Generic;
#endregion

namespace Healthcare.BusinessLayer.Common
{
    /// <summary>
    /// ICommonUtilityProvider
    /// </summary>
    public interface ICommonUtilityProvider
    {
        #region Method Declarations

        List<MaritalStatusModel> getMaritals();
        List<SalutationModel> getSalutations();
        DashboardModel getDashboardItems();

        #endregion
    }
}
