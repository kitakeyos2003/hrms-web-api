using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class AttendanceRepository : IRepository<AttendanceModel, AttendanceEntity> 
    {
        private MyDbContext _context;
        public AttendanceRepository(MyDbContext context)
        {
            _context = context;
        }

        public AttendanceModel Add(AttendanceEntity e)
        {
            _context.Attendances.Add(e);
            _context.SaveChanges();
            var ne = _context.Entry(e);
            ne.Reference(a => a.Employee).Load();
            var n = _context.Entry(e.Employee);
            n.Reference(a => a.Department).Load();
            n.Reference(a => a.Position).Load();
            return new AttendanceModel
            {
                AttendanceID = e.AttendanceID,
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
                ActualEndTime = e.ActualEndTime,
                ActualStartTime = e.ActualStartTime,
                AttendanceNote = e.AttendanceNote,
                AttendanceStatus = e.AttendanceStatus,
                Date = e.Date,
                Overtime = e.Overtime,
                ShiftEndTime = e.ShiftEndTime,
                ShiftStartTime = e.ShiftStartTime,
            };
        }

        public void Delete(int id)
        {
            var e = _context.Attendances.SingleOrDefault(e => e.AttendanceID == id);
            if (e != null)
            {
                _context.Attendances.Remove(e);
                _context.SaveChanges();
            }
        }

        public AttendanceModel Get(int id)
        {
            var e = _context.Attendances.SingleOrDefault(e => e.AttendanceID == id);
            if (e != null)
            {
                return new AttendanceModel
                {
                    AttendanceID = e.AttendanceID,
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
                    ActualEndTime = e.ActualEndTime,
                    ActualStartTime = e.ActualStartTime,
                    AttendanceNote = e.AttendanceNote,
                    AttendanceStatus = e.AttendanceStatus,
                    Date = e.Date,
                    Overtime = e.Overtime,
                    ShiftEndTime = e.ShiftEndTime,
                    ShiftStartTime = e.ShiftStartTime,
                };
            }
            return null;
        }

        public List<AttendanceModel> GetAll()
        {
            return _context.Attendances.Select(e => new AttendanceModel
            {
                AttendanceID = e.AttendanceID,
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
                ActualEndTime = e.ActualEndTime,
                ActualStartTime = e.ActualStartTime,
                AttendanceNote = e.AttendanceNote,
                AttendanceStatus = e.AttendanceStatus,
                Date = e.Date,
                Overtime = e.Overtime,
                ShiftEndTime = e.ShiftEndTime,
                ShiftStartTime = e.ShiftStartTime,
            }).OrderBy(e => e.AttendanceID).ToList();
        }

        public void Update(AttendanceModel t)
        {
            var e = _context.Attendances.SingleOrDefault(e => e.AttendanceID == t.AttendanceID);
            if (e != null)
            {
                e.EmployeeID = t.Employee.EmployeeID;
                e.ActualStartTime = t.ActualStartTime;
                e.ActualEndTime = t.ActualEndTime;
                e.AttendanceNote = t.AttendanceNote;
                e.AttendanceStatus = t.AttendanceStatus;
                e.Date = t.Date;
                e.Overtime = t.Overtime;
                e.ShiftEndTime = t.ShiftEndTime;
                e.ShiftStartTime = t.ShiftStartTime;
                _context.SaveChanges();
            }
        }
    }
}
