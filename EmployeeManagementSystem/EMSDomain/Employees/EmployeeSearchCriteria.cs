namespace EMSDomain.Employees
{
    public class EmployeeSearchCriteria
    {
        public string? EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public int? MinScore { get; set; }
        public int? MaxScore { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}
