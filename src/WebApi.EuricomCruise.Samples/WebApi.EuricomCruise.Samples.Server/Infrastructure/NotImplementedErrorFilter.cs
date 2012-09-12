using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi.EuricomCruise.Samples.Server.Infrastructure
{
    public class NotImplementedErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.NotImplemented);

            base.OnException(actionExecutedContext);
        }
    }
}
