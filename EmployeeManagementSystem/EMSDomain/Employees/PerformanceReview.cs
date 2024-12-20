using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMSDomain
{
    public class PerformanceReview : BaseEntity
    {
        [Display(Name = "Review Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Review Date is required")]
        public DateTime? ReviewDate { get; set; }

        [Display(Name = "Review Score")]
        [Range(1, 10, ErrorMessage = "Review Score must be between 1 and 10")]
        [Required(ErrorMessage = "Review Score is required")]
        public int? ReviewScore { get; set; }

        [Display(Name = "Review Notes")]
        [StringLength(500, ErrorMessage = "Review Notes cannot exceed 500 characters")]
        public string? ReviewNotes { get; set; }

        [Display(Name = "Employee")]
        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum Quarter
    {
 
        [Display(Name = "Quarter-1"), Description("Quarter-1")]
        Q1 = 1,

        [Display(Name = "Quarter-2"), Description("Quarter-2")]
        Q2 = 2,

        [Display(Name = "Quarter-3"), Description("Quarter-3")]
        Q3 = 3,

        [Display(Name = "Quarter-4"), Description("Quarter-4")]
        Q4 = 4
    }
}
