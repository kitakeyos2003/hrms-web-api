namespace WebApi.Models
{
    public class AllowanceModel
    {
        public int AllowanceID { get; set; }
        public int Amount { get; set; }
        public virtual DepartmentModel Department { get; set; }
        public virtual PositionModel Position { get; set; }
    }
}
