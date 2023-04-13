using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class ContractRepository : IRepository<ContractModel, ContractEntity>
    {
        private MyDbContext _context;
        public ContractRepository(MyDbContext context)
        {
            _context = context;
        }

        public ContractModel Add(ContractEntity e)
        {
            _context.Contracts.Add(e);
            _context.SaveChanges();
            var ne = _context.Entry(e);
            ne.Reference(a => a.Employee).Load();
            var n = _context.Entry(e.Employee);
            n.Reference(a => a.Department).Load();
            n.Reference(a => a.Position).Load();
            return new ContractModel
            {
                ContractID = e.ContractID,
                Employee = new EmployeeModel
                {
                    EmployeeID = e.Employee.EmployeeID,
                    FullName = e.Employee.FullName,
                    Gender = e.Employee.Gender,
                    PhoneNumber = e.Employee.PhoneNumber,
                    Email = e.Employee.Email,
                    Address = e.Employee.Address,
                    DateOfBirth = e.Employee.DateOfBirth,
                    Department = new DepartmentModel { Id = e.Employee.Department.DepartmentID, Name = e.Employee.Department.Name },
                    Position = new PositionModel { Id = e.Employee.Position.PositionID, Name = e.Employee.Position.Name },
                    StartDate = e.Employee.StartDate,
                    EndDate = e.Employee.EndDate,
                    Status = e.Employee.Status
                },
                BasicSalary = e.BasicSalary,
                ContractType = e.ContractType,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                WorkingTime = e.WorkingTime,
                Note = e.Note,
            };
        }

        public void Delete(int id)
        {
            var e = _context.Contracts.SingleOrDefault(e => e.ContractID == id);
            if (e != null)
            {
                _context.Contracts.Remove(e);
                _context.SaveChanges();
            }
        }

        public ContractModel Get(int id)
        {
            var e = _context.Contracts.SingleOrDefault(e => e.ContractID == id);
            if (e != null)
            {
                return new ContractModel
                {
                    ContractID = e.ContractID,
                    Employee = new EmployeeModel
                    {
                        EmployeeID = e.Employee.EmployeeID,
                        FullName = e.Employee.FullName,
                        Gender = e.Employee.Gender,
                        PhoneNumber = e.Employee.PhoneNumber,
                        Email = e.Employee.Email,
                        Address = e.Employee.Address,
                        DateOfBirth = e.Employee.DateOfBirth,
                        Department = new DepartmentModel { Id = e.Employee.Department.DepartmentID, Name = e.Employee.Department.Name },
                        Position = new PositionModel { Id = e.Employee.Position.PositionID, Name = e.Employee.Position.Name },
                        StartDate = e.Employee.StartDate,
                        EndDate = e.Employee.EndDate,
                        Status = e.Employee.Status
                    },
                    BasicSalary = e.BasicSalary,
                    ContractType = e.ContractType,
                    EndDate = e.EndDate,
                    StartDate = e.StartDate,
                    WorkingTime = e.WorkingTime,
                    Note = e.Note,
                };
            }
            return null;
        }

        public List<ContractModel> GetAll()
        {
            return _context.Contracts.Select(e => new ContractModel
            {
                ContractID = e.ContractID,
                Employee = new EmployeeModel
                {
                    EmployeeID = e.Employee.EmployeeID,
                    FullName = e.Employee.FullName,
                    Gender = e.Employee.Gender,
                    PhoneNumber = e.Employee.PhoneNumber,
                    Email = e.Employee.Email,
                    Address = e.Employee.Address,
                    DateOfBirth = e.Employee.DateOfBirth,
                    Department = new DepartmentModel { Id = e.Employee.Department.DepartmentID, Name = e.Employee.Department.Name },
                    Position = new PositionModel { Id = e.Employee.Position.PositionID, Name = e.Employee.Position.Name },
                    StartDate = e.Employee.StartDate,
                    EndDate = e.Employee.EndDate,
                    Status = e.Employee.Status
                },
                BasicSalary = e.BasicSalary,
                ContractType = e.ContractType,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                WorkingTime = e.WorkingTime,
                Note = e.Note,
            }).OrderBy(e => e.ContractID).ToList();
        }

        public void Update(ContractModel t)
        {
            var e = _context.Contracts.SingleOrDefault(e => e.ContractID == t.ContractID);
            if (e != null)
            {
                e.EmployeeID = t.Employee.EmployeeID;
                e.BasicSalary = t.BasicSalary;
                e.ContractType = t.ContractType;
                e.EndDate = t.EndDate;
                e.StartDate = t.StartDate;
                e.WorkingTime = t.WorkingTime;
                e.Note = t.Note;
                _context.SaveChanges();
            }
        }
    }
}
