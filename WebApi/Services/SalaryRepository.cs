using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class SalaryRepository : IRepository<SalaryModel, SalaryEntity>
    {
        private MyDbContext _context;
        public SalaryRepository(MyDbContext context)
        {
            _context = context;
        }

        public SalaryModel Add(SalaryEntity e)
        {
            _context.Salarys.Add(e);
            _context.SaveChanges();
            return new SalaryModel
            {
                SalaryID = e.SalaryID,
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
                Allowance = e.Allowance,
                BasicSalary = e.BasicSalary,
                Bonus = e.Bonus,
                Deductions = e.Deductions,
                GrossSalary = e.GrossSalary,
                NetSalary = e.NetSalary,
                PaymentDate = e.PaymentDate,
                PaymentMethod = e.PaymentMethod,
                PaySlip = e.PaySlip,
                Tax = e.Tax
            };
        }

        public void Delete(int id)
        {
            var e = _context.Salarys.SingleOrDefault(e => e.SalaryID == id);
            if (e != null)
            {
                _context.Salarys.Remove(e);
                _context.SaveChanges();
            }
        }

        public SalaryModel Get(int id)
        {
            var e = _context.Salarys.SingleOrDefault(e => e.SalaryID == id);
            if (e != null)
            {
                return new SalaryModel
                {
                    SalaryID = e.SalaryID,
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
                    Allowance = e.Allowance,
                    BasicSalary = e.BasicSalary,
                    Bonus = e.Bonus,
                    Deductions = e.Deductions,
                    GrossSalary = e.GrossSalary,
                    NetSalary = e.NetSalary,
                    PaymentDate = e.PaymentDate,
                    PaymentMethod = e.PaymentMethod,
                    PaySlip = e.PaySlip,
                    Tax = e.Tax
                };
            }
            return null;
        }

        public List<SalaryModel> GetAll()
        {
            return _context.Salarys.Select(e => new SalaryModel
            {
                SalaryID = e.SalaryID,
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
                Allowance = e.Allowance,
                BasicSalary = e.BasicSalary,
                Bonus = e.Bonus,
                Deductions = e.Deductions,
                GrossSalary = e.GrossSalary,
                NetSalary = e.NetSalary,
                PaymentDate = e.PaymentDate,
                PaymentMethod = e.PaymentMethod,
                PaySlip = e.PaySlip,
                Tax = e.Tax
            }).ToList();
        }

        public void Update(SalaryModel t)
        {
            var e = _context.Salarys.SingleOrDefault(e => e.SalaryID == t.SalaryID);
            if (e != null)
            {
                e.EmployeeID = t.Employee.EmployeeID;
                e.Allowance = t.Allowance;
                e.BasicSalary = t.BasicSalary;
                e.Bonus = t.Bonus;
                e.Deductions = t.Deductions;
                e.GrossSalary = t.GrossSalary;
                e.NetSalary = t.NetSalary;
                e.PaymentDate = t.PaymentDate;
                e.PaymentMethod = t.PaymentMethod;
                e.PaySlip = t.PaySlip;
                e.Tax = t.Tax;
                _context.SaveChanges();
            }
        }
    }
}
