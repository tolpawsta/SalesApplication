using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Repository;
using System.Data.Entity;
using System.Linq;

namespace SalesApp.DAL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private SalesContext _context;
        private DbSet<Customer> _db;

        public IQueryable<Customer> All => _db;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
            _db = _context?.Customer;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(Customer customer)
        {
          var customerTarget = _db.Where(p => (p.FirstName == customer.FirstName && p.LastName==customer.LastName)||p.Id==customer.Id).FirstOrDefault();
              if(customerTarget != null) _db.Remove(customerTarget);
           
        }

        public void Create(Customer customer)
        {
            _db.Add(customer);
        }

        public Customer GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
        public bool isExists(Customer customer)
        {
           var checkCustomer = _db.Where(p=>(p.FirstName == customer.FirstName && p.LastName == customer.LastName) || p.Id == customer.Id).FirstOrDefault();
            if (checkCustomer != null)
            {
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Customer Find(Customer customer)
        {
            return _db.Where(p => p.LastName == customer.LastName && p.FirstName == customer.FirstName).FirstOrDefault();
        }
    }
}
