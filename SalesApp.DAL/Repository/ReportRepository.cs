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
  public class ReportRepository : IRepository<Report>
    {
        private SalesContext _context;
        private DbSet<Report> _db;

        public IQueryable<Report> All => _db;

        public ReportRepository(SalesContext context)
        {
            _context = context;
            _db = _context?.Report;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(Report report)
        {
            var reportTarget = _db.Where(r=>r.ReportDate==report.ReportDate || (r.Id==report.Id)).FirstOrDefault();
            if (reportTarget != null) _db.Remove(reportTarget);

        }

        public void Create(Report report)
        {
            _db.Add(report);
        }

        public Report GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;
        }
        public bool isExists(Report report)
        {
            var checkReport = _db.Where(r => r.ReportDate == report.ReportDate && (r.Id ==report.Id)).FirstOrDefault();
            if (checkReport != null)
            {
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Report Find(Report report)
        {
            return _db.Where(p => p.ReportDate == report.ReportDate).FirstOrDefault();
        }
    }
}
