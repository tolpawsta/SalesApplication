using SalesApp.Infrastructure;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Presenter.DI;
using SalesApp.Presenter.Services;
using System;

namespace SalesApp.PL.Presenter
{
    public class AppPresenter:IPresenter
    {
        private IWatcher _watcher;
       public void StartWatching(string pathFile)
        {
            var manager = Configurator.CreateManager(new DependencyManager());
            
            _watcher = manager.CreateWatcher(pathFile);
            _watcher.LogEvent += s => Console.WriteLine(s);
            _watcher.Start();
            IReaderService readerService = new ReaderService();
            IWatcherListener listener = new WatcherListener(readerService);
            _watcher.Created += m => listener.OnCreated(m);
        }
        public void Stop()
        {
            _watcher.Stop();
        }
    }
}
