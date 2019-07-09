#region Namespace
using Healthcare.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.BusinessLayer.UserDetail
{
    /// <summary>
    /// IUserDetailProvider
    /// </summary>
    public interface IUserDetailProvider
    {
        #region Method Declarations
        UserModel authenticateUser(UserModel userDetail);
        #endregion
    }
}
