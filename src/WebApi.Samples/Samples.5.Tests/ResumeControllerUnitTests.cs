using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples._5.Server.Controllers;
using System.Net;
using Samples.Common;
using Moq;

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
    }
}
