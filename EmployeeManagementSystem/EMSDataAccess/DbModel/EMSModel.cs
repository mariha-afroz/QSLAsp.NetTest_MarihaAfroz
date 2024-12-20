using EMSDomain;
using EMSDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSDataAccess
{
    public partial class EMSModel : DbContext
    {
        public EMSModel(DbContextOptions<EMSModel> options) : base(options)
        {

        }
        #region Employee
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<PerformanceReview> PerformanceReviews { get; set; }
        #endregion Employee

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeListDTO>().HasNoKey().ToView("EmployeeListDTO"); 
            modelBuilder.Entity<DepartementListDTO>().HasNoKey().ToView("DepartementListDTO");
            modelBuilder.Entity<PerformanceReviewListDTO>().HasNoKey().ToView("PerformanceReviewListDTO");
            modelBuilder.Entity<AveragePerformanceScoreDTO>().HasNoKey().ToView("AveragePerformanceScoreDTO");
            modelBuilder.Entity<EmployeeSearchDTO>().HasNoKey().ToView("EmployeeSearchDTO");
        }
    }

}
