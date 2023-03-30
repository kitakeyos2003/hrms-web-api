using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("evaluate")]
    public class EvaluateEntity
    {
        [Key]
        public int EvaluateID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EvaluationPeriod { get; set; }
        [Required]
        public string EvaluationCriteria { get; set; }
        [Required]
        public double EvaluationScore { get; set; }
        [Required]
        public string ManagerComment { get; set; }
        [Required]
        public string EmployeeComment { get; set; }
        [Required]
        public int EvaluationResult { get; set; }
        [Required]
        public string ImprovementPlan { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public virtual EmployeeEntity Employee { get; set; }
    }
}
