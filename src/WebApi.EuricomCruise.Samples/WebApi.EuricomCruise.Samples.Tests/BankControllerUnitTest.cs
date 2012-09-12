using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.EuricomCruise.Samples.Server;
using WebApi.EuricomCruise.Samples.Server.Controllers;

namespace WebApi.EuricomCruise.Samples.Tests
{    
    [TestClass()]
    public class BankControllerUnitTest
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void Put_throws_not_implemented_exception()
        {
            var bankController = new BankController(new BankStore());

            bankController.PutBank("1", new Bank() { BIC = "1", Name = "KBC" });
        }
    }
}
