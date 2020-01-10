using System.Collections.Generic;

namespace SalesApp.Infrastructure.Interfaces
{
    public interface IService<T> where T : class
    {

        IEnumerable<T> GetAll();
        void Remove(T entity);

        void Update(T entity);
        void Create(T entity);
        bool Check(T entity);
        T GetById(int id);
        T Find(T entity);

        void SaveChange();
    }
}
