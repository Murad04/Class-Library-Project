using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.Enum
{
    public enum LogFields
    {
        Request,
        Response,
        HostName,
        Path,
        QueryString,
        ResponseTiming,
        RequestLength,
        ResponseLength
    }
}
