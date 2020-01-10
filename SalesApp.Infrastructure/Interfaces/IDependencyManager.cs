using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Interfaces
{
    public interface IDependencyManager
    {
        ILogger CreateLogger(ILogger logger);
        IWatcher CreateWatcher(string pathFile);
    }
}
