using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http;
using Ninject;
using Samples.Common;

namespace Samples._5.Server.Infrastructure
{
    public class ServerSetup 
    {
        public static HttpSelfHostConfiguration GetConfiguration(string baseAdress)
        {
            var config = new HttpSelfHostConfiguration(baseAdress);

            var kernel = new StandardKernel();
            kernel.Bind<IResumeStore>().To<ResumeStore>();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            config.MessageHandlers.Add(new MethodOverrideHandler());
            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            return config;
        }
    }
}
