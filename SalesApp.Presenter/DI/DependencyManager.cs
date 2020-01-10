using SalesApp.Infrastructure.Interfaces;
using SalesApp.Presenter.Services;

namespace SalesApp.Presenter.DI
{
    public class DependencyManager:IDependencyManager
    {
        public ILogger CreateLogger(ILogger logger)
        {
            return logger;
        }

        public IWatcher CreateWatcher(string pathFile)
        {
            return new FileWatcher(pathFile);
        }
    }
}
