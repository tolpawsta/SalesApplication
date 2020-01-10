using AutoMapper;
using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Infrastructure.Repository;
using System.Collections.Generic;

namespace SalesApp.BL.Services
{
    public class ManagerService: IService<ManagerBL>
    {
        private IRepository<Manager> _repo;
        private readonly IMapper _mapper;

        public ManagerService(IRepository<Manager> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void SaveChange()
        {
            _repo.SaveChanges();
        }


        public IEnumerable<ManagerBL> GetAll()
        {
            return _mapper.Map<IEnumerable<Manager>, IEnumerable<ManagerBL>>(_repo.All);
        }

        public void Remove(ManagerBL managerBl)
        {
            Manager product = _mapper.Map<Manager>(managerBl);
            _repo.Delete(product);
        }

        public void Update(ManagerBL managerBl)
        {
            _repo.Update(_mapper.Map<Manager>(managerBl));
        }

        public void Create(ManagerBL managerBl)
        {
            _repo.Create(_mapper.Map<Manager>(managerBl));
        }

        public ManagerBL GetById(int id)
        {
            return _mapper.Map<ManagerBL>(_repo.GetById(id));
        }

        public bool Check(ManagerBL managerBl)
        {
            Manager manager = _repo.Find(_mapper.Map<Manager>(managerBl));
            return manager != null;
        }

        public ManagerBL Find(ManagerBL managerBL)
        {
            Manager manager = _repo.Find(_mapper.Map<Manager>(managerBL));
            return _mapper.Map<ManagerBL>(manager);
        }
    }
}
