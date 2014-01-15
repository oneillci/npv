﻿using System;
using Autofac;

namespace CiaranONeill.NPV.Silverlight
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(INpvService).Assembly).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(ICommandHandler<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            _container = builder.Build();

            return _container;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
