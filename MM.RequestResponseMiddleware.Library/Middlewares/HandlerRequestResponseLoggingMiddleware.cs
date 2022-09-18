using Microsoft.AspNetCore.Http;
using MM.RequestResponseMiddleware.Library.Interfaces;
using MM.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Middlewares
{
    public class HandlerRequestResponseLoggingMiddleware : BaseRequestResponseMiddleware
    {
        private readonly Func<RequestResponseContext,Task> requestResponseHandler;
        private readonly ILogWriter logWriter;

        public HandlerRequestResponseLoggingMiddleware(RequestDelegate next, Func<RequestResponseContext, Task> requestResponseHandler, ILogWriter logWriter):base(next,logWriter)
        {
            this.requestResponseHandler = requestResponseHandler;
            this.logWriter = logWriter;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestResponseContext =await BaseMiddlewareInvoke(context);

            await requestResponseHandler.Invoke(requestResponseContext);
        }
    }
}
