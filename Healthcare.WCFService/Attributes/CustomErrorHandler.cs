#region Namespace
using Healthcare.Logging;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
#endregion

namespace Healthcare.WCFService.Attributes
{
    /// <summary>
    /// CustomErrorHandler
    /// </summary>
    public class CustomErrorHandler : IErrorHandler
    {
        /// <summary>
        /// HandleError
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool HandleError(Exception error)
        {
            LogHelper.Error(error.Message, error);
            return true;
        }

        /// <summary>
        /// ProvideFault
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;
            FaultException faultException = new FaultException(error.Message);
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }
    }
}