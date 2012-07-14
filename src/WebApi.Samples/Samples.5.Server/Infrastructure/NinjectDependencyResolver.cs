﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject;

namespace Samples._5.Server.Infrastructure
{
    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver
    {             
       private IKernel _kernel;

       public NinjectDependencyResolver(IKernel kernel) : base(kernel)
       {           
            _kernel = kernel;           
       }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        } 
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }
}
