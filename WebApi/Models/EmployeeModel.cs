namespace WebApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public PositionModel Position { get; set; }
        public DepartmentModel Department { get; set; }
    }
}
