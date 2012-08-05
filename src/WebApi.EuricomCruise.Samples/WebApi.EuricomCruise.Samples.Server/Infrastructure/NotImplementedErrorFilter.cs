using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Filters;
using System.Net;

namespace WebApi.EuricomCruise.Samples.Server.Infrastructure
{
    public class NotImplementedErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
                actionExecutedContext.Response.StatusCode = HttpStatusCode.NotImplemented;

            base.OnException(actionExecutedContext);
        }
    }
}
