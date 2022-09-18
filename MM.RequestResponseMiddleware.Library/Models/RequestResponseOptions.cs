using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Models
{
    public class RequestResponseOptions
    {
        internal ILoggerFactory LoggerFactory;
        internal LoggingOptions LoggingOptions;

        internal Func<RequestResponseContext, Task> RequestResponseHandler { get; set; }

        public void UseHandler(Func<RequestResponseContext, Task> requestResponseHandler)
        {
            RequestResponseHandler = requestResponseHandler;
        }

        public void UseLogger(ILoggerFactory loggerFactory, Action<LoggingOptions> logginAction)
        {
            LoggingOptions = new LoggingOptions();
            logginAction(LoggingOptions);

            LoggerFactory = loggerFactory;
        }
    }
}