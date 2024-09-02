--Adding a default value to CustomerID in the Orders Table
ALTER TABLE dbo.Orders
ADD DEFAULT 'DELET' FOR CustomerID;

--Setting ON DELETE to switch customerID to the defualt value
ALTER TABLE dbo.Orders
ADD CONSTRAINT FK_CustomerID_default
FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID) ON DELETE SET DEFAULT;

-- Setting ON DELETE to switch ShipVia to null
ALTER TABLE dbo.Orders
ADD CONSTRAINT FK_ShipVia_null
FOREIGN KEY (ShipVia) REFERENCES dbo.Shippers(ShipperID) ON DELETE SET NULL;