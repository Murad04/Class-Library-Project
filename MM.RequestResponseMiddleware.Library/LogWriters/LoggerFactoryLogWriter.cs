using Microsoft.Extensions.Logging;
using MM.RequestResponseMiddleware.Library.Interfaces;
using MM.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.LogWriters
{
    internal class LoggerFactoryLogWriter : ILogWriter
    {
        private readonly ILogger iLogger;
        private readonly LoggingOptions loggingOptions;

        public LoggerFactoryLogWriter(ILoggerFactory loggerFactory,LoggingOptions loggingOptions)
        {
            this.iLogger = loggerFactory.CreateLogger(loggingOptions.LoggerCategoryName);
            this.loggingOptions = loggingOptions;
        }

        public Task Write(RequestResponseContext context)
        {
            iLogger.Log(loggingOptions.LogLevel, "");
        }
    }
}
