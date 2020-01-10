using AutoMapper;
using SalesApp.BL.Models;
using SalesApp.DAL.Model;
using SalesApp.Infrastructure.Interfaces;
using SalesApp.Infrastructure.Repository;
using System.Collections.Generic;

namespace SalesApp.BL.Services
{
    public class ReportService: IService<ReportBL>
    {
        private IRepository<Report> _repo;
        private readonly IMapper _mapper;

        public ReportService(IRepository<Report> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void SaveChange()
        {
            _repo.SaveChanges();
        }


        public IEnumerable<ReportBL> GetAll()
        {
            return _mapper.Map<IEnumerable<Report>, IEnumerable<ReportBL>>(_repo.All);
        }

        public void Remove(ReportBL reportBl)
        {
            Report report = _mapper.Map<Report>(reportBl);
            _repo.Delete(report);
        }

        public void Update(ReportBL reportBl)
        {
            _repo.Update(_mapper.Map<Report>(reportBl));
        }

        public void Create(ReportBL reportBl)
        {
            _repo.Create(_mapper.Map<Report>(reportBl));
        }

        public ReportBL GetById(int id)
        {
            return _mapper.Map<ReportBL>(_repo.GetById(id));
        }

        public bool Check(ReportBL reportBl)
        {
            Report report = _repo.Find(_mapper.Map<Report>(reportBl));
            return report != null;
        }

        public ReportBL Find(ReportBL reportBL)
        {
            Report report = _repo.Find(_mapper.Map<Report>(reportBL));
            return _mapper.Map<ReportBL>(report);
        }
    }
}
