using EMSDataAccess;
using EMSDomain;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class EmployeeListModel : TransactionBase
    {
        public IList<EmployeeListDTO> EmployeeList { get; set; }


        private readonly IEmployee m_Employee;

        public EmployeeListModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }

        public void OnGet()
        {
            EmployeeList = m_Employee.GetAllEmployees();
        }
    }
}
