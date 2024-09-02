GO

CREATE OR ALTER PROCEDURE sp_remove_order_details_by_product_id
(@productID INT)
AS
BEGIN
	DELETE  FROM [Order Details]
	WHERE ProductID = @productID;
END


go
declare remove_cursor_for_disconinued_product cursor
for
	SELECT ProductID FROM Products
	WHERE Discontinued = 1;
declare @productid int
open remove_cursor_for_disconinued_product

FETCH NEXT FROM remove_cursor_for_disconinued_product
while @@FETCH_STATUS = 0

begin
	print @productid;

	
	SELECT OrderID
	INTO #temp_order_removal
	FROM [Order Details]
	WHERE ProductID = @productid AND OrderID IN(
									SELECT OrderID 
									FROM [Order Details] 
									GROUP BY OrderID 
									HAVING COUNT(OrderID) = 1);
	

	select * from #temp_order_removal
	EXECUTE sp_remove_order_details_by_product_id @productID = @productid;
	DELETE FROM Orders
	WHERE OrderID IN (select * from #temp_order_removal)
	drop table #temp_order_removal 
	fetch next from remove_cursor_for_disconinued_product
	into @productid
		
end

close remove_cursor_for_disconinued_product
deallocate remove_cursor_for_disconinued_product