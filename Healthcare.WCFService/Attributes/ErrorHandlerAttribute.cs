#region Namespace
using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
#endregion

namespace Healthcare.WCFService.Attributes
{
    /// <summary>
    /// ErrorHandlerAttribute
    /// </summary>
    public class ErrorHandlerAttribute : Attribute, IServiceBehavior
    {
        #region Properties
        private readonly Type errorHandler;
        #endregion

        #region Constructor

        /// <summary>
        /// ErrorHandlerAttribute
        /// </summary>
        /// <param name="errorHandler"></param>
        public ErrorHandlerAttribute(Type errorHandler)
        {
            this.errorHandler = errorHandler;
        }
        #endregion

        #region Methods

        /// <summary>
        /// AddBindingParameters
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        /// <summary>
        /// ApplyDispatchBehavior
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            IErrorHandler handler = (IErrorHandler)Activator.CreateInstance(this.errorHandler);
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    channelDispatcher.ErrorHandlers.Add(handler);
                }
            }
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }
        #endregion
    }
}