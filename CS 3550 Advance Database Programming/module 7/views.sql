USE NorthWind;

SELECT [ProductID]
      ,[ProductName]
      ,[SupplierID]
      ,[CategoryID]
      ,[QuantityPerUnit]
      ,[UnitPrice]
      ,[UnitsInStock]
      ,[UnitsOnOrder]
      ,[ReorderLevel]
      ,[Discontinued]
      ,[CategoryName]
	  FROM [Alphabetical list of products]
WHERE Discontinued = 0 AND ProductID IN (SELECT ProductID FROM Invoices WHERE ShippedDate BETWEEN '1997-01-01' AND '1997-03-31')
ORDER BY CategoryName;

GO

CREATE VIEW [Order Details Extended Above Average] AS
SELECT od.OrderID, od.ProductID, p.ProductName, od.UnitPrice, od.Quantity, od.Discount, (CONVERT(money, (od.UnitPrice * od.Quantity) * (1 - od.Discount) / 100) * 100) AS ExtendedPrice
FROM [Order Details] AS od
LEFT OUTER JOIN Products AS p
ON od.ProductID = p.ProductID
WHERE (CONVERT(money, (od.UnitPrice * od.Quantity) * (1 - od.Discount) / 100) * 100) > (SELECT AVG(CONVERT(money, (UnitPrice * Quantity) * (1 - Discount) / 100) * 100) FROM [Order Details]);


GO
SELECT [OrderID]
      ,[ProductID]
      ,[ProductName]
      ,[UnitPrice]
      ,[Quantity]
      ,[Discount]
      ,[ExtendedPrice]
FROM [Order Details Extended Above Average];