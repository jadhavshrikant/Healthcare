#region Namespace
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using Healthcare.Repository.Repositories.Common;
using System.Collections.Generic;
#endregion

namespace Healthcare.BusinessLayer.Common
{
    /// <summary>
    /// CommonUtilityProvider
    /// </summary>
    public class CommonUtilityProvider : ICommonUtilityProvider
    {
        #region Properties
        private readonly ICommonUtilityRepository repository;
        #endregion

        #region Constructor

        /// <summary>
        /// CommonUtilityProvider
        /// </summary>
        public CommonUtilityProvider()
        {
            this.repository = new CommonUtilityRepository();
        }
        #endregion

        #region Methods

        /// <summary>
        /// getMaritals
        /// </summary>
        /// <returns></returns>
        public List<MaritalStatusModel> getMaritals()
        {
            return repository.getMaritals();
        }

        /// <summary>
        /// getSalutations
        /// </summary>
        /// <returns></returns>
        public List<SalutationModel> getSalutations()
        {
            return repository.getSalutations();
        }

        /// <summary>
        /// getDashboardItems
        /// </summary>
        /// <returns></returns>
        public DashboardModel getDashboardItems()
        {
            return repository.getDashboardItems();
        }
        #endregion
    }
}
