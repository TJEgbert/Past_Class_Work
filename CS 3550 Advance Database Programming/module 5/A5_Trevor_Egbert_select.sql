--Part 1
WITH CTE1 AS (
  SELECT 
    O.CustomerID, 
    O.OrderID, 
    OD.ProductID 
  FROM 
    Orders AS O 
    LEFT OUTER JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID 
  WHERE 
    OD.ProductID IN (
      SELECT 
        ProductID 
      FROM 
        Products 
      WHERE 
        ProductName = 'Chai' 
        OR ProductName = 'Chang'
    )
) 
SELECT 
  CompanyName, 
  ContactName 
FROM 
  Customers AS C 
WHERE 
  C.CustomerID IN (
    SELECT 
      CustomerID 
    FROM 
      CTE1
  ) 
ORDER BY 
  CompanyName ASC;

--Part 2
SELECT 
  Country, 
  COUNT(CustomerID) NumOfCustomers 
FROM 
  Customers 
GROUP BY 
  Country;

--Part 3
SELECT 
  Country 
FROM 
  Customers 
GROUP BY 
  Country 
HAVING 
  COUNT(CustomerID) >= 5;

-- Part 4
SELECT 
  E.FirstName, 
  E.LastName, 
  COUNT(O.OrderID) AS NumOfOrders 
FROM 
  Employees AS E 
  LEFT OUTER JOIN Orders AS O ON E.EmployeeID = O.EmployeeID 
GROUP BY 
  E.FirstName, 
  E.LastName 
HAVING 
  COUNT(O.OrderID) > 50;

-- Part 5
WITH CTE2 AS (
  SELECT 
    R.RegionID, 
    T.TerritoryID 
  FROM 
    Region AS R 
    LEFT OUTER JOIN Territories AS T ON R.RegionID = T.RegionID 
  WHERE 
    R.RegionDescription = 'Western'
) 
SELECT 
  E.FirstName, 
  E.LastName, 
  E.Title, 
  E.Address, 
  E.City, 
  E.PostalCode 
FROM 
  Employees AS E 
WHERE 
  e.EmployeeID IN (
    SELECT 
      EmployeeID 
    FROM 
      EmployeeTerritories AS ET 
    WHERE 
      ET.TerritoryID IN (
        SELECT 
          C.TerritoryID 
        FROM 
          CTE2 AS C
      ) 
    GROUP BY 
      EmployeeID
  ) 
ORDER BY 
  E.FirstName;

-- Part 6
WITH CTE3 AS (
  SELECT 
    OD.ProductID 
  FROM 
    Orders AS O 
    LEFT OUTER JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID 
  WHERE 
    EmployeeID = (
      SELECT 
        EmployeeID 
      FROM 
        Employees 
      WHERE 
        LastName LIKE 'L%'
    ) 
    AND Shipvia = (
      SELECT 
        ShipperID 
      FROM 
        Shippers 
      WHERE 
        CompanyName = 'Federal Shipping'
    )
) 
SELECT 
  DISTINCT ProductName 
FROM 
  Products AS P 
WHERE 
  P.ProductID IN (
    SELECT 
      C.ProductID 
    FROM 
      CTE3 AS C
  );

-- Part 7
SELECT 
  P.ProductName, 
  S.CompanyName 
FROM 
  Products AS P 
  LEFT OUTER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID 
WHERE 
  P.CategoryID IN (
    SELECT 
      CategoryID 
    FROM 
      Categories 
    WHERE 
      CategoryName = 'Beverages'
  );

-- Part 8
SELECT 
  E.LastName, 
  E.FirstName 
FROM 
  Employees AS E 
WHERE 
  E.ReportsTo = (
    SELECT 
      M.EmployeeID 
    FROM 
      Employees AS M 
    WHERE 
      M.Title = 'Vice President, Sales'
  );