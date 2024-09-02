USE NorthWind;

GO 
DROP 
  PROCEDURE IF EXISTS ExpediteOrder GO CREATE PROCEDURE ExpediteOrder (@OrderID INT) AS BEGIN;
SET 
  NOCOUNT ON IF EXISTS (
    SELECT 
      OrderID 
    FROM 
      Orders 
    WHERE 
      OrderID = @OrderID
  ) BEGIN;
IF(
  SELECT 
    DATEDIFF(day, OrderDate, ShippedDate) 
  FROM 
    Orders 
  WHERE 
    OrderID = @OrderID
) > 10 BEGIN;
UPDATE 
  Orders 
SET 
  ShippedDate = DATEADD(Day, -7, ShippedDate), 
  Freight = (Freight * 2) 
WHERE 
  OrderId = @OrderID 
SELECT 
  ShippedDate 
FROM 
  Orders 
WHERE 
  OrderID = @OrderID RETURN END;
ELSE BEGIN;
SELECT 
  ShippedDate 
FROM 
  Orders 
WHERE 
  OrderID = @OrderID RETURN END;
END;
SET 
  NOCOUNT OFF END;


EXEC ExpediteOrder @OrderID = 10254;

 /*
	ShippedDate
	1996-07-16 00:00:00.000
 */