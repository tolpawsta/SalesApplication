using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.DAL.Repository
{
   public class OrderRepository : IRepository<Order>
    {
        private SalesContext _context;
        private DbSet<Order> _db;

        public IQueryable<Order> All => _db;

        public OrderRepository(SalesContext context)
        {
            _context = context;
            _db = _context?.Order;
        }
       
        public void Create(Order order)
        {
            _db.Add(order);
        }

        public void Delete(Order order)
        {
            var orderTarget = _db.Where(p => p.OrderDate == order.OrderDate && p.Id==order.Id).FirstOrDefault();
            if (orderTarget != null) _db.Remove(orderTarget);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Order GetById(int id)
        {
            return _db.Find(id);
        }

        public bool isExists(Order order)
        {
            var checkOrder = _db.Where(p => p.OrderDate == order.OrderDate && p.Id == order.Id).FirstOrDefault();
            if (checkOrder != null)
            {
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public Order Find(Order order)
        {
            return _db.Where(p => p.Id == order.Id).FirstOrDefault();
        }
   
    }
}
