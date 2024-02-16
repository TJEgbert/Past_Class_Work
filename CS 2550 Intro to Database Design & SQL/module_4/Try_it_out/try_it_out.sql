use 2550sales;

SELECT CustomerNUmber, amount
FROM Payments;

SELECT CustomerNUmber, AVG(amount)
FROM Payments
GROUP BY customerNumber;

SELECT CustomerNUmber, SUM(amount)
FROM Payments
GROUP BY customerNumber;

Select ROUNd(3.141926, 3) as PI;

SELECT ROUND(AVG(buyPrice), 2)
FROM Products
GROUP BY ProductVendor;

SELECT ROUND(MAX(buyPrice), 2)
FROM Products
GROUP BY ProductVendor;

SELECT ProductName, MIN(MSRP)
FROM Products;

SELECT ProductVendor, COUNT(productName) AS 'Number of Products'
FROM Products
GROUP BY ProductVendor;

SELECT customerNumber, COUNT(amount)
FROM payments
GROUP BY customerNumber;

SELECT customerNumber, COUNT(amount)
FROM payments
GROUP BY customerNumber
HAVING COUNT(Amount) > 5;

SELECT customerNumber, AVG(amount)
FROM payments
GROUP BY customerNumber
HAVING AVG(Amount) > 50000;

SELECT State, COUNT(state) AS 'Num Customers'
FROM Customers
GROUP BY State
HAVING COUNT(State) > 1;


SELECT CustomerName, Amount
FROM customers
INNER JOIN
Payments on Customers.customerNumber = Payments.customerNumber;

SELECT CustomerName, COUNT(Amount)
FROM customers
INNER JOIN
Payments on Customers.customerNumber = Payments.customerNumber
GROUP BY CustomerName;

SELECT productName, productLine, priceEach
FROM Products
INNER JOIN
Orderdetails on Products.productCode = Orderdetails.productCode;


SELECT productName, productLine, AVG(priceEach) AS 'Average Cost'
FROM Products
INNER JOIN
Orderdetails on Products.productCode = Orderdetails.productCode
GROUP BY productName;

SELECT productName, productLine, AVG(priceEach) AS 'Average Cost'
FROM Products
INNER JOIN
Orderdetails on Products.productCode = Orderdetails.productCode
GROUP BY productName
HAVING AVG(priceEach) < 100;