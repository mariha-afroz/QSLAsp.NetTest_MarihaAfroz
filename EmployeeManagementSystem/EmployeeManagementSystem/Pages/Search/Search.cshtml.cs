using EMSDataAccess;
using EMSDomain.Employees;
using EMSDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementSystem.Pages.Search
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public EmployeeSearchCriteria SearchData { get; set; }
        public IList<EmployeeSearchDTO> EmployeeSearchList { get; set; }

        private readonly IEmployee m_Employee;
        public SearchModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }

        public void OnGet()
        {
            try
            {
                if (SearchData == null)
                {
                    SearchData = new EmployeeSearchCriteria();
                }
            }
            catch
            {
                throw;
            }
        }
        public IActionResult OnGetSearch()
        {
            try
            {
                
                EmployeeSearchList = m_Employee.SearchEmployee(SearchData);
                return Page();
            }
            catch
            {
                throw;
            }
        }
    }
}

