using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class CandidateRepository : IRepository<CandidateModel, CandidateEntity>
    {
        private MyDbContext _context;
        public CandidateRepository(MyDbContext context)
        {
            _context = context;
        }

        public CandidateModel Add(CandidateEntity e)
        {
            _context.Candidates.Add(e);
            _context.SaveChanges();
            var ne = _context.Entry(e);
            ne.Reference(a => a.Department).Load();
            ne.Reference(a => a.Position).Load();
            return new CandidateModel
            {
                CandidateID = e.CandidateID,
                FullName = e.FullName,
                ContactInformation = e.ContactInformation,
                DepartmentApplied = new DepartmentModel
                {
                    Id = e.Department.DepartmentID,
                    Name = e.Department.Name
                },
                PositionApplied = new PositionModel
                {
                    Id = e.Position.PositionID,
                    Name = e.Position.Name
                },
                Education = e.Education,
                InterviewDate = e.InterviewDate,
                Interviewer = e.Interviewer,
                InterviewResult = e.InterviewResult,
                Skills = e.Skills,
                WorkExperience = e.WorkExperience
            };
        }

        public void Delete(int id)
        {
            var e = _context.Candidates.SingleOrDefault(e => e.CandidateID == id);
            if (e != null)
            {
                _context.Candidates.Remove(e);
                _context.SaveChanges();
            }
        }

        public CandidateModel Get(int id)
        {
            var e = _context.Candidates.SingleOrDefault(e => e.CandidateID == id);
            if (e != null)
            {
                return new CandidateModel
                {
                    CandidateID = e.CandidateID,
                    FullName = e.FullName,
                    ContactInformation = e.ContactInformation,
                    DepartmentApplied = new DepartmentModel
                    {
                        Id = e.Department.DepartmentID,
                        Name = e.Department.Name
                    },
                    PositionApplied = new PositionModel
                    {
                        Id = e.Position.PositionID,
                        Name = e.Position.Name
                    },
                    Education = e.Education,
                    InterviewDate = e.InterviewDate,
                    Interviewer = e.Interviewer,
                    InterviewResult = e.InterviewResult,
                    Skills = e.Skills,
                    WorkExperience = e.WorkExperience
                };
            }
            return null;
        }

        public List<CandidateModel> GetAll()
        {
            return _context.Candidates.Select(e => new CandidateModel
            {
                CandidateID = e.CandidateID,
                FullName = e.FullName,
                ContactInformation = e.ContactInformation,
                DepartmentApplied = new DepartmentModel
                {
                    Id = e.Department.DepartmentID,
                    Name = e.Department.Name
                },
                PositionApplied = new PositionModel
                {
                    Id = e.Position.PositionID,
                    Name = e.Position.Name
                },
                Education = e.Education,
                InterviewDate = e.InterviewDate,
                Interviewer = e.Interviewer,
                InterviewResult = e.InterviewResult,
                Skills = e.Skills,
                WorkExperience = e.WorkExperience
            }).OrderBy(e => e.CandidateID).ToList();
        }

        public void Update(CandidateModel t)
        {
            var e = _context.Candidates.SingleOrDefault(e => e.CandidateID == t.CandidateID);
            if (e != null)
            {
                e.FullName = t.FullName;
                e.Skills = t.Skills;
                e.WorkExperience = t.WorkExperience;
                e.InterviewDate = t.InterviewDate;
                e.Interviewer = t.Interviewer;
                e.InterviewResult = t.InterviewResult;
                e.PositionApplied = t.PositionApplied.Id;
                e.DepartmentApplied = t.DepartmentApplied.Id;
                e.Education = t.Education;
                e.ContactInformation = t.ContactInformation;
                _context.SaveChanges();
            }
        }
    }
}
