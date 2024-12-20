using EMSDomain;
using EMSDomain.Employees;
using EMSDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDataAccess
{
    public interface IEmployee
    {
        #region Employee
        Employee GetEmployeeById(int id);
        IList<EmployeeListDTO> GetAllEmployees();
        int CreateEmployee(Employee employeeData);
        bool UpdateEmployee(Employee employeeData);
        bool MarkDeleteEmployee(int id);
        #endregion Employee

        #region Departments
        Department GetDepartmentById(int id);
        IList<DepartementListDTO> GetAllDepartments();
        int CreateDepartment(Department departmentData);
        bool UpdateDepartment(Department employeeData);

        #endregion Departments

        #region Performance Review
        PerformanceReview GetPerformanceReviewById(int id);
        IList<PerformanceReviewListDTO> GetAllPerformanceReviews();
        int CreatePerformanceReview(PerformanceReview performanceReviewData);
        bool UpdatePerformanceReview(PerformanceReview performanceReviewData);

        #endregion Performance Review

        #region Average Performance Review
        IList<AveragePerformanceScoreDTO> GetAveragePerfromanceScoreByDepartmentId(int departmentId);
        #endregion Average Performance Review

        #region Search
        IList<EmployeeSearchDTO> SearchEmployee(EmployeeSearchCriteria criteria);
        #endregion Search
    }
}
