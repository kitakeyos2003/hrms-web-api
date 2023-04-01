using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("candidate")]
    public class CandidateEntity
    {
        [Key]
        public int CandidateID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int PositionApplied { get; set; }
        [Required]
        public int DepartmentApplied { get; set; }
        [Required]
        public string ContactInformation { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string WorkExperience { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public DateTime InterviewDate { get; set; }
        [Required]
        public string Interviewer { get; set; }
        [Required]
        public int InterviewResult { get; set; }


        [ForeignKey(nameof(PositionApplied))]
        public virtual PositionEntity Position { get; set; }
        [ForeignKey(nameof(DepartmentApplied))]
        public virtual DepartmentEntity Department { get; set; }
    }
}
