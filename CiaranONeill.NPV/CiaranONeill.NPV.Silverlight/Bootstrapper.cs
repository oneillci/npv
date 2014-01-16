using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using Autofac;
using Caliburn.Micro;
using CiaranONeill.NPV.Silverlight.Proxies;
using CiaranONeill.NPV.Silverlight.ViewModels;

namespace CiaranONeill.NPV.Silverlight
{
    public class Bootstrapper : BootstrapperBase
    {
        private static IContainer _container;

        public Bootstrapper()
        {
            Start();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MainViewModel>();
            builder.RegisterAssemblyTypes(typeof(INpvService).Assembly).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(ICommandHandler<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            _container = builder.Build();

            MessageBinder.SpecialValues["$text"] = context =>
            {
                var textBox = (TextBox)context.Source;
                return textBox.Text;
            };
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.Resolve(service);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
               {
                   GetType().Assembly, 
                   typeof(MainViewModel).Assembly
               };
        }

        protected override void OnUnhandledException(object sender, System.Windows.ApplicationUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
        }

        //protected override IEnumerable<object> GetAllInstances(Type service)
        //{
        //    return container.GetAllInstances(service);
        //}

        //protected override void BuildUp(object instance)
        //{
        //    _container.Build();
        //}

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        //public static IContainer Configure()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterAssemblyTypes(typeof(INpvService).Assembly).AsImplementedInterfaces();
        //    //builder.RegisterGeneric(typeof(ICommandHandler<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
        //    _container = builder.Build();

        //    return _container;
        //}

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
