using AutoMapper;
using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Infrastructure.Repository;
using System.Collections.Generic;

namespace SalesApp.BL.Services
{
    public class OrderService: IService<OrderBL>
    {
        private IRepository<Order> _repo;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void SaveChange()
        {
            _repo.SaveChanges();
        }


        public IEnumerable<OrderBL> GetAll()
        {
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderBL>>(_repo.All);
        }

        public void Remove(OrderBL orderBl)
        {
            Order order = _mapper.Map<Order>(orderBl);
            _repo.Delete(order);
        }

        public void Update(OrderBL orderBl)
        {
            _repo.Update(_mapper.Map<Order>(orderBl));
        }

        public void Create(OrderBL orderBl)
        {
            _repo.Create(_mapper.Map<Order>(orderBl));
        }

        public OrderBL GetById(int id)
        {
            return _mapper.Map<OrderBL>(_repo.GetById(id));
        }

        public bool Check(OrderBL orderBl)
        {
            
            Order order = _repo.Find(_mapper.Map<Order>(orderBl));
            return order != null;
        }

        public OrderBL Find(OrderBL orderBL)
        {
            Order product = _repo.Find(_mapper.Map<Order>(orderBL));
            return _mapper.Map<OrderBL>(product);
        }
    }
}
