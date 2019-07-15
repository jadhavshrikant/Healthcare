#region Namespace
using Healthcare.BusinessLayer.Common;
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using Healthcare.WCFService.Attributes;
using Healthcare.WCFServiceInterface.Common;
using System.Collections.Generic;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// CommonUtilityService
    /// </summary>
    [ErrorHandler(typeof(CustomErrorHandler))]
    public class CommonUtilityService : ICommonUtilityService
    {
        #region Properties
        private readonly ICommonUtilityProvider commonUtilityProvider;
        #endregion

        #region Constructor 

        /// <summary>
        /// CommonUtilityService
        /// </summary>
        public CommonUtilityService()
        {
            this.commonUtilityProvider = new CommonUtilityProvider();
        }

        #endregion

        #region Methods

        /// <summary>
        /// getMaritals
        /// </summary>
        /// <returns></returns>
        public List<MaritalStatusModel> getMaritals()
        {
            return commonUtilityProvider.getMaritals();
        }

        /// <summary>
        /// getSalutations
        /// </summary>
        /// <returns></returns>
        public List<SalutationModel> getSalutations()
        {
            return commonUtilityProvider.getSalutations();
        }

        /// <summary>
        /// getDashboardItems
        /// </summary>
        /// <returns></returns>
        public DashboardModel getDashboardItems()
        {
            return commonUtilityProvider.getDashboardItems();
        }
        #endregion
    }
}
