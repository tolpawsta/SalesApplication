using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Interfaces
{
    public interface ILogger
    {
        void Start();
        void Stop();
        void Log(string message);
        void LogOnChanged(object sender, FileSystemEventArgs e);
        void LogOnRenamed(object sender, RenamedEventArgs e);
    }
}
