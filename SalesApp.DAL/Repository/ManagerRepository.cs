using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Repository;
using System.Data.Entity;
using System.Linq;

namespace SalesApp.DAL.Repository
{
   public class ManagerRepository : IRepository<Manager>
    {
        private SalesContext _context;
        private DbSet<Manager> _db;

        public IQueryable<Manager> All => _db;

        public ManagerRepository(SalesContext context)
        {
            _context = context;
            _db = _context?.Manager;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(Manager manager)
        {
            var customerTarget = _db.Where(p => p.Name == manager.Name).FirstOrDefault();
            if (customerTarget != null) _db.Remove(customerTarget);

        }

        public void Create(Manager manager)
        {
            _db.Add(manager);
        }

        public Manager GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(Manager manager)
        {
            _context.Entry(manager).State = EntityState.Modified;
        }
        public bool isExists(Manager manager)
        {
            var checkManager = _db.Where(p => p.Name == manager.Name).FirstOrDefault();
            if (checkManager != null)
            {
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Manager Find(Manager manager)
        {
            return _db.Where(p => p.Name == manager.Name).FirstOrDefault();
        }
    }
}
