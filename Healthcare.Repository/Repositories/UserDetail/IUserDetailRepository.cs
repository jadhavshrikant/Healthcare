#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Models.UserDetail;
#endregion

namespace Healthcare.Repository.Repositories.UserDetail
{
    /// <summary>
    /// IUserDetailRepository
    /// </summary>
    public interface IUserDetailRepository
    {
        #region Method Declarations
        UserModel authenticateUser(UserModel userDetail);
        #endregion
    }
}
