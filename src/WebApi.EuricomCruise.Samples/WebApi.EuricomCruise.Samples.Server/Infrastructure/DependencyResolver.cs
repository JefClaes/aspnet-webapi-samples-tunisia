using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;
using WebApi.EuricomCruise.Samples.Server.Controllers;

namespace WebApi.EuricomCruise.Samples.Server.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(BankController))
                return new BankController(new BankStore());

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // Do nothing
        }
    }
}
