using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http;
using WebApi.EuricomCruise.Samples.Server.Infrastructure;

namespace WebApi.EuricomCruise.Samples.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
            config.Filters.Add(new NotImplementedErrorFilter());
            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            config.Formatters.Add(new EuricomFormatter());
            config.MessageHandlers.Add(new MethodOverrideHandler());

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
