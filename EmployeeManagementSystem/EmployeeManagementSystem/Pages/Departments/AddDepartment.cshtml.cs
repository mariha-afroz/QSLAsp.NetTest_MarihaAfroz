using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Pages.Departments
{
    public class AddDepartmentModel : TransactionBase
    {
        [BindProperty]
        public Department DepartmentData { get; set; }

        private readonly IEmployee m_Employee;

        public AddDepartmentModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }
        public void OnGet()
        {
            try
            {
                DepartmentData = new Department();

                SetCCInfo($"{Navigator.DepartmentList}");

            }
            catch
            {
                throw;
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                if (string.IsNullOrEmpty(DepartmentData.DepartmentName))
                {
                    TempData["Message"] = "Department Name is required";
                    return Page();
                }
                m_Employee.CreateDepartment(DepartmentData);

                TempData["Message"] = "Department has been created successfully";

                return RedirectToPage(Navigator.DepartmentList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
