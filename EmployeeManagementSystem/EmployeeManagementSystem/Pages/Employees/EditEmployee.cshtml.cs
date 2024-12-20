using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class EditEmployeeModel : TransactionBase
    {
        [BindProperty]
        public Employee EmployeeData { get; set; }
        public bool AllowDelete { get; set; }

        private readonly IEmployee m_Employee;

        public EditEmployeeModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }
        public void OnGet(int id)
        {
            EmployeeData = m_Employee.GetEmployeeById(id);
            
            if (Request.Query["IsDelete"].FirstOrDefault() != null)
            {
                AllowDelete = true;
                SetDCInfo(Navigator.EmployeeList);
            }
            else 
            {
                
                SetCCInfo(Navigator.EmployeeList);
            }
           
        }

        public IActionResult OnGetDelete(int id, int listId)
        {
            try
            {
                m_Employee.MarkDeleteEmployee(id);
                TempData["Message"] = "Employee has been deleted succesfully";
                return RedirectToPage(Navigator.EmployeeList, new { listId });
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
                if (string.IsNullOrEmpty(EmployeeData.EmployeeName))
                {
                    TempData["Message"] = "Employee Name is required";
                    return Page();
                }
                m_Employee.UpdateEmployee(EmployeeData);

                TempData["Message"] = "Employee has been updated succesfully";
                return RedirectToPage(Navigator.EmployeeList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
