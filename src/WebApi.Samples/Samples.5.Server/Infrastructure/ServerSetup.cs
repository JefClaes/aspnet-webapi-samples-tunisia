using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace Samples._5.Server.Infrastructure
{
    public class ServerSetup 
    {
        public static HttpSelfHostConfiguration GetConfiguration(string baseAdress)
        {
            var config = new HttpSelfHostConfiguration(baseAdress);

            config.Routes.MapHttpRoute(
             "DefaultApi", "api/{controller}/{id}",
             new { id = RouteParameter.Optional });
            config.MessageHandlers.Add(new MethodOverrideHandler());

            return config;
        }
    }
}
