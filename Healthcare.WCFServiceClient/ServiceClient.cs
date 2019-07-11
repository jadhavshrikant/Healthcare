#region Namespace
using System;
using System.ServiceModel;
#endregion

namespace Healthcare.WCFServiceClient
{
    /// <summary>
    /// ServiceClient
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceClient<T>
    {
        #region Properties

        /// <summary>
        /// channel
        /// </summary>
        public ChannelFactory<T> channel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// ServiceClient
        /// </summary>
        /// <param name="endpointAddressUrl"></param>
        public ServiceClient(string endpointAddressUrl)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress(endpointAddressUrl);
            channel = new ChannelFactory<T>(binding, endpointAddress);
        }
        #endregion

        #region Methods

        /// <summary>
        /// CreateChannel
        /// </summary>
        /// <returns></returns>
        public T CreateChannel()
        {
            return channel.CreateChannel();
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="action"></param>
        public void Execute(Action<T> action)
        {
            T proxy = CreateChannel();
            action(proxy);
            ((ICommunicationObject)proxy).Close();
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        public TResult Execute<TResult>(Func<T, TResult> function)
        {
            T proxy = CreateChannel();
            var result = function(proxy);
            ((ICommunicationObject)proxy).Close();
            return result;
        }
        #endregion
    }
}
