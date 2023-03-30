using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("contract")]
    public class ContractEntity
    {
        [Key]
        public int ContractID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double WorkingTime { get; set; }
        [Required]
        public double BasicSalary { get; set; }
        [Required]
        public int ContractType { get; set; }
        public string Note { get; set; }


        [ForeignKey(nameof(EmployeeID))]
        public virtual EmployeeEntity Employee { get; set; }
    }
}
