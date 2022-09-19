using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddMMRequestResponseMiddleware(this IApplicationBuilder appBuilder, Action<RequestResponseOptions> optionActions)
        {
            var options = new RequestResponseOptions();
            optionActions(options);

            ILogWriter logWriter = options.LoggerFactory is null
                ? new NullLogWriter()
                : new LoggerFactoryLogWriter(options.LoggerFactory, options.LoggingOptions);

            if (options.RequestResponseHandler is not null) appBuilder.UseMiddleware<HandlerRequestResponseLoggingMiddleware>(options.RequestResponseHandler, logWriter);
            else appBuilder.UseMiddleware<RequestResponseLoggingMiddleware>(logWriter);

            return appBuilder;
        }
    }
}
