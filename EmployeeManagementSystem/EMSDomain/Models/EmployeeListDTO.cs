using System.ComponentModel.DataAnnotations;

namespace EMSDomain
{
    public class EmployeeListDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string? Phone { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? JoiningDate { get; set; }

    }
}
