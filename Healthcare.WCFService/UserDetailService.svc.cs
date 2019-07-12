#region Namespace
using Healthcare.BusinessLayer.UserDetail;
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
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
                userDetail = userDetailProvider.authenticateUser(userDetail);
                userDetail.TokenCreated = DateTime.Now;
                userDetail.Token = CommonMethod.ConvertObjectToJsonString<UserModel>(userDetail);
                return userDetail;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        #endregion
    }
}
