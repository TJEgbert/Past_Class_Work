USE NorthWind;

/*SELECT *
FROM dbo.[Order Details] AS O
LEFT OUTER JOIN Products P
ON O.ProductID = P.ProductID
WHERE P.CategoryID = 1;

SELECT OrderId, SUM(Quantity * UnitPrice) TotalPrice
FROM dbo.[Order Details]
WHERE OrderID = 10253
GROUP BY OrderID;

SELECT *
FROM dbo.[Order Details]
WHERE OrderID = 10253;

SELECT *
FROM Categories;*/

SELECT RegionID, RegionDescription 
FROM Region;

SELECT T.TerritoryID, R.RegionDescription
FROM Territories AS T
LEFT OUTER JOIN Region AS R
ON T.RegionID = R.RegionID
WHERE R.RegionDescription = 'Western'

SELECT EmployeeID
FROM EmployeeTerritories
WHERE TerritoryID IN (SELECT T.TerritoryID
		FROM Territories AS T
		LEFT OUTER JOIN Region AS R
		ON T.RegionID = R.RegionID
		WHERE R.RegionDescription = 'Southern');