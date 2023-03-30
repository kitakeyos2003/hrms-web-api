namespace WebApi.Models
{
    public class EvaluateModel
    {
        public int EvaluateID { get; set; }
        public EmployeeModel Employee { get; set; }
        public string EvaluationPeriod { get; set; }
        public string EvaluationCriteria { get; set; }
        public double EvaluationScore { get; set; }
        public string ManagerComment { get; set; }
        public string EmployeeComment { get; set; }
        public int EvaluationResult { get; set; }
        public string ImprovementPlan { get; set; }
    }
}
