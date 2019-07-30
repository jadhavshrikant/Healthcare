#region Namespace
using Healthcare.Models.UserDetail;
using System.ServiceModel;
#endregion

namespace Healthcare.WCFServiceInterface.UserDetail
{
    /// <summary>
    /// IUserDetailService
    /// </summary>
    [ServiceContract]
    public interface IUserDetailService
    {
        #region Methods Declaration]

        [OperationContract]
        UserModel authenticateUser(UserModel userDetail);

        #endregion
    }
}
