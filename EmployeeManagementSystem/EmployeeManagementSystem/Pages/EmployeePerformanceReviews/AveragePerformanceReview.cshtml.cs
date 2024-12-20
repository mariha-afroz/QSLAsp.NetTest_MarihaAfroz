using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementSystem.Pages.EmployeePerformanceReviews
{
    public class AveragePerformanceReviewModel : PageModel
    {
        public IList<AveragePerformanceScoreDTO> AveragePerformanceScoreList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedDepartmentId { get; set; }

        private readonly IEmployee m_Employee;
        public AveragePerformanceReviewModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }

        public void OnGet()
        {
            if (SelectedDepartmentId > 0)
            {
                AveragePerformanceScoreList = m_Employee.GetAveragePerfromanceScoreByDepartmentId(SelectedDepartmentId);
            }
        }
    }
}
