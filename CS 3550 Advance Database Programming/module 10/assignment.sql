USE NorthWind;

DROP TABLE [Order Details Audit Trail];

CREATE TABLE [Order Details Audit Trail](
	OrderID INT NOT NULL,
	ProductID INT NOT NULL,
	UserName VARCHAR(120), 
	EditedTimeStamp DATETIME NOT NULL,
	OldUnitPrice MONEY NOT NULL,
	NewUnitPrice MONEY NOT NULL); 

GO

CREATE OR ALTER TRIGGER Audit_Trail
ON [Order Details]
FOR UPDATE
AS
	DECLARE @OrderID INT
	DECLARE @ProductID INT
	DECLARE @UserName VARCHAR(120)
	DECLARE @OldPrice INT
	DECLARE @NewPrice INT
	
	SELECT @OrderID = OrderID
	FROM inserted

	SELECT @ProductID = ProductID
	from inserted

	SELECT @UserName = login_name
	FROM sys.dm_exec_sessions
	WHERE session_id = @@SPID

	SELECT @OldPrice = UnitPrice
	FROM deleted

	SELECT @NewPrice = UnitPrice
	FROM inserted

	INSERT INTO [Order Details Audit Trail](OrderID, ProductID, UserName, EditedTimeStamp, OldUnitPrice, NewUnitPrice)
	SELECT OrderID, ProductID, SYSTEM_USER, CURRENT_TIMESTAMP, @OldPrice, @NewPrice
	FROM inserted;

GO

UPDATE [Order Details]
SET UnitPrice = 34.00
WHERE ProductID = 65;

SELECT [OrderID]
      ,[ProductID]
      ,[UserName]
      ,[EditedTimeStamp]
      ,[OldUnitPrice]
      ,[NewUnitPrice]
FROM [Order Details Audit Trail];


ALTER TABLE Orders NOCHECK CONSTRAINT FK_Orders_Customers;
ALTER TABLE Orders NOCHECK CONSTRAINT FK_CustomerID_default;

UPDATE Customers
SET CustomerID = 'QWRTY'
WHERE CustomerID = 'VINET';

GO

DROP TRIGGER fk_order_customers_on_update_no_action


GO
CREATE OR ALTER TRIGGER fk_order_customers_on_update_no_action
ON Customers
FOR UPDATE
AS
	DECLARE @OldID VARCHAR(5)
	DECLARE @NewID VARCHAR(5)

	SELECT @OldID = CustomerID
	FROM deleted

	SELECT @NewID = CustomerID
	FROM inserted

	IF @OldID != @NewID
	BEGIN
		IF EXISTS (SELECT 1 FROM Orders WHERE CustomerID = @OldID)
		BEGIN
			PRINT('Cannot not update Customer ID since it is used in the Orders table')
			ROLLBACK
		END
	END;


GO
CREATE OR ALTER TRIGGER fk_orders_customers_on_update_cascade
ON Customers
FOR UPDATE
AS
	DECLARE @OldID VARCHAR(5)
	DECLARE @NewID VARCHAR(5)

	SELECT @OldID = CustomerID
	FROM deleted

	SELECT @NewID = CustomerID
	FROM inserted

	IF @OldID != @NewID
	BEGIN
		IF EXISTS (SELECT 1 FROM Orders WHERE CustomerID = @OldID)
		BEGIN
			UPDATE Orders
			SET CustomerID = @NewID
			WHERE CustomerID = @OldID
		END
	END;



GO
CREATE OR ALTER TRIGGER fk_orders_shippers_on_update_no_action
ON Shippers
FOR UPDATE
AS
	DECLARE @OldID INT
	DECLARE @NewID INT

	SELECT @OldID = ShipperID
	FROM deleted

	SELECT @NewID = ShipperID
	FROM inserted

	IF @OldID != @NewID
	BEGIN
		IF EXISTS (SELECT 1 FROM Orders WHERE ShipVia = @OldID)
		BEGIN
			PRINT('Cannot not update ShipperID since it is used in the Orders table')
			ROLLBACK
		END
	END;



GO
CREATE OR ALTER TRIGGER  fk_orders_shippers_on_update_cascade
ON Shippers
FOR UPDATE
AS
	DECLARE @OldID INT
	DECLARE @NewID INT

	SELECT @OldID = ShipperID
	FROM deleted

	SELECT @NewID = ShipperID
	FROM inserted

	IF @OldID != @NewID
	BEGIN

		IF EXISTS (SELECT 1 FROM Orders WHERE ShipVia = @OldID)
		BEGIN
			UPDATE Orders
			SET ShipVia = @NewID
			WHERE ShipVia = @OldID
		END
	END;