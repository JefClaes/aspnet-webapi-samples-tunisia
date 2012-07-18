using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;
using System.ServiceModel.Channels;

namespace Samples._6.Server.Infrastructure
{
    public class SecureConfiguration : HttpSelfHostConfiguration
    {
        public SecureConfiguration(string baseAdress) : base(baseAdress) { }

        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = System.Web.Http.SelfHost.Channels.HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
            
            var bc = base.OnConfigureBinding(httpBinding);

            return bc;
        }
    }
}
