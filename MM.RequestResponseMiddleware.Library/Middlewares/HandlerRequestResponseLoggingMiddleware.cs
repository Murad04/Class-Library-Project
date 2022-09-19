using Microsoft.AspNetCore.Http;
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

        public HandlerRequestResponseLoggingMiddleware(RequestDelegate next, Func<RequestResponseContext, Task> requestResponseHandler, ILogWriter logWriter):base(next,logWriter)
        {
            this.requestResponseHandler = requestResponseHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestResponseContext =await BaseMiddlewareInvoke(context);

            await requestResponseHandler.Invoke(requestResponseContext);
        }
    }
}
