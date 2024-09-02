-- Part 1
INSERT INTO Products(
  ProductName, SupplierID, CategoryID, 
  QuantityPerUnit, UnitPrice, UnitsInStock, 
  UnitsOnOrder, ReorderLevel, Discontinued
) 
VALUES 
  (
    'Super Drink', 23, 1, '12 count of 8oz cans', 
    20.00, 30, 5, 10, 0
  ), 
  (
    'Ultra Drink', 23, 1, '24 count of 8oz cans', 
    50.00, 30, 2, 10, 0
  );

INSERT INTO Orders(
  CustomerID, EmployeeID, OrderDate, 
  RequiredDate, ShippedDate, ShipVia, 
  Freight, ShipName, ShipAddress, ShipCity, 
  ShipRegion, ShipPostalCode, ShipCountry
) 
VALUES 
  (
    'VINET', 5, '2024-02-07', NULL, NULL, 
    3, 21.00, 'Vins et alcools Chevalier', 
    '123456 Street', 'Number Town', 
    NULL, '51100', 'France'
  ), 
  (
    'VINET', 5, '2024-02-06', NULL, NULL, 
    3, 21.00, 'Vins et alcools Chevalier', 
    '123456 Street', 'Number Town', 
    NULL, '51100', 'France'
  ), 
  (
    'VINET', 5, '2024-02-05', NULL, NULL, 
    3, 21.00, 'Vins et alcools Chevalier', 
    '123456 Street', 'Number Town', 
    NULL, '51100', 'France'
  ), 
  (
    'VINET', 5, '2024-02-04', NULL, NULL, 
    3, 21.00, 'Vins et alcools Chevalier', 
    '123456 Street', 'Number Town', 
    NULL, '51100', 'France'
  );

INSERT INTO [Order Details](
  OrderID, ProductID, UnitPrice, Quantity, 
  Discount
) 
VALUES 
  (11082, 82, 20.00, 1, 0), 
  (11082, 83, 50.00, 1, 0), 
  (11083, 82, 20.00, 1, 0), 
  (11083, 83, 50.00, 1, 0), 
  (11084, 82, 20.00, 1, 0), 
  (11084, 83, 50.00, 1, 0), 
  (11085, 82, 20.00, 1, 0), 
  (11085, 83, 50.00, 1, 0);

SELECT 
  OrderID, 
  ProductID, 
  UnitPrice, 
  Quantity, 
  Discount 
FROM 
  [Order Details] 
WHERE 
  OrderID = 11082 
  OR OrderID = 11083 
  OR OrderID = 11084 
  OR OrderID = 11085;



-- Part 2
UPDATE 
  [Order Details] 
Set 
  Discount = Discount + 0.1 
WHERE 
  UnitPrice > 20;



-- Part 3
DELETE [Order Details] 
WHERE 
  OrderID = 11082 
  OR OrderID = 11083 
  OR OrderID = 11084 
  OR OrderID = 11085 DELETE Orders 
WHERE 
  OrderID = 11082 
  OR OrderID = 11083 
  OR OrderID = 11084 
  OR OrderID = 11085 DELETE Products 
WHERE 
  ProductID = 82 
  OR ProductID = 83;


--Part 4
SELECT 
  DISTINCT EmployeeID 
FROM 
  EmployeeTerritories 
WHERE 
  TerritoryID IN (
    SELECT 
      TerritoryID 
    FROM 
      Territories 
    WHERE 
      RegionID = (
        SELECT 
          RegionID 
        FROM 
          Region 
        WHERE 
          RegionDescription = 'Eastern'
      )
  );

SELECT 
  TerritoryID 
FROM 
  Territories 
WHERE 
  RegionID IN (
    SELECT 
      RegionID 
    FROM 
      Region 
    WHERE 
      RegionDescription = 'Western'
  );

DELETE EmployeeTerritories 
WHERE 
  EmployeeID = 1 
  OR EmployeeID = 2 
  OR EmployeeID = 4 
  OR EmployeeID = 5;

INSERT INTO EmployeeTerritories(EmployeeID, TerritoryID) 
VALUES 
  (1, '60179'), 
  (2, '60601'), 
  (4, '80202'), 
  (5, '80909');

DELETE Territories 
WHERE 
  RegionID IN (
    SELECT 
      RegionID 
    FROM 
      Region 
    WHERE 
      RegionDescription = 'Eastern'
  );

DELETE Region 
WHERE 
  RegionDescription = 'Eastern';
