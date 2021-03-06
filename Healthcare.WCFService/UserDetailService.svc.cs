﻿#region Namespace
using Healthcare.BusinessLayer.UserDetail;
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFService.Attributes;
using Healthcare.WCFServiceInterface.UserDetail;
using System;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// UserDetailService
    /// </summary>
    [ErrorHandler(typeof(CustomErrorHandler))]
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
            userDetail = userDetailProvider.authenticateUser(userDetail);
            if (null != userDetail && userDetail.ResultType == (int)CommonConstant.ReturnResult.Success)
            {
                userDetail.TokenCreated = DateTime.Now;
                userDetail.Token = CommonMethod.ConvertObjectToJsonString<UserModel>(userDetail);
            }
            return userDetail;
        }
        #endregion
    }
}
