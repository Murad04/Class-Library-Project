using Microsoft.AspNetCore.Http;
using MM.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Middlewares
{
    internal class HandlerRequestResponseLogginMiddleware : BaseRequestResponseMiddleware
    {
        private readonly Func<RequestResponseOptions,Task> requestResponseHandler;

        public HandlerRequestResponseLogginMiddleware(RequestDelegate next, Func<RequestResponseOptions,Task> requestResponseHandler):base(next)
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
