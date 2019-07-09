#region Namespace
using System;
using System.Configuration;
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
        /// Channel
        /// </summary>
        public ChannelFactory<T> Channel { get; set; }

        /// <summary>
        /// serviceAddressURL
        /// </summary>
        public string serviceAddressURL { get; }
        #endregion

        #region Constructor

        /// <summary>
        /// ServiceClient
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="serviceName"></param>
        public ServiceClient(string endpoint, string serviceName)
        {
            serviceAddressURL = ConfigurationManager.AppSettings["ServiceAddressURL"];
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress(serviceAddressURL + serviceName);
            Channel = new ChannelFactory<T>(binding, endpointAddress);
        }
        #endregion

        #region Methods

        /// <summary>
        /// CreateChannel
        /// </summary>
        /// <returns></returns>
        public T CreateChannel()
        {
            return Channel.CreateChannel();
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
