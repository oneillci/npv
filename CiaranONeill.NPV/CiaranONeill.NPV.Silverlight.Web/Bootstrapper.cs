using System;
using System.Linq;
using Autofac;
using CiaranONeill.NPV.Calculator;

namespace CiaranONeill.NPV.Silverlight.Web
{
    public class Bootstrapper
    {
        //private static IContainer _container;

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(INpvCalculator).Assembly).AsImplementedInterfaces();
            builder.RegisterType<NpvService>();
            builder.RegisterType<NpvDateService>();
            return builder.Build();
        }
    }
}