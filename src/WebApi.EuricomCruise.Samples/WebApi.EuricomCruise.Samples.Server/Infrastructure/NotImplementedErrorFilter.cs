using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

namespace WebApi.EuricomCruise.Samples.Server.Infrastructure
{
    public class NotImplementedErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);

            base.OnException(actionExecutedContext);
        }
    }
}
