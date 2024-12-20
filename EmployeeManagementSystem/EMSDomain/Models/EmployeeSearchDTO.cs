namespace EMSDomain.Models
{
    public class EmployeeSearchDTO
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Position { get; set; }
        public int? MinScore { get; set; } 
        public int? MaxScore { get; set; }

    }
}
