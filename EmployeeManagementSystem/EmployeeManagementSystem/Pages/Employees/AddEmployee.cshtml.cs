using DocumentFormat.OpenXml.Spreadsheet;
using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class AddEmployeeModel : TransactionBase
    {
        [BindProperty]
        public Employee EmployeeData { get; set; }

        public IList<DepartementListDTO> departments { get; set; }

        private readonly IEmployee m_Employee;

        public AddEmployeeModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }
        public void OnGet()
        {
            try
            {
                EmployeeData = new Employee
                {
                    JoiningDate = DateTime.Now,
                };

                SetCCInfo($"{Navigator.EmployeeList}");

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
                m_Employee.CreateEmployee(EmployeeData);

                TempData["Message"] = "Employee has been created successfully";

                return RedirectToPage(Navigator.EmployeeList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
