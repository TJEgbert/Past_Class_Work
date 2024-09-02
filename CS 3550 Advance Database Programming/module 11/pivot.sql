USE NorthWind;

SELECT * FROM 
(
	SELECT CategoryName, UnitPrice
	FROM Products p LEFT OUTER JOIN Categories c
	ON p.CategoryID = c.CategoryID
	WHERE CategoryName IN ('Beverages', 'Condiments', 'Produce')
)AS CatergoryAvg
PIVOT
(
	AVG(UnitPrice)
	FOR CategoryName IN ([Beverages], [Condiments], [Produce])

)AS CatergoryAvgPivot;


SELECT  CategoryName, AVG(UnitPrice) [Avg Unit Price] 
FROM Products p LEFT OUTER JOIN Categories c
ON p.CategoryID = c.CategoryID
WHERE CategoryName IN ('Beverages', 'Condiments', 'Produce')
GROUP BY CategoryName;