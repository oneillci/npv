using System;
using Autofac;

namespace CiaranONeill.NPV.Silverlight
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(NpvServiceProxy)).As<INpvService>();
            //builder.RegisterGeneric(typeof(ICommandHandler<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            _container = builder.Build();

            return _container;
        }

        //public static object Resolve(Type serviceType)
        //{
        //    return _container.Resolve(serviceType);
        //}

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
