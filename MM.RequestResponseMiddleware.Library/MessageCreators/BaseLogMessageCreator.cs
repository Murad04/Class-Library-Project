using MM.RequestResponseMiddleware.Library.Enum;
using MM.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.MessageCreators
{
    public abstract class BaseLogMessageCreator
    {
        protected string? GetValueByField(RequestResponseContext context,LogFields fields)
        {
            return fields switch
            {
                LogFields.Request => context.RequestBody,
                LogFields.Response => context.ResponseBody,
                LogFields.QueryString => context.context?.Request?.QueryString.Value,
                LogFields.Path => context.context?.Request?.Path.Value,
                LogFields.HostName => context.context?.Request?.Host.Value,
                LogFields.RequestLength => context.RequestLength.ToString(),
                LogFields.ResponseLength => context.ResponseLength.ToString(),
                LogFields.ResponseTiming => context.FormattedCreationTime,
                _ => string.Empty
            };
        }
    }
}
