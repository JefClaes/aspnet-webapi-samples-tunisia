using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using Samples._5.Server.Infrastructure;
using Samples.Common;
using System.Net;
using Moq;
using System.Web.Http.Dependencies;
using Samples._5.Server.Controllers;

namespace Samples._5.Tests
{
    [TestClass]
    public class ResumeControllerIntegrationTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            var resumeStore = new Mock<IResumeStore>();
            resumeStore
              .Setup(rs => rs.GetById("1"))
              .Returns(new Resume("Jef", "Claes"));
            var dependencyResolver = new Mock<IDependencyResolver>();
            dependencyResolver
                .Setup(r => r.GetService(typeof(ResumeController)))
                .Returns(new ResumeController(resumeStore.Object));
            dependencyResolver
                .Setup(dr => dr.BeginScope())
                .Returns((IDependencyScope)dependencyResolver.Object);
            dependencyResolver
                .Setup(dr => dr.GetServices(It.IsAny<Type>()))
                .Returns(new List<object>());

            var config = ServerSetup.GetConfiguration("http://test");
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;            
            config.DependencyResolver = dependencyResolver.Object;

            var server = new HttpServer(config);

            _client = new HttpClient(server);
        }

        [TestMethod]
        public void Get_Returns_Something()
        {              
            var result = _client.GetAsync("http://test/api/resume/1").Result;
            
            result.EnsureSuccessStatusCode();

            var resume = result.Content.ReadAsAsync<Resume>();

            Assert.IsNotNull(resume);
        }

        [TestMethod]
        public void Delete_Returns_HttpStatus_Code_No_Content()
        {
            var result = _client.DeleteAsync("http://test/api/resume/1").Result;

            result.EnsureSuccessStatusCode();            

            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }        
    }
}
