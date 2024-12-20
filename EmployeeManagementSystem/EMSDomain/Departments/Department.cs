using System.ComponentModel.DataAnnotations;

namespace EMSDomain
{
    public class Department : BaseEntity
    {
        [Display(Name = "Department Name")]
        [StringLength(100, ErrorMessage = "Department Name exceeded the max {1} characters")]
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; } //EmployeeId from Employee table

        [Display(Name = "Budget")]
        public decimal? Budget { get; set; }
    }
}
