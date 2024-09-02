USE NorthWind;
GO 
DROP 
  FUNCTION IF EXISTS EmployeesFromRegion;
GO CREATE FUNCTION EmployeesFromRegion(
  @RegionName NCHAR(50)
) RETURNS INT AS BEGIN;
DECLARE @NumOfEmployees INT;
IF EXISTS (
  SELECT 
    1 
  FROM 
    Region 
  WHERE 
    RegionDescription = @RegionName
) BEGIN;
SELECT 
  @NumOfEmployees = COUNT(DISTINCT EmployeeID) 
FROM 
  EmployeeTerritories 
WHERE 
  TerritoryID IN (
    SELECT 
      T.TerritoryID 
    FROM 
      Territories AS T 
      LEFT OUTER JOIN Region AS R ON T.RegionID = R.RegionID 
    WHERE 
      R.RegionDescription = @RegionName
  );
END;
Return @NumOfEmployees END;

GO 
SELECT 
  dbo.EmployeesFromRegion('Northern') AS NumberOfEmployees;
SELECT 
  dbo.EmployeesFromRegion('Eastern') AS NumberOfEmployees;
SELECT 
  dbo.EmployeesFromRegion('Southern') AS NumberOfEmployees;
SELECT 
  dbo.EmployeesFromRegion('Western') AS NumberOfEmployees;

/*
Northern	2
Eastern		4
Southern	1
Western		2
*/