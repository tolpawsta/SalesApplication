using AutoMapper;
using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Infrastructure.Repository;
using System.Collections.Generic;

namespace SalesApp.BL.Services
{
    public class CustomerService:IService<CustomerBL>
    {
        private IRepository<Customer> _repo;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void SaveChange()
        {
            _repo.SaveChanges();
        }


        public IEnumerable<CustomerBL> GetAll()
        {
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerBL>>(_repo.All);
        }

        public void Remove(CustomerBL reportBl)
        {
            Customer report = _mapper.Map<Customer>(reportBl);
            _repo.Delete(report);
        }

        public void Update(CustomerBL reportBl)
        {
            _repo.Update(_mapper.Map<Customer>(reportBl));
        }

        public void Create(CustomerBL reportBl)
        {
            _repo.Create(_mapper.Map<Customer>(reportBl));
        }

        public CustomerBL GetById(int id)
        {
            return _mapper.Map<CustomerBL>(_repo.GetById(id));
        }

        public bool Check(CustomerBL customerBl)
        {
            Customer customer = _repo.Find(_mapper.Map<Customer>(customerBl));
            return customer != null;
        }

        public CustomerBL Find(CustomerBL customerBL)
        {

            Customer customer = _repo.Find(_mapper.Map<Customer>(customerBL));
            return _mapper.Map<CustomerBL>(customer);
        }
    }
}
