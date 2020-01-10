using System;
using System.Linq;

namespace SalesApp.Infrastructure.Repository
{
    public interface IRepository<T>:IDisposable where T : class
    {
        void SaveChanges();
        IQueryable<T> All { get; }
        void Delete(T entity);
        void Create(T entity);
        T GetById(int id);
        void Update(T entity);
        bool isExists(T entity);
        T Find(T entity);
    }
}
