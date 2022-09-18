using Microsoft.AspNetCore.Http;
using MM.RequestResponseMiddleware.Library.Models;
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
        public RequestResponseLoggingMiddleware(RequestDelegate next, RequestResponseOptions requestResponseOptions) : base(next)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            await BaseMiddlewareInvoke(context);
        }
    }
}
