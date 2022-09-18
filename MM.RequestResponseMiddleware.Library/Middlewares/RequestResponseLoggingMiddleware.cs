using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;

        public async Task Invoke(HttpContext context )
        {
            await next(context);
        }
    }
}
