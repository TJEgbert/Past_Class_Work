USE 2550Sales;

SELECT 
    firstName, lastName, CustomerName
FROM
    employees
        LEFT JOIN
    customers ON employees.employeeNumber = customers.salesRepEmployeeNumber;
    
    SELECT 
    firstName, lastName, CustomerName
FROM
    employees
        Right JOIN
    customers ON employees.employeeNumber = customers.salesRepEmployeeNumber;
    
    
SELECT 
    firstName, lastName, COUNT(CustomerName)
FROM
    employees
        LEFT JOIN
    customers ON employees.employeeNumber = customers.salesRepEmployeeNumber
GROUP BY FirstName
HAVING COUNT(customerName) = 0;

SELECT 
    firstName, lastName
FROM
    employees
        LEFT JOIN
    customers ON employees.employeeNumber = customers.salesRepEmployeeNumber
WHERE
    customerName IS NULL
GROUP BY FirstName;




SELECT 
    CustomerName, amount
FROM
    customers c
        RIGHT JOIN
    payments p ON p.customerNumber = c.customerNumber; 




SELECT 
    CustomerName, SUM(amount) AS 'Total Payments'
FROM
    customers c
        LEFT JOIN
    payments p ON p.customerNumber = c.customerNumber
GROUP BY CustomerName; 




SELECT 
    CustomerName, SUM(amount) AS 'Total Payments'
FROM
    customers c
        LEFT JOIN
    payments p ON p.customerNumber = c.customerNumber
WHERE
    amount IS NOT NULL
GROUP BY CustomerName;


SELECT *
FROM productlines pl
CROSS JOIN products p;




SELECT 
    l.productLine, TextDescription, ProductName
FROM
    productLines l
        CROSS JOIN
    Products p;


SELECT 
    p.productLine, TextDescription, ProductName
FROM
    productLines l
        CROSS JOIN
    Products p;
    
    
    
SELECT 
    e.lastName, c.contactLastName
FROM
    Customers c
        CROSS JOIN
    employees e;
    
    
SELECT 
    CONCAT(m.LastName, ', ', m.firstName) AS Manager,
    CONCAT(e.lastName, ', ', e.firstName) AS Employee
FROM
    Employees e
        LEFT JOIN
    employees m ON m.employeeNumber = e.reportsTo;


SELECT 
    CONCAT(m.LastName, ', ', m.firstName) AS Manager,
    COUNT(e.employeeNumber) AS EmployeeCount
FROM
    Employees e
        INNER JOIN
    employees m ON m.employeeNumber = e.reportsTo
GROUP BY m.employeeNumber;

SELECT 
    AVG(BuyPrice)
FROM
    Products;


SELECT 
    productCode, priceEach
FROM
    OrderDetails
WHERE
    priceEach < (SELECT 
            AVG(BuyPrice)
        FROM
            Products);
            
            
SELECT CustomerNumber
FROM orders
WHERE status = 'On Hold';



SELECT 
    CustomerName,
    ContactLastName,
    contactFirstName
FROM
    customers
WHERE
    customerNumber IN (SELECT 
            CustomerNumber
        FROM
            orders
        WHERE
            status = 'On Hold');
            
            
SELECT DISTINCT
    CustomerName,
    (SELECT 
            MAX(orderDate)
        FROM
            orders o
        WHERE
            o.customerNumber = c.Customernumber) AS MostRecientPurchase
FROM
    Customers c
    ORDER BY c.CustomerNumber;
    
SELECT DISTINCT
    CustomerName, MAX(orderDate)
FROM
    Customers c
        LEFT JOIN
    orders o ON o.customerNumber = c.customerNumber
GROUP BY c.customerNumber
ORDER BY c.customerNumber;