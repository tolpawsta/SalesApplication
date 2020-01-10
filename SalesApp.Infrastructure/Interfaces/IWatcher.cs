using System;

namespace SalesApp.Infrastructure.Interfaces
{
    public interface IWatcher:ILoggable
    {
        event Action<string> Created;
        void Stop();
        void Start();
    }
}
