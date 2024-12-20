using EMSDomain;
using EMSDomain.Employees;
using EMSDomain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDataAccess.Managers
{
    public class EmployeeManager : BaseDataManager, IEmployee
    {
        public EmployeeManager(EMSModel context) : base(context) { }

        #region Employee

        public Employee GetEmployeeById(int id)
        {
            return FindEntity<Employee>(id);

        }

        public IList<EmployeeListDTO> GetAllEmployees()
        {
            return GetListData<EmployeeListDTO>($"EXEC GetAllEmployees");

        }
        public int CreateEmployee(Employee employeeData)
        {
            dbModel.Employees.Add(employeeData);
            dbModel.SaveChanges();
            return employeeData.Id;
        }

        public bool UpdateEmployee(Employee employeeData)
        {
            return AddUpdateEntity(employeeData);

        }

        public bool MarkDeleteEmployee(int id)
        {
            ExecuteSqlInterpolated($"UPDATE Employees SET IsDeleted = 1 WHERE Id = {id}");
            return true;
        }
        #endregion Employee

        #region Departments
        public Department GetDepartmentById(int id)
        {
            return FindEntity<Department>(id);

        }

        public IList<DepartementListDTO> GetAllDepartments()
        {
            return GetListData<DepartementListDTO>($"EXEC GetAllDepartments");
        }
        public int CreateDepartment(Department departmentData)
        {
            dbModel.Departments.Add(departmentData);
            dbModel.SaveChanges();
            return departmentData.Id;
        }

        public bool UpdateDepartment(Department employeeData)
        {
            return AddUpdateEntity(employeeData);

        }

        #endregion Departments

        #region Performance Review
        public PerformanceReview GetPerformanceReviewById(int id)
        {
            return FindEntity<PerformanceReview>(id);
        }
        public IList<PerformanceReviewListDTO> GetAllPerformanceReviews()
        {
            return GetListData<PerformanceReviewListDTO>($"EXEC GetAllPerformanceReviews");
        }

        public int CreatePerformanceReview(PerformanceReview performanceReviewData)
        {
            dbModel.PerformanceReviews.Add(performanceReviewData);
            dbModel.SaveChanges();
            return performanceReviewData.Id;
        }

        public bool UpdatePerformanceReview(PerformanceReview performanceReviewData)
        {
            return AddUpdateEntity(performanceReviewData);
        }
        #endregion Performance Review

        #region Average Performance Score
        public IList<AveragePerformanceScoreDTO> GetAveragePerfromanceScoreByDepartmentId(int departmentId)
        {
            return GetListData<AveragePerformanceScoreDTO>($"EXEC GetAveragePerfromanceScoreByDepartmentId @departmentId={departmentId}");
        }
        #endregion Average Performance Score

        #region Employee Search
        public IList<EmployeeSearchDTO> SearchEmployee(EmployeeSearchCriteria criteria)
        {
            try
            {
                var parameters = new[]
                {
        new SqlParameter("@EmployeeName", SqlDbType.NVarChar) { Value = (object)criteria.EmployeeName ?? DBNull.Value },
        new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = (object)criteria.DepartmentId ?? DBNull.Value },
        new SqlParameter("@Position", SqlDbType.NVarChar) { Value = (object)criteria.Position ?? DBNull.Value },
        new SqlParameter("@MinScore", SqlDbType.Int) { Value = (object)criteria.MinScore ?? DBNull.Value },
        new SqlParameter("@MaxScore", SqlDbType.Int) { Value = (object)criteria.MaxScore ?? DBNull.Value },
        new SqlParameter("@PageNumber", SqlDbType.Int) { Value = criteria.PageNumber },
        new SqlParameter("@PageSize", SqlDbType.Int) { Value = criteria.PageSize }
                };

                return GetListData<EmployeeSearchDTO>("EXEC SearchEmployees @EmployeeName, @DepartmentId, @Position, @MinScore, @MaxScore, @PageNumber, @PageSize", parameters).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
        #endregion Employee Search
    }
}
