USE NorthWind;

GO 
DROP 
  PROCEDURE IF EXISTS ExpediteDelivery GO CREATE PROCEDURE ExpediteDelivery (
    @CustomerID NCHAR(5)
  ) AS BEGIN;
SET 
  NOCOUNT ON;
IF EXISTS (
  SELECT 
    1 
  FROM 
    Customers 
  where 
    CustomerID = @CustomerID
) BEGIN;
IF (
  SELECT 
    TOP 1 DATEDIFF(day, OrderDate, ShippedDate) 
  FROM 
    Orders 
  WHERE 
    CustomerID = @CustomerID 
    AND DATEDIFF(day, OrderDate, ShippedDate) < 10
) < 10 BEGIN;
SELECT 
  OrderID, 
  OrderDate, 
  ShippedDate, 
  DATEDIFF(day, OrderDate, ShippedDate) DaysBetween 
FROM 
  Orders 
WHERE 
  CustomerID = @CustomerID 
  AND DATEDIFF(day, OrderDate, ShippedDate) < 10 END;
IF (
  SELECT 
    TOP 1 DATEDIFF(day, OrderDate, ShippedDate) 
  FROM 
    Orders 
  WHERE 
    CustomerID = @CustomerID 
    AND DATEDIFF(day, OrderDate, ShippedDate) > 10
) > 10 BEGIN;
UPDATE 
  Orders 
SET 
  ShippedDate = DATEADD(Day, -7, ShippedDate), 
  Freight = (Freight * 2) 
WHERE 
  CustomerID = @CustomerID 
  AND DATEDIFF(day, OrderDate, ShippedDate) > 10 END;
END;
SET 
  NOCOUNT OFF;
END;

EXEC ExpediteDelivery @CustomerID = 'VINET';

/*SELECT 
  OrderID, 
  Freight, 
  OrderDate, 
  ShippedDate, 
  DATEDIFF(day, OrderDate, ShippedDate) DaysBetween 
FROM 
  Orders 
WHERE 
  CustomerID = 'VINET';*/


/*
Results from (OrderDate - Shipped) < 10
OrderID	OrderDate					ShippedDate					DaysBetween
10295	1996-09-02 00:00:00.000		1996-09-10 00:00:00.000		8
10737	1997-11-11 00:00:00.000		1997-11-18 00:00:00.000		7
10739	1997-11-12 00:00:00.000		1997-11-17 00:00:00.000		5

Results After (OrderDate - Shipped) > 10

OrderID	Freight	OrderDate					ShippedDate					DaysBetween
10248	64.76	1996-07-04 00:00:00.000		1996-07-09 00:00:00.000		5
10274	6.01	1996-08-06 00:00:00.000		1996-08-16 00:00:00.000		10
10295	1.15	1996-09-02 00:00:00.000		1996-09-10 00:00:00.000		8
10737	7.79	1997-11-11 00:00:00.000		1997-11-18 00:00:00.000		7
10739	11.08	1997-11-12 00:00:00.000		1997-11-17 00:00:00.000		5

*/