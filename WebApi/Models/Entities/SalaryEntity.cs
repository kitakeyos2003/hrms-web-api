using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("salary")]
    public class SalaryEntity
    {
        [Key]
        public int SalaryID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int WorkingDays { get; set; }
        [Required]
        public decimal BasicSalary { get; set; }
        [Required]
        public decimal Allowance { get; set; }
        [Required]
        public decimal Bonus { get; set; }
        [Required]
        public decimal GrossSalary { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Deductions { get; set; }
        [Required]
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [ForeignKey(nameof(EmployeeID))]
        public virtual EmployeeEntity Employee { get; set; }
    }
}
