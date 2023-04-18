using WebApi.Data;
using WebApi.Models;
using WebApi.Models.Helper;

namespace WebApi.Services
{
    public class SalaryRepository : IRepository<SalaryModel, SalaryEntity>
    {
        private MyDbContext _context;
        public SalaryRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<SalaryModel> Generate(List<EmployeeModel> models, DateTime startDate, DateTime endDate)
        {
            List<SalaryModel> result = new List<SalaryModel>(); 
            TimeSpan timeSpan = endDate - startDate;
            int days = timeSpan.Days;
            int sundays = DateTimeHelper.CountSundays(startDate, endDate);
            foreach (EmployeeModel model in models)
            {
                IQueryable<EmployeeEntity> employees = _context.Employees.Where(e => e.EmployeeID == model.EmployeeID);
                EmployeeEntity employee = employees.FirstOrDefault();
                if (employee != null)
                {
                    IQueryable<AllowanceEntity> qA = _context.Allowances.Where(e => e.PositionID == employee.PositionId && e.DepartmentID == employee.DepartmentId);
                    AllowanceEntity allowance = qA.FirstOrDefault();
                    if (allowance != null)
                    {
                        IQueryable<ContractEntity> qC = _context.Contracts.Where(c => c.EmployeeID == model.EmployeeID);
                        ContractEntity contract = qC.FirstOrDefault();
                        if (contract != null)
                        {
                            IQueryable<AttendanceEntity> attendances = _context.Attendances.Where(a => a.EmployeeID == model.EmployeeID && a.Date >= startDate && a.Date <= endDate);
                            decimal deductions = 0;
                            int workingDays = attendances.Count();
                            decimal basicSalary = contract.BasicSalary;
                            decimal pSalary = Math.Round((workingDays * (basicSalary / (30 - sundays))) / 1000) * 1000;
                            decimal pAllowance = allowance.Amount;
                            decimal bonus = 0;
                            decimal tax = 10;
                            decimal grossSalary = pSalary + pAllowance + bonus - deductions;
                            decimal netSalary = grossSalary - (grossSalary * tax / 100);
                            SalaryModel salary = Add(new SalaryEntity
                            {
                                EmployeeID = model.EmployeeID,
                                Allowance = pAllowance,
                                WorkingDays = workingDays,
                                Deductions = deductions,
                                BasicSalary = basicSalary,
                                Bonus = bonus,
                                Tax = tax,
                                GrossSalary = grossSalary,
                                NetSalary = netSalary
                            });
                            result.Add(salary);
                        }
                    }
                }
            }
            return result;
        }

        public SalaryModel Add(SalaryEntity e)
        {
            _context.Salarys.Add(e);
            _context.SaveChanges();
            var ne = _context.Entry(e);
            ne.Reference(a => a.Employee).Load();
            var n = _context.Entry(e.Employee);
            n.Reference(a => a.Department).Load();
            n.Reference(a => a.Position).Load();
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
                WorkingDays = e.WorkingDays,
                Allowance = e.Allowance,
                BasicSalary = e.BasicSalary,
                Bonus = e.Bonus,
                Deductions = e.Deductions,
                GrossSalary = e.GrossSalary,
                NetSalary = e.NetSalary,
                PaymentDate = e.PaymentDate,
                PaymentMethod = e.PaymentMethod,
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
                WorkingDays = e.WorkingDays,
                Allowance = e.Allowance,
                BasicSalary = e.BasicSalary,
                Bonus = e.Bonus,
                Deductions = e.Deductions,
                GrossSalary = e.GrossSalary,
                NetSalary = e.NetSalary,
                PaymentDate = e.PaymentDate,
                PaymentMethod = e.PaymentMethod,
                Tax = e.Tax
            }).OrderBy(e => e.SalaryID).ToList();
        }

        public void Update(SalaryModel t)
        {
            var e = _context.Salarys.SingleOrDefault(e => e.SalaryID == t.SalaryID);
            if (e != null)
            {
                e.EmployeeID = t.Employee.EmployeeID;
                e.WorkingDays = t.WorkingDays;
                e.Allowance = t.Allowance;
                e.BasicSalary = t.BasicSalary;
                e.Bonus = t.Bonus;
                e.Deductions = t.Deductions;
                e.GrossSalary = t.GrossSalary;
                e.NetSalary = t.NetSalary;
                e.PaymentDate = t.PaymentDate;
                e.PaymentMethod = t.PaymentMethod;
                e.Tax = t.Tax;
                _context.SaveChanges();
            }
        }
    }
}
