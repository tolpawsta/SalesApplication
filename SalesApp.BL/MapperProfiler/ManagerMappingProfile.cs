using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SalesApp.BL.MapperProfiler
{
    public class ManagerMappingProfile:Profile
    {
        public ManagerMappingProfile()
        {
            CreateMap<Product, ProductBL>();
            CreateMap<ProductBL, Product>();
            CreateMap<Manager, ManagerBL>();
            CreateMap<ManagerBL, Manager>();
            CreateMap<Customer, CustomerBL>();
            CreateMap<CustomerBL, Customer>();
            CreateMap<Order, OrderBL>();
            CreateMap<OrderBL, Order>();
            CreateMap<Report, ReportBL>();
            CreateMap<ReportBL, Report>();
        }
    }
}
