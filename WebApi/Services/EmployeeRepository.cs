using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            _context = context;
        }
        public EmployeeModel Add(EmployeeEntity e)
        {
            
            var m = _context.Employees.Add(e);
            var employeeModel = new EmployeeModel
            {
                Id = e.Id,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                BirthDay = e.BirthDay,
                Department = new DepartmentModel { Id = e.Department.Id, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.Id, Name = e.Position.Name },
            };
            _context.SaveChanges();
            return employeeModel;
        }

        public void Delete(int id)
        {
            var e = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (e != null)
            {
                _context.Employees.Remove(e);
            }
        }

        public EmployeeModel Get(int id)
        {
            var e = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (e != null)
            {
                return new EmployeeModel
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Gender = e.Gender,
                    PhoneNumber = e.PhoneNumber,
                    Address = e.Address,
                    BirthDay = e.BirthDay,
                    Department = new DepartmentModel { Id = e.Department.Id, Name = e.Department.Name },
                    Position = new PositionModel { Id = e.Position.Id, Name = e.Position.Name },
                };
            }
            return null;
        }

        public List<EmployeeModel> GetAll()
        {
            return _context.Employees.Select(e => new EmployeeModel
            {
                Id = e.Id,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                BirthDay = e.BirthDay,
                Department = new DepartmentModel { Id = e.Department.Id, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.Id, Name = e.Position.Name }
            }).ToList(); 
        }

        public void Update(EmployeeModel employeeVM)
        {
            var e = _context.Employees.SingleOrDefault(e => e.Id == employeeVM.Id);
            if (e != null)
            {
                e.Id = employeeVM.Id;
                e.FullName = employeeVM.FullName;
                e.Gender = employeeVM.Gender;
                e.PhoneNumber = employeeVM.PhoneNumber;
                e.Address = employeeVM.Address;
                e.BirthDay = employeeVM.BirthDay;
                e.DepartmentId = employeeVM.Department.Id;
                e.PositionId = employeeVM.Position.Id;
            }
        }

        public List<EmployeeModel> GetAll(string search)
        {
            var allEmployee = _context.Employees.Where(e => e.FullName.Contains(search)).ToList();
            var result = allEmployee.Select(e => new EmployeeModel
            {
                Id = e.Id,
                FullName = e.FullName,
                Gender = e.Gender,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                BirthDay = e.BirthDay,
                Department = new DepartmentModel { Id = e.Department.Id, Name = e.Department.Name },
                Position = new PositionModel { Id = e.Position.Id, Name = e.Position.Name },
            }).ToList();
            return result;
        }
    }
}
