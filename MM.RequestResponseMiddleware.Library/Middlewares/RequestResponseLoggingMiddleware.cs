using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Middlewares
{
    public class RequestResponseLoggingMiddleware : BaseRequestResponseMiddleware
    {
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogWriter logWriter) : base(next,logWriter)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            var requestersponsecontext = await BaseMiddlewareInvoke(context);
        }
    }
}
