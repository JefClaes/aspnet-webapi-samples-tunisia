using WebApi.EuricomCruise.Samples.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApi.EuricomCruise.Samples.Server;

namespace WebApi.EuricomCruise.Samples.Tests
{    
    [TestClass()]
    public class BankControllerUnitTest
    {
        private TestContext testContextInstance;       
        
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void Put_throws_not_implemented_exception()
        {
            var bankController = new BankController(new BankStore());

            bankController.PutBank("1", new Bank() { BIC = "1", Name = "KBC" });            
        }
    }
}
