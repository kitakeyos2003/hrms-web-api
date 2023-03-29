using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("department")]
    public class DepartmentEntity
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
