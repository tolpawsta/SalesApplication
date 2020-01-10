using AutoMapper;
using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using SalesApp.DAL.Repository;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Infrastructure.Repository;
using System.Collections.Generic;

namespace SalesApp.BL.Services
{
    public class ProductService: IService<ProductBL>
    {
        private IRepository<Product> _repo;
        private readonly IMapper _mapper;
        private object _locker = new object();

        public ProductService(IRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void SaveChange()
        {
            _repo.SaveChanges();
        }


        public IEnumerable<ProductBL> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductBL>>(_repo.All);
        }

        public void Remove(ProductBL productBl)
        {
            Product product = _mapper.Map<Product>(productBl);
            _repo.Delete(product);
        }

        public void Update(ProductBL productBl)
        {
            _repo.Update(_mapper.Map<Product>(productBl));
        }

        public void Create(ProductBL productBl)
        {
            _repo.Create(_mapper.Map<Product>(productBl));
        }

        public ProductBL GetById(int id)
        {
            return _mapper.Map<ProductBL>(_repo.GetById(id));
        }

        public bool Check(ProductBL productBL)
        {
            Product product =_repo.Find(_mapper.Map<Product>(productBL));
            return product != null;

        }

        public ProductBL Find(ProductBL productBL)
        {
            Product product= _repo.Find(_mapper.Map<Product>(productBL));
            return _mapper.Map<ProductBL>(product);
        }
    }
}
