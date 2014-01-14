using System;
using System.Linq;
using Autofac;
using Autofac.Integration.Wcf;

namespace CiaranONeill.NPV.Silverlight.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = Bootstrapper.Configure();
            AutofacHostFactory.Container = container;
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var a = scope.Resolve<NpvDateService>();
            //}
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}