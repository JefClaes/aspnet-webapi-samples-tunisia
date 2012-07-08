using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Filters;
using System.Net;

namespace Samples._3.Server.Infrastructure
{
    public class NotImplementedExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
                actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}
