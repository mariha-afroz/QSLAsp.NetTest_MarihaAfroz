/************************************************************/
-- ANSI AND QUOTED ON STORED PROCS
/************************************************************/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/************************************************************/
-- ALL NEW AND UPDATED ANSI AND QUOTED OFF PROCS GOES BELOW
/************************************************************/

/************************************************************
Description:  Employees Search
*****************************************************************/
DROP PROCEDURE IF EXISTS [dbo].[SearchEmployees]
GO
CREATE OR ALTER PROCEDURE [dbo].[SearchEmployees]
    @EmployeeName NVARCHAR(100),
    @DepartmentId INT,
    @Position NVARCHAR(100),
    @MinScore INT,
    @MaxScore INT,
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @Params NVARCHAR(MAX) = N'@EmployeeName NVARCHAR(100), @DepartmentId INT, @Position NVARCHAR(100), @MinScore INT, @MaxScore INT, @PageNumber INT, @PageSize INT';

    SET @SQL = N'
        SELECT E.Id, E.EmployeeName, D.DepartmentName, E.Position, MIN(PR.ReviewScore) AS MinScore, MAX(PR.ReviewScore) AS MaxScore
        FROM Employees E
        LEFT JOIN Departments D ON E.DepartmentId = D.Id
        LEFT JOIN PerformanceReviews PR ON E.Id = PR.EmployeeId ';

    SET @SQL += N'WHERE E.IsDeleted = 0 '; 

    IF @EmployeeName IS NOT NULL AND @EmployeeName <> ''
        SET @SQL += N'AND E.EmployeeName LIKE ''%' + @EmployeeName + '%'' ';
    IF @DepartmentId IS NOT NULL AND @DepartmentId <> 0
        SET @SQL += N'AND E.DepartmentId = @DepartmentId ';
    IF @Position IS NOT NULL AND @Position <> ''
        SET @SQL += N'AND E.Position LIKE ''%' + @Position + '%'' ';
    IF @MinScore IS NOT NULL
        SET @SQL += N'AND PR.ReviewScore >= @MinScore ';
    IF @MaxScore IS NOT NULL
        SET @SQL += N'AND PR.ReviewScore <= @MaxScore ';

    SET @SQL += N'
        GROUP BY E.Id, E.EmployeeName, D.DepartmentName, E.Position
        ORDER BY E.Id
        OFFSET (' + CAST((@PageNumber - 1) * @PageSize AS NVARCHAR) + ') ROWS 
        FETCH NEXT ' + CAST(@PageSize AS NVARCHAR) + ' ROWS ONLY;';

    PRINT @SQL;

    EXEC sp_executesql @SQL, @Params, 
        @EmployeeName, @DepartmentId, @Position, @MinScore, @MaxScore, @PageNumber, @PageSize;
END;
GO

/************************************************************/
-- ANSI AND QUOTED ON STORED PROCS
/************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************/
-- ALL NEW AND UPDATED ANSI AND QUOTED ON PROCS GOES BELOW


/************************************************************/

/************************************************************
Description:  List of the Employees
*****************************************************************/
DROP PROCEDURE IF EXISTS [dbo].[GetAllEmployees]
GO
CREATE OR ALTER PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 	
		Emp.Id,
		Emp.EmployeeName,
		Emp.Phone,
		DepartmentName = ISNULL(D.DepartmentName, 'No Department'),
		Emp.JoiningDate
	FROM  Employees Emp 
	LEFT JOIN Departments D ON Emp.DepartmentId = D.Id
	WHERE Emp.IsDeleted = 0
	ORDER BY Emp.Id DESC
END
GO
/************************************************************
Description:  List of the Departments
*****************************************************************/
DROP PROCEDURE IF EXISTS [dbo].[GetAllDepartments]
GO
CREATE OR ALTER PROCEDURE [dbo].[GetAllDepartments]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 	
		D.Id,
		D.DepartmentName,
		Manager = ISNULL(Emp.EmployeeName,'No Employee'),
		D.Budget

	FROM  Departments D 
	LEFT JOIN Employees Emp ON D.ManagerId = Emp.Id
	ORDER BY Emp.Id DESC
END
GO
/************************************************************
Description:  List of the Performance Reviews
*****************************************************************/
DROP PROCEDURE IF EXISTS [dbo].[GetAllPerformanceReviews]
GO
CREATE OR ALTER PROCEDURE [dbo].[GetAllPerformanceReviews]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 	
		Per.Id,
		EmployeeName = ISNULL(Emp.EmployeeName,'No Employee'),
		Per.ReviewDate,
		Per.ReviewScore, 
		Per.ReviewNotes

	FROM  PerformanceReviews Per 
	LEFT JOIN Employees Emp ON Per.EmployeeId = Emp.Id
	ORDER BY Emp.Id DESC
END
GO