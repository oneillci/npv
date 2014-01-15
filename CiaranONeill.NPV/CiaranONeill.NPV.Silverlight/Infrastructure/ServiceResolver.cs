using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Browser;
using Autofac;

namespace CiaranONeill.NPV.Silverlight.Infrastructure
{
    public class ServiceResolver
    {
        public static T GetService<T>(int closeTimeout = 600, int openTimeout = 600, int receiveTimeout = 600, int sendTimeout = 600)
        {
            Uri serviceUri = GetServiceUri<T>();
            TransportBindingElement transportBindingElement = serviceUri.Scheme == "http" ?
                new HttpTransportBindingElement { MaxBufferSize = 2147483647, MaxReceivedMessageSize = 2147483647 } :
                new HttpsTransportBindingElement { MaxBufferSize = 2147483647, MaxReceivedMessageSize = 2147483647 };

            var channelFactory = new ChannelFactory<T>(
                new CustomBinding(
                    new BinaryMessageEncodingBindingElement(),
                    transportBindingElement)
                {
                    CloseTimeout = TimeSpan.FromSeconds(closeTimeout),
                    OpenTimeout = TimeSpan.FromSeconds(openTimeout),
                    ReceiveTimeout = TimeSpan.FromSeconds(receiveTimeout),
                    SendTimeout = TimeSpan.FromSeconds(sendTimeout)
                },
                new EndpointAddress(serviceUri));

            var builder = new ContainerBuilder();
            builder.Register(x =>
            {
                return channelFactory.CreateChannel();
            });            
            var container = builder.Build();
            var service = container.Resolve<T>();
            return service;
        }

        private static Uri GetServiceUri<T>()
        {
            var serviceString = GetServiceString<T>();
            var serviceUri = new Uri(HtmlPage.Document.DocumentUri, serviceString);
            return serviceUri;
        }

        /// <summary>
        /// Infers the location of a service (.svc file) from the type of service being requested
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetServiceString<T>()
        {
            Type t = typeof(T);
            if (t.IsAssignableFrom(typeof(INpvDateServiceClient)))
                return "../NpvDateService.svc";
            else
                throw new Exception("Invalid Service Requested!");
        }
    }
}
