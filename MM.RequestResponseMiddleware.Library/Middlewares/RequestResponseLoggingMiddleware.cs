using Microsoft.AspNetCore.Http;
using MM.RequestResponseMiddleware.Library.Interfaces;
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
        private readonly ILogWriter logWriter;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogWriter logWriter) : base(next,logWriter)
        {
            this.logWriter = logWriter;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestersponsecontext = await BaseMiddlewareInvoke(context);
        }
    }
}
