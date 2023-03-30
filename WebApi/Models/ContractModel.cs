namespace WebApi.Models
{
    public class ContractModel
    {
        public int ContractID { get; set; }
        public EmployeeModel Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double WorkingTime { get; set; }
        public double BasicSalary { get; set; }
        public int ContractType { get; set; }
        public string Note { get; set; }
    }
}
