using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace Healthcare.WCFService
{
    public class StructureMapServiceBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var endpointDispatchers = serviceHostBase.ChannelDispatchers
                                                     .OfType<ChannelDispatcher>()
                                                           .SelectMany(cd => cd.Endpoints);

            foreach (var endpointDispatcher in endpointDispatchers)
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider =
                    new StructureMapInstanceProvider(serviceDescription.ServiceType);
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,
                                         ServiceHostBase serviceHostBase,
                                         Collection<ServiceEndpoint> endpoints,
                                     BindingParameterCollection bindingParameters)
        { }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        { }
    }
}