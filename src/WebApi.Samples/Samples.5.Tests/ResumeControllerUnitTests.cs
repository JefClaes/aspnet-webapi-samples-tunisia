using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples._5.Server.Controllers;
using System.Net;
using Samples.Common;
using Moq;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;

namespace Samples._5.Tests
{
    [TestClass]
    public class ResumeControllerUnitTests
    {
        [TestMethod]
        public void Get_Returns_Something()
        {
            var resumeStore = new Mock<IResumeStore>();
            resumeStore
                .Setup(rs => rs.GetById("1"))
                .Returns(new Resume("Jef", "Claes"));
            var controller = new ResumeController(resumeStore.Object);

            var result = controller.GetById("1");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_Returns_HttpStatus_Code_No_Content()
        {
            var controller = new ResumeController(new Mock<IResumeStore>().Object);

            var result = controller.DeleteResume("1");

            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }       

        [TestMethod]
        public void Post_Returns_HttpStatus_Code_Created()
        {
            // http://www.peterprovost.org/blog/2012/06/16/unit-testing-asp-dot-net-web-api/
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/resume");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "resume" } });
            var controller = new ResumeController(new Mock<IResumeStore>().Object);
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;    

            var result = controller.PostResume(new Resume("Jef", "Claes"));

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
