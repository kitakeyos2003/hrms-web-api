using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class EvaluationRepository : IRepository<EvaluateModel, EvaluateEntity>
    {
        private MyDbContext _context;
        public EvaluationRepository(MyDbContext context)
        {
            _context = context;
        }

        public EvaluateModel Add(EvaluateEntity e)
        {
            _context.Evaluations.Add(e);
            _context.SaveChanges(); 
            var ne = _context.Entry(e);
            ne.Reference(a => a.Employee).Load();
            var n = _context.Entry(e.Employee);
            n.Reference(a => a.Department).Load();
            n.Reference(a => a.Position).Load();
            return new EvaluateModel
            {
                EvaluateID = e.EvaluateID,
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
                EmployeeComment = e.EmployeeComment,
                EvaluationCriteria = e.EvaluationCriteria,
                EvaluationPeriod = e.EvaluationPeriod,
                EvaluationResult = e.EvaluationResult,
                EvaluationScore = e.EvaluationScore,
                ImprovementPlan = e.ImprovementPlan,
                ManagerComment = e.ManagerComment
            };
        }

        public void Delete(int id)
        {
            var e = _context.Evaluations.SingleOrDefault(e => e.EvaluateID == id);
            if (e != null)
            {
                _context.Evaluations.Remove(e);
                _context.SaveChanges();
            }
        }

        public EvaluateModel Get(int id)
        {
            var e = _context.Evaluations.SingleOrDefault(e => e.EvaluateID == id);
            if (e != null)
            {
                return new EvaluateModel
                {
                    EvaluateID = e.EvaluateID,
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
                    EmployeeComment = e.EmployeeComment,
                    EvaluationCriteria = e.EvaluationCriteria,
                    EvaluationPeriod = e.EvaluationPeriod,
                    EvaluationResult = e.EvaluationResult,
                    EvaluationScore = e.EvaluationScore,
                    ImprovementPlan = e.ImprovementPlan,
                    ManagerComment = e.ManagerComment
                };
            }
            return null;
        }

        public List<EvaluateModel> GetAll()
        {
            return _context.Evaluations.Select(e => new EvaluateModel
            {
                EvaluateID = e.EvaluateID,
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
                EmployeeComment = e.EmployeeComment,
                EvaluationCriteria = e.EvaluationCriteria,
                EvaluationPeriod = e.EvaluationPeriod,
                EvaluationResult = e.EvaluationResult,
                EvaluationScore = e.EvaluationScore,
                ImprovementPlan = e.ImprovementPlan,
                ManagerComment = e.ManagerComment
            }).OrderBy(e => e.EvaluateID).ToList();
        }

        public void Update(EvaluateModel t)
        {
            var e = _context.Evaluations.SingleOrDefault(e => e.EvaluateID == t.EvaluateID);
            if (e != null)
            {
                e.EmployeeID = t.Employee.EmployeeID;
                e.EvaluationPeriod = t.EvaluationPeriod;
                e.EvaluationResult = t.EvaluationResult;
                e.EvaluationScore = t.EvaluationScore;
                e.ImprovementPlan = t.ImprovementPlan;
                e.EmployeeComment = t.EmployeeComment;
                e.ManagerComment = t.ManagerComment;
                e.EvaluationCriteria = t.EvaluationCriteria;
                _context.SaveChanges();
            }
        }
    }
}
