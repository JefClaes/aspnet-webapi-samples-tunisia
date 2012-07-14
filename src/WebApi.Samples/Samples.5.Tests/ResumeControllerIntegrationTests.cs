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
using Ninject;
using System.Net.Http.Formatting;

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

            var kernel = new StandardKernel();
            kernel.Bind<IResumeStore>().ToConstant(resumeStore.Object);

            var config = ServerSetup.GetConfiguration("http://test");
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;                        

            _client = new HttpClient(new HttpServer(config));
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

        [TestMethod]
        public void Post_Returns_HttpStatus_Code_Created()
        {
            var result = _client.PostAsync<Resume>("http://test/api/resume", new Resume("Jef", "Claes"), new JsonMediaTypeFormatter()).Result;

            result.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
