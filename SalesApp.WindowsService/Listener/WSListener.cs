using SalesApp.Infrastructure.Interfaces;
using SalesApp.WindowsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesApp.WindowsService.Listener
{
    internal class WSListener : IWatcherListener, IWSListener
    {
        private IReaderService _readerService;
        private string _path2LogFile;
        public WSListener(IReaderService readerService)
        {
            _readerService = readerService;
            _path2LogFile = ConfigurationManager.AppSettings.Get("DefaultPathToLogFile");
        }

        public void Log(string message)
        {
            if (!File.Exists(_path2LogFile))
            {
                File.Create(_path2LogFile);
            }
            using (var writer = new StreamWriter(_path2LogFile))
            {
                writer.WriteLine($"{new DateTime().Date} \t{message}");
            }
        }


        public void OnCreated(string pathFile)
        {
            Thread.Sleep(1000);
            Task.Factory.StartNew(
                () => _readerService.Begin(pathFile)
                );
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
