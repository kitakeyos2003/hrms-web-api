using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("employee")]
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public PositionEntity Position { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public DepartmentEntity Department { get; set; }

    }
}
