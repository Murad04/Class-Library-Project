using MM.RequestResponseMiddleware.Library.Enum;
using MM.RequestResponseMiddleware.Library.Interfaces;
using MM.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.MessageCreators
{
    internal class LoggerFactoryMessageCreator : BaseLogMessageCreator, ILogMessageCreator
    {
        private readonly LoggingOptions options;
        private RequestResponseContext context;

        public LoggerFactoryMessageCreator(LoggingOptions options)
        {
            this.options = options;
        }

        public string Create(RequestResponseContext context)
        {
            var stringBuilder = new StringBuilder();

            foreach (var field in options.LoggingFields)
            {
                var value = GetValueByField(context, field);

                stringBuilder.AppendFormat("{0}: {1}\n", field, value);
            }

            return stringBuilder.ToString();
        }


    }
}
