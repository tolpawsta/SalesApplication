using AutoMapper;
using SalesApp.BL.MapperProfiler;
using SalesApp.BL.Models;
using SalesApp.BL.Services;
using SalesApp.DAL.Model;
using SalesApp.DAL.Repository;
using SalesApp.Infrastructure.Interfaces;
using System;
using System.IO;

namespace SalesApp.Presenter.Services
{
    public class ReaderService : IReaderService
    {

        private MapperConfiguration config;
        private IMapper _mapper;
        private object _lock = new object();

        public ReaderService()
        {

            config = new MapperConfiguration(cfg => cfg.AddProfile(new ManagerMappingProfile()));
            _mapper = new Mapper(config);
        }

        public void Begin(string pathFile)
        {

            using (var reader = new StreamReader(pathFile))
            {
                IService<ProductBL> productService = new ProductService(new ProductRepository(new SalesContext()), _mapper);
                IService<OrderBL> orderService = new OrderService(new OrderRepository(new SalesContext()), _mapper);
                IService<ManagerBL> managerService = new ManagerService(new ManagerRepository(new SalesContext()), _mapper);
                IService<ReportBL> reportService = new ReportService(new ReportRepository(new SalesContext()), _mapper);
                IService<CustomerBL> customerService = new CustomerService(new CustomerRepository(new SalesContext()), _mapper);
                using (var csvReader = new CsvFileReader(pathFile))
                {
                    csvReader.Dilimiter = ';';

                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {

                        csvReader.CreateObject(record);
                        ProductBL product = csvReader.GetProduct();
                        CustomerBL customer = csvReader.GetCustomer();
                        ManagerBL manager = csvReader.GetManager();
                        DoWorkWithEntity(ref product, productService, _lock);
                        DoWorkWithEntity(ref manager, managerService, _lock);
                        DoWorkWithEntity(ref customer, customerService, _lock);
                        ReportBL report = csvReader.GetReport(manager.Id);
                        report.Manager = manager;
                        DoWorkWithEntity(ref report, reportService, _lock);
                        OrderBL order = csvReader.GetOrder(customer.Id, product.Id, report.Id);
                        DoWorkWithEntity(ref order, orderService, _lock);


                    }
                }
            }



        }
        private void DoWorkWithEntity<Entity, Service>(ref Entity entity, Service service, object _lock) where Entity : class
            where Service : IService<Entity>
        {
            if (!service.Check(entity))
            {
                lock (_lock)
                {
                    if (!service.Check(entity))
                    {
                        service.Create(entity);
                        service.SaveChange();
                        entity = service.Find(entity);
                    }
                }

            }

        }

    }
}
