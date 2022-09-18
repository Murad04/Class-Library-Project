using Microsoft.Extensions.Logging;
using MM.RequestResponseMiddleware.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Models
{
    public class LoggingOptions
    {
        private List<LogFields> loggingFields = null!;

        public LogLevel LogLevel { get; set; } = LogLevel.Information;

        public string LoggerCategoryName { get; set; } = "RequestResponseLoggerMiddleware";

        public List<LogFields> LoggingFields
        {
            get
            {
                return loggingFields ??= new List<LogFields>();
            }
            set => loggingFields = value;
        }
    }
}
