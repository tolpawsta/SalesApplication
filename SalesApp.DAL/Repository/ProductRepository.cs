using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Repository;
using System.Data.Entity;
using System.Linq;

namespace SalesApp.DAL.Repository
{
    public class ProductRepository:IRepository<Product>
    {
        private SalesContext _context;
        private DbSet<Product> _db;

        public IQueryable<Product> All => _db;

        public ProductRepository(SalesContext context)
        {
            _context = context;
            _db = _context?.Product;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
          var productTarget =_db.Where(p => p.Name == product.Name).FirstOrDefault();
              if(productTarget!=null) _db.Remove(productTarget);
           
        }

        public void Create(Product product)
        {
            _db.Add(product);
        }

        public Product GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
        public bool isExists(Product product)
        {
           var checkProduct= _db.Where(p => p.Name == product.Name).FirstOrDefault();
            if (checkProduct!=null)
            {
                return true;
            }
            return false;
        }
        public Product Find(Product product)
        {
           return _db.Where(p => p.Name == product.Name).FirstOrDefault();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
