using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Pages.Departments
{
    public class EditDepartmentModel : TransactionBase
    {
        [BindProperty]
        public Department DepartmentData { get; set; }

        private readonly IEmployee m_Employee;

        public EditDepartmentModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }
        public void OnGet(int id)
        {
            DepartmentData = m_Employee.GetDepartmentById(id);
            SetCCInfo(Navigator.DepartmentList);
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

                m_Employee.UpdateDepartment(DepartmentData);

                TempData["Message"] = "Department has been updated succesfully";
                return RedirectToPage(Navigator.DepartmentList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

