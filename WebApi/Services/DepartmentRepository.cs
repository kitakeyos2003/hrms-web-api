using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class DepartmentRepository : IRepository<DepartmentModel, DepartmentEntity>
    {
        private MyDbContext _context;
        public DepartmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public DepartmentModel Add(DepartmentEntity e)
        {
            _context.Departments.Add(e);
            _context.SaveChanges();
            return new DepartmentModel
            {
                Id = e.DepartmentID,
                Name = e.Name,
            };
        }

        public void Delete(int id)
        {
            var e = _context.Departments.SingleOrDefault(e => e.DepartmentID == id);
            if (e != null)
            {
                _context.Departments.Remove(e);
                _context.SaveChanges();
            }
        }

        public DepartmentModel Get(int id)
        {
            var e = _context.Departments.SingleOrDefault(e => e.DepartmentID == id);
            if (e != null)
            {
                return new DepartmentModel
                {
                   Id = e.DepartmentID,
                   Name = e.Name,
                };
            }
            return null;
        }

        public List<DepartmentModel> GetAll()
        {
            return _context.Departments.Select(e => new DepartmentModel
            {
                Id = e.DepartmentID,
                Name = e.Name,
            }).ToList();
        }

        public void Update(DepartmentModel t)
        {
            var e = _context.Departments.SingleOrDefault(e => e.DepartmentID == t.Id);
            if (e != null)
            {
                e.Name = t.Name;
                _context.SaveChanges();
            }
        }
    }
}
