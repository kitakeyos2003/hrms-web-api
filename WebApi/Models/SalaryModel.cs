namespace WebApi.Models
{
    public class SalaryModel
    {
        public int SalaryID { get; set; }
        public EmployeeModel Employee { get; set; }
        public int WorkingDays { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Bonus { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
