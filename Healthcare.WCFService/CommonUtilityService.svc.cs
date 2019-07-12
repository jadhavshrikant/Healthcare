#region Namespace
using Healthcare.BusinessLayer.Common;
using Healthcare.Models.DashboardDetail;
using Healthcare.Models.MaritalStatusDetails;
using Healthcare.Models.SalutationDetail;
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceInterface;
using Healthcare.WCFServiceInterface.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// CommonUtilityService
    /// </summary>
    public class CommonUtilityService : ICommonUtilityService, IValidateUserService
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
            if (validateUser())
            {
                return commonUtilityProvider.getMaritals();
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }

        /// <summary>
        /// getSalutations
        /// </summary>
        /// <returns></returns>
        public List<SalutationModel> getSalutations()
        {
            if (validateUser())
            {
                return commonUtilityProvider.getSalutations();
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }

        /// <summary>
        /// getDashboardItems
        /// </summary>
        /// <returns></returns>
        public DashboardModel getDashboardItems()
        {
            if (validateUser())
            {
                return commonUtilityProvider.getDashboardItems();
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }
        #endregion

        #region Validate User

        /// <summary>
        /// validateUser
        /// </summary>
        /// <returns></returns>
        public bool validateUser()
        {
            bool isValid = true;
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string encUserDetail = headers["X-Token"];
            if (!string.IsNullOrEmpty(encUserDetail))
            {
                UserModel userModel = CommonMethod.ConvertJsonStringToObject<UserModel>(encUserDetail);
                if (null == userModel || userModel.UserId == 0)
                {
                    isValid = false;
                }
                else if (!TokenValidator.CheckTokenAlive(userModel.TokenCreated, DateTime.Now))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        #endregion
    }
}
