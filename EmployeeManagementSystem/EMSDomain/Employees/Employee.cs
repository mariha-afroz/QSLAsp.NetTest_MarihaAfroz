using System.ComponentModel.DataAnnotations;

namespace EMSDomain
{
    public class Employee : BaseEntity
    {

        [Display(Name = "Employee Name")]
        [StringLength(100, ErrorMessage = "Employee Name exceeded the max {1} characters")]
        public string? EmployeeName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email exceeded the max {1} characters")]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The number is not a valid phone number")]
        [StringLength(17)]
        public string? Phone { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Display(Name = "Position")]
        [StringLength(100, ErrorMessage = "Position exceeded the max {1} characters")]
        public string? Position { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public DateTime? JoiningDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
