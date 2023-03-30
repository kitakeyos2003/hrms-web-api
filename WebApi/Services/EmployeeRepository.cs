using DevExpress.XtraSpellChecker.Parser;
using System.Net;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmployeeRepository : IRepository<EmployeeModel, EmployeeEntity>
    {
        private MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            _context = context;
        }
        public EmployeeModel Add(EmployeeEntity e)
        {
             _context.Employees.Add(e);
            _context.SaveChanges();
            var ne = _context.Entry(e);
            ne.Reference(a => a.Department).Load();
            ne.Reference(a => a.Position).Load();
            var employeeModel = new EmployeeModel
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                Department = new DepartmentModel { Id = e.Department.DepartmentID, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.PositionID, Name = e.Position.Name },
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status
            };
            return employeeModel;
        }

        public void Delete(int id)
        {
            var e = _context.Employees.SingleOrDefault(e => e.EmployeeID == id);
            if (e != null)
            {
                _context.Employees.Remove(e);
                _context.SaveChanges();
            }
        }

        public EmployeeModel Get(int id)
        {
            var e = _context.Employees.SingleOrDefault(e => e.EmployeeID == id);
            if (e != null)
            {
                return new EmployeeModel
                {
                    EmployeeID = e.EmployeeID,
                    FullName = e.FullName,
                    Gender = e.Gender,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    Address = e.Address,
                    DateOfBirth = e.DateOfBirth,
                    Department = new DepartmentModel { Id = e.Department.DepartmentID, Name = e.Department.Name },
                    Position = new PositionModel { Id = e.Position.PositionID, Name = e.Position.Name },
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Status = e.Status,
                };
            }
            return null;
        }

        public List<EmployeeModel> GetAll()
        {
            return _context.Employees.Select(e => new EmployeeModel
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                Department = new DepartmentModel { Id = e.Department.DepartmentID, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.PositionID, Name = e.Position.Name },
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status,
            }).ToList();
        }

        public void Update(EmployeeModel employeeVM)
        {
            var e = _context.Employees.SingleOrDefault(e => e.EmployeeID == employeeVM.EmployeeID);
            if (e != null)
            {
                e.EmployeeID = employeeVM.EmployeeID;
                e.FullName = employeeVM.FullName;
                e.Gender = employeeVM.Gender;
                e.PhoneNumber = employeeVM.PhoneNumber;
                e.Email = employeeVM.Email;
                e.Address = employeeVM.Address;
                e.DateOfBirth = employeeVM.DateOfBirth;
                e.Department = new DepartmentEntity { DepartmentID = employeeVM.Department.Id, Name = employeeVM.Department.Name };
                e.Position = new PositionEntity { PositionID = employeeVM.Position.Id, Name = employeeVM.Position.Name };
                e.StartDate = employeeVM.StartDate;
                e.EndDate = employeeVM.EndDate;
                e.Status = employeeVM.Status;
                _context.SaveChanges();
            }
        }

        public List<EmployeeModel> GetAll(string search)
        {
            var allEmployee = _context.Employees.Where(e => e.FullName.Contains(search)).ToList();
            var result = allEmployee.Select(e => new EmployeeModel
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                Department = new DepartmentModel { Id = e.Department.DepartmentID, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.PositionID, Name = e.Position.Name },
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status,
            }).ToList();
            return result;
        }
    }
}
