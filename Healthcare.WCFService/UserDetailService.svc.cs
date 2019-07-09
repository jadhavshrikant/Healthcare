#region Namespace
using Healthcare.BusinessLayer.UserDetail;
using Healthcare.Models.UserDetail;
using Healthcare.WCFServiceInterface.UserDetail;
using System;
using System.ServiceModel;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// UserDetailService
    /// </summary>
    public class UserDetailService : IUserDetailService
    {
        #region Properties
        private readonly IUserDetailProvider userDetailProvider;
        #endregion

        #region Constructor 

        /// <summary>
        /// UserDetailService
        /// </summary>
        public UserDetailService()
        {
            this.userDetailProvider = new UserDetailProvider();
        }

        #endregion

        #region Methods

        /// <summary>
        /// authenticateUser
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns></returns>
        public UserModel authenticateUser(UserModel userDetail)
        {
            try
            {
                return userDetailProvider.authenticateUser(userDetail);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        #endregion
    }
}
