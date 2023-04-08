using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("attendance")]
    public class AttendanceEntity
    {
        [Key]
        public int AttendanceID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ShiftStartTime { get; set; }
        [Required]
        public DateTime ShiftEndTime { get; set; }
        [Required]
        public DateTime ActualStartTime { get; set; }
        [Required]
        public DateTime ActualEndTime { get; set; }
        [Required]
        public int Overtime { get; set; }
        [Required]
        public int AttendanceStatus { get; set; }
        public string AttendanceNote { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public virtual EmployeeEntity Employee { get; set; }
    }
}
