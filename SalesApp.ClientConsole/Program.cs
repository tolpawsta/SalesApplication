using SalesApp.Infrastructure.Interfaces;
using SalesApp.PL.Presenter;
using System;
using System.Configuration;

namespace SalesApp.ClientConsole
{
    class Program
    {


        static void Main(string[] args)
        {           
            
            string pathFile = ConfigurationManager.AppSettings.Get("PathWatcherFolder");
            IPresenter presenter = new AppPresenter();
            
                presenter.StartWatching(pathFile);
           
            do
            {
                Console.WriteLine("Press Escape for stop, cuntinue press AnyKey...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            presenter.Stop();

            Console.ReadLine();
        }
    }
}
