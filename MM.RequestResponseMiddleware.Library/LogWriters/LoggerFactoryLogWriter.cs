using Microsoft.Extensions.Logging;
using MM.RequestResponseMiddleware.Library.Interfaces;
using MM.RequestResponseMiddleware.Library.MessageCreators;
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
        public ILogMessageCreator MessageCreator { get; } = null!;

        public LoggerFactoryLogWriter(ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
        {
            this.iLogger = loggerFactory.CreateLogger(loggingOptions.LoggerCategoryName);
            this.loggingOptions = loggingOptions;

            MessageCreator = new LoggerFactoryMessageCreator(loggingOptions);
        }


        public async Task Write(RequestResponseContext context)
        {
            var message = MessageCreator.Create(context);

            iLogger.Log(loggingOptions.LogLevel, "");

            await Task.CompletedTask;
        }
    }
}
