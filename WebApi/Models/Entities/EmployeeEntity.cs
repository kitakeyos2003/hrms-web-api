using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("employee")]
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Status { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentEntity Department { get; set; }
        [ForeignKey(nameof(PositionId))]
        public virtual PositionEntity Position { get; set; }
    }
}
