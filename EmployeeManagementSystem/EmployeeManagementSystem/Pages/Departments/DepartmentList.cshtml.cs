using EMSDataAccess;
using EMSDomain;

namespace EmployeeManagementSystem.Pages.Departments
{
    public class DepartmentListModel : TransactionBase
    {
        public IList<DepartementListDTO> DepartementList { get; set; }


        private readonly IEmployee m_Employee;

        public DepartmentListModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }

        public void OnGet()
        {
            DepartementList = m_Employee.GetAllDepartments();
        }
    }
}
