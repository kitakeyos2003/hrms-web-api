

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("allowance")]
    public class AllowanceEntity
    {
        [Key]
        public int AllowanceID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public int PositionID { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public virtual DepartmentEntity Department { get; set; }

        [ForeignKey(nameof(PositionID))]
        public virtual PositionEntity Position { get; set; }
    }
}
