namespace EMSDomain
{
    public class PerformanceReviewListDTO
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? ReviewScore { get; set; }
        public string? ReviewNotes { get; set; }
    }

    public class AveragePerformanceScoreDTO
    {
        public string? DepartmentName { get; set; }
        public double AveragePerformanceScore { get; set; }
    }
}
