namespace WebApi.Models
{
    public class CandidateModel
    {
        public int CandidateID { get; set; }
        public string FullName { get; set; }
        public PositionModel PositionApplied { get; set; }
        public DepartmentModel DepartmentApplied { get; set; }
        public string Resume { get; set; }
        public string ContactInformation { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public string Skills { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Interviewer { get; set; }
        public int InterviewResult { get; set; }
    }
}
