#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using System.Collections.Generic;
#endregion

namespace Healthcare.Repository.Repositories.Common
{
    /// <summary>
    /// ICommonUtility
    /// </summary>
    public interface ICommonUtilityRepository
    {
        #region Method Declarations

        List<MaritalStatusModel> getMaritals();
        List<SalutationModel> getSalutations();
        DashboardModel getDashboardItems();

        #endregion
    }
}
