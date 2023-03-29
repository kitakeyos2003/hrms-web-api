using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("position")]
    public class PositionEntity
    {
        [Key]
        public int PositionID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
