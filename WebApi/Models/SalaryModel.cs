namespace WebApi.Models
{
    public class SalaryModel
    {
        public int SalaryID { get; set; }
        public EmployeeModel Employee;
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Bonus { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaySlip { get; set; }
    }
}
