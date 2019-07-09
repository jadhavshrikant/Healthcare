#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Models.UserDetail;
using Healthcare.Repository.Repositories.UserDetail;
#endregion

namespace Healthcare.BusinessLayer.UserDetail
{
    /// <summary>
    /// UserDetailProvider
    /// </summary>
    public class UserDetailProvider : IUserDetailProvider
    {
        #region Properties
        private readonly IUserDetailRepository repository;
        #endregion

        #region Constructor

        /// <summary>
        /// UserDetailProvider
        /// </summary>
        public UserDetailProvider()
        {
            this.repository = new UserDetailRepository();
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
            return repository.authenticateUser(userDetail);
        }

        #endregion
    }
}
