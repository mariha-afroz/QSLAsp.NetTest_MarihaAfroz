Project Overview 

Employee Management System (EMS)
Introduction
The Employee Management System (EMS) is a full-fledged web application designed to streamline employee, department, and performance management. The project leverages clean architecture principles to ensure loose coupling, maintainability, and scalability.

This project has been designed as per the requirements. The five tasks which were mentioned in the assessments are all completed and explained below. 

Architecture Overview
Data Access Layer
Components: Includes a DbModel with DbSet properties for Employee, Department, and PerformanceReview.
Features:
Migrations Folder: Contains migration files for database schema management.
Stored Procedure & DDL Files: SQL scripts for stored procedures and data definition tasks.
Base Manager: Handles common data access operations to reduce redundancy.
Interfaces:
IEmployee for employee-specific operations.
Managers:
EmployeeManager implements IEmployee.
References:
Depends on CommonLib and Domain projects.

Domain Layer:
Components:
Models: Employee, Department, PerformanceReview, and EmployeeSearchCriteria.
DTOs: Located in the Models folder, used to retrieve data from stored procedures.
BaseEntity: Ensures consistency and avoids repetition across models.
References:
Depends on CommonLib.

Application Layer:
Components:
UI: Includes Razor Pages, layouts, and styling with Bootstrap, Telerik, and a custom Style.CSS.
Configuration:
appsettings.json contains the database connection string (EMSDb).
Programmatic dependency injection via program.cs.
References:
Depends on CommonLib, DataAccess, and Domain.

CommonLib:
Contains common libraries and configurations shared across layers.

Core Functionalities: 

Employee Management
1. Employee List: Displays all employees.
2. Add Employee: Includes department selection (populated from the Department table).
3. Edit Employee: Allows updates to employee details.
4. Soft Delete: Marks an employee as deleted (IsDelete = 1) without removing the record from the database.

Department Management: 
1. Department List: Displays all departments.
2. Add Department: Includes manager selection (populated from the Employee table).
3. Edit Department: Updates department details.

Performance Review: 
1. Add Review: Allows adding performance reviews for employees.
2. Quarter-Based Filter: Filters reviews by quarter (uses a Quarter enum).

Average Performance Score:
Calculates and displays the average review scores for employees in a selected department. Uses indexing for efficient queries on large datasets.

Advanced Search:
Search employees using the following filters (individually or in combination):
1. Employee Name
2. Department
3. Position
4. Review Score (1–10)
5. Default: Displays all employees if no filter is selected.
6. Includes pagination via Kendo UI.

Setup and Configuration:
Prerequisites-
1. Install Visual Studio.
2. Install SQL Server Management Studio.
Steps
1. Open EmployeeManagementSystem.sln in Visual Studio.
2. Restore NuGet packages if not already installed.
3. Add project references (CommonLib, DataAccess, Domain) as mentioned earlier.
4. Update appsettings.json with your SQL Server's name:
"ConnectionStrings": {
  "DefaultConnection": "Server=YourServerName;Database=EMSDb;Trusted_Connection=True;"
}
5. Run migrations:
Open Package Manager Console.
Select EMSDataAccess as the default project.
Run Update-Database to apply migrations.
6. Execute the stored procedure and DDL SQL files in the DataAccess folder on the EMSDb database.
7. Clean, rebuild, and build the solution.
8. Run the application using IIS Express.

Additional Enhancements:
1. Partial Views: Includes reusable partial Razor views for save, update, delete, and navigation utilities.
2. Manual Validation: Ensures required fields are validated before data is saved.
3. Pagination & Search: Uses Kendo UI for seamless navigation and search functionality.

Future Improvements:

1. Model Validations: Adding attribute-level validations in the models would ensure stricter data integrity and improve the overall robustness of the application. This can include annotations like [Required], [StringLength], and [Range] to enforce constraints directly within the model.

2. UI/UX Enhancements: The overall look and feel of the application could be refined further for better user experience.

3. Database Deployment: While I successfully deployed the application's code, I could not deploy the local database to an online environment due to time constraints and the need for additional research. Deploying the database online would streamline the transition and improve accessibility for smoother demonstrations.

