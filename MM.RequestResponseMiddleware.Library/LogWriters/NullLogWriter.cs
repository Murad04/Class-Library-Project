
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.RequestResponseMiddleware.Library.LogWriters
{
    internal class NullLogWriter : ILogWriter
    {
        public ILogMessageCreator MessageCreator { get; }

        public Task Write(RequestResponseContext context)
        {
            return Task.CompletedTask;
        }
    }
}
