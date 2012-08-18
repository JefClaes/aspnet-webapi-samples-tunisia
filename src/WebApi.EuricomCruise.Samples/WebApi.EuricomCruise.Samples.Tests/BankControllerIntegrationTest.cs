using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.SelfHost;
using WebApi.EuricomCruise.Samples.Server.Infrastructure;
using System.Net.Http;
using WebApi.EuricomCruise.Samples.Server;
using System.Net;

namespace WebApi.EuricomCruise.Samples.Tests
{
    [TestClass()]
    public class BankControllerIntegrationTest
    {
        [TestMethod()]
        public void Put_throws_not_implemented_exception()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
            config.Filters.Add(new NotImplementedErrorFilter());
            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            config.Formatters.Add(new EuricomFormatter());
            config.MessageHandlers.Add(new MethodOverrideHandler());
            config.DependencyResolver = new DependencyResolver();

            var server = new HttpServer(config);
            var client = new HttpClient(server);

            var result = client.PutAsXmlAsync<Bank>("http://localhost:8080/api/bank/1", new Bank()).Result;

            Assert.AreEqual(HttpStatusCode.NotImplemented, result.StatusCode);
        }
    }
}
