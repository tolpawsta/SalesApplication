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
            string s = "5,73";
            decimal d = decimal.Parse(s);
            #region Example1
            //Product product = new Product() { Name = "Clipboard" };
            //SalesContext context = new SalesContext();
            //context.Product.Add(product);
            //Console.WriteLine($"{product.ToString()} added");
            //context.SaveChanges();
            /*
            Product product = new Product() { Name = "Glue" };
            SalesContext context = new SalesContext();
            IRepository<Product> productRepo = new ProductRepository(context);
            productRepo.Create(product);
            Console.WriteLine($"Product \"{product.Name}\" added");
            productRepo.SaveChanges();

            if (productRepo.isExists(product))
            {
                productRepo.Delete(product);
                Console.WriteLine($"{product.Name} deleted");
                productRepo.SaveChanges();
            }
            else
            {
                Console.WriteLine($"{product.Name} not exists");
            }

    */
            #endregion

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
