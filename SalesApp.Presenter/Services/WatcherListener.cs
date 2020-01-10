using SalesApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesApp.Presenter.Services
{
   public class WatcherListener:IWatcherListener
    {
        private IReaderService _readerService;

        public WatcherListener(IReaderService readerService)
        {
            _readerService = readerService;
        }
        public void OnCreated(string pathFile)
        {
            Thread.Sleep(1000);
            Task.Factory.StartNew(
                () => _readerService.Begin(pathFile)
                );

           
        }
    }
}
