using SalesApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System;
using SalesApp.Presenter.Services;
using SalesApp.PL.Presenter;
using System.Configuration;
using SalesApp.WindowsService.Interfaces;
using SalesApp.WindowsService.Listener;

namespace SalesApp.WindowsService
{
    public partial class MainService : ServiceBase
    {
        private IWatcher _watcher;
        public MainService()
        {
            InitializeComponent();
            string pathFile = ConfigurationManager.AppSettings.Get("PathWatcherFolder");
            _watcher = new FileWatcher(pathFile);
        }

        protected override void OnStart(string[] args)
        {
            IReaderService readerService = new ReaderService();
            IWSListener listener = new WSListener(readerService);

            _watcher.LogEvent += m => listener.Log(m);
            _watcher.Start();


        }

        protected override void OnStop()
        {
            _watcher.Stop();
        }
    }
}
