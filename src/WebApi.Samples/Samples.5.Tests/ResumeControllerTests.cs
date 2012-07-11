using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using Samples._5.Server.Infrastructure;
using Samples.Common;

namespace Samples._5.Tests
{
    [TestClass]
    public class ResumeControllerTests
    {
        [TestMethod]
        public void Get_Returns_Something()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            config.MessageHandlers.Add(new MethodOverrideHandler());
            var server = new HttpServer(config);
            var client = new HttpClient(server);

            var result = client.GetAsync("http://test/api/resume/1").Result;
            
            result.EnsureSuccessStatusCode();

            var resume = result.Content.ReadAsAsync<Resume>();

            Assert.IsNotNull(resume);
        }
    }
}
