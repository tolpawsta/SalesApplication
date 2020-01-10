using System;

namespace SalesApp.Infrastructure.Interfaces
{
    public interface ILoggable
    {
        event Action<string> LogEvent;
    }
}
