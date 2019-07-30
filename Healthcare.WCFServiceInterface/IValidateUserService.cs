#region Namespace
using System.ServiceModel;
#endregion

namespace Healthcare.WCFServiceInterface
{
    /// <summary>
    /// IValidateUserService
    /// </summary>
    [ServiceContract]
    public interface IValidateUserService
    {
        #region Method Declarations
        [OperationContract]
        bool validateUser();
        #endregion
    }
}
