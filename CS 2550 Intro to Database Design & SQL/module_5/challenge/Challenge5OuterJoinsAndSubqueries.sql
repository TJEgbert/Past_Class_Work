/*USE the 2550HR Database and write a single SQL script (with commenting) to answer the following 16 questions. */
USE 2550HR;

#1A. Display the first name, last name, department number and department name, for all employees including those without any department. (107 rows)

SELECT # Gets the first_name, last_name, deparment_id from the employees table, department_name
    first_name, last_name, e.department_id, department_name 
FROM
    employees e
        LEFT JOIN # employees table and the departments table through the department_id
    departments d ON d.department_id = e.department_id;

#1B. With one simple change, modify your query to display all departments including departments without any employees. (122 Rows)

SELECT # Gets the first_name, last_name, deparment_id from the employees table, department_name
    first_name, last_name, e.department_id, department_name
FROM
    employees e
        RIGHT JOIN # employees table and the departments table through the department_id
    departments d ON d.department_id = e.department_id;

#2A. For each employee, display the last name, and the manager’s last name. (106 Rows)

SELECT # last_name of the employees and the last_name for the managers
    e.last_name, m.last_name 
FROM
    employees e
        JOIN # A self join on the employees table on e.manager_id to m.employee_id to get the managers last_name from the e.manager_id
    employees m ON m.employee_id = e.manager_id;

#2B. With one simple change, modify your query to display all employees including those without any manager. (107 Rows)

SELECT # Selects the last_name of the employees and the last_name for the managers
    e.last_name Employee, m.last_name Manager 
FROM
    employees e
        LEFT JOIN # on employees table on e.manager_id to m.employee_id to get the managers last_name from the e.manager_id
    employees m ON m.employee_id = e.manager_id;

#3. Display the first name, last name, and department number for all employees who work in the same department as employee whose last name is "King".(37 Rows)

SELECT # first_name, last_name, department_id from the employees table that has the same depart_id as 'King'
    e.first_name, e.last_name, e.department_id 
FROM
    employees e
        LEFT JOIN # the employee table to itself on the department_id
    employees k ON k.department_id = e.department_id
WHERE # checks to see what department_id that the last_name king is associated with  
    k.last_name = 'King';

#4. Display the last name and salary for all employees who earn less than employee number 103. (80 Rows) 

SELECT # last_name, salary from the employees table
    last_name, salary 
FROM
    employees
WHERE # Checks to see if the salary is less then the subquery of the salary of employee_id 103 
    salary < (SELECT 
            salary
        FROM
            employees
        WHERE
            employee_id = 103);
            
#5. Display the first name and salary for all employees who earn more than employee number 103. MUST USE SUBQUERY. (23 Rows)

SELECT # last_name, salary from the employees table
    last_name, salary
FROM
    employees
WHERE # Checks to see if the salary is more then the subquery of the salary of employee_id 103 
    salary > (SELECT 
            salary
        FROM
            employees
        WHERE
            employee_id = 103);

#6. Display the department id and department name for all departments whose location id is equal to the location id where the department id = 90. MUST USE SUBQUERY. (21 Rows)

SELECT # department_id and the department_name from departments
    department_id, department_name
FROM
    departments
WHERE # checks to see if the location_id is the same as the subquery location_id of department_id 90
    location_id = (SELECT 
            location_id
        FROM
            departments
        WHERE
            department_id = 90);

#7. Display the last name and hire date for all employees who was hired after employee number 101. MUST USE SUBQUERY. (104 Rows)

SELECT # last_name, hire_date from the employees table
    last_name, hire_date
FROM
    employees
WHERE # checks to see if the hire_date is after the subquery checking the hire_date of employee number 101.
    hire_date > (SELECT 
            hire_date
        FROM
            employees
        WHERE
            employee_id = 101);

#8. Display the first name, last name, and department number for all employees who work in Sales department. MUST USE SUBQUERY. (34 Rows)

SELECT # first_name, last_name, department_id from the employee table
    first_name, last_name, e.department_id
FROM
    employees e
WHERE # Checks to see if the e.department_id is the same as the subquery checking to see what department_id is associated with department_name 'Sales' 
    e.department_id = (SELECT 
            department_id
        FROM
            departments
        WHERE
            department_name = 'Sales');

#9. Display the department number and department name for all departments located in Toronto. MUST USE SUBQUERY. (1 Row)

SELECT # department_id and department_name from the departments table
    department_id, department_name
FROM
    departments d
WHERE # checks to see location_id is the same as the subquery checking to see what location_id is associated with the city of Toronot
    d.location_id = (SELECT 
            l.location_id
        FROM
            locations l
        WHERE
            city = 'Toronto');

#10. Display the first name, salary and department number for all employees who work in the department as employee number 123. Do not count employee 123 in the results.  MUST USE SUBQUERY. (44 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # Checks to see if the department_id is the same as the subquery checking to see what department employee nuymber 123 works.  Then it also excludes that employee from the results.
    department_id = (SELECT 
            department_id
        FROM
            employees
        WHERE
            employee_id = 123)
        && (employee_id != 123);

#11. Display the first name, salary, and department number for all employees who earn more than the average salary. MUST USE SUBQUERY. (51 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # checks to see if the salary is greater than subquery getting the AVG salary from the employees table
    salary > (SELECT 
            AVG(salary)
        FROM
            employees);

#12. Display the first name, salary, and department number for all employees whose salary equals one of the salaries in department number 10. MUST USE SUBQUERY. (1 Row)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # checks to see if the salary is the same the subquery checking the salary as one of the employees from department 10
    salary = (SELECT 
            salary
        FROM
            employees
        WHERE
            department_id = 10);

#13. Display the first name, salary, and department number for all employees who earn more than maximum salary in department number 50. MUST USE SUBQUERY. (31 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # checks to see if the salary is greater then the subquery checking the MAX salary of department 50.
    salary > (SELECT 
            MAX(salary)
        FROM
            employees
        WHERE
            department_id = 50);

#14. Display the first name, salary, and department number for all employees who earn more than the minimum salary in department number 10. MUST USE SUBQUERY. (60 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # checks to see if the salary is greater then the subquery checking the MIN salary of department 10.
    salary > (SELECT 
            MIN(salary)
        FROM
            employees
        WHERE
            department_id = 10);

#15. Display the first name, salary, and department number for all employees who earn less than the minimum salary of department number 90. MUST USE SUBQUERY. (104 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, department_id
FROM
    employees
WHERE # checks to see if the salary is less then the subquery checking the MIN salary of department 90.
    salary < (SELECT 
            MIN(salary)
        FROM
            employees
        WHERE
            department_id = 90);

#16. Display the first name, salary and department number for all employees whose department is located in Seattle. MUST USE SUBQUERY. (18 Rows)

SELECT # first_name, salary, and department_id from the employees table
    first_name, salary, e.department_id
FROM
    employees e
        JOIN # inner join the departments table and employees table ON deparment_id
    departments d ON d.department_id = e.department_id
WHERE # checks to see if the d.location_id is the same as the subquery checking the location_id for the city of Seattle
    d.location_id = (SELECT 
            location_id
        FROM
            locations
        WHERE
            city = 'Seattle');

/*CONTINUE: USE the 2550ACDB Database and Queries to answer the last 4 questions. */
USE 2550ACDB;
#17A. Display the first name, last name, internet speed and monthly payment for all customers. Use INNER JOIN to solve this exercise. (1045 Rows)

SELECT # first_name and last_name from the customer table. Then speed and monthly_payments from the packages table
    first_name, last_name, speed, monthly_payment
FROM
    customers c
        JOIN # An INNER JOIN On pack_id
    packages p ON p.pack_id = c.pack_id;

#17B. With one simple change, Modify last query to display all customers, including those without any internet package. (1223 Rows)

SELECT # first_name and last_name from the customer table. Then speed and monthly_payments from the packages table
    first_name, last_name, speed, monthly_payment
FROM
    customers c
       LEFT JOIN # on pack pack_id
    packages p ON p.pack_id = c.pack_id;

#17C. With one simple change, Modify last query to display all packages, including those without any customers. (1075 Rows)

SELECT # first_name and last_name from the customer table. Then speed and monthly_payments from the packages table
    first_name, last_name, speed, monthly_payment
FROM
    customers c
       RIGHT JOIN # on pack pack_id
    packages p ON p.pack_id = c.pack_id;

#18. Display the first name, monthly discount and package number for all customers whose monthly payment is greater than the average monthly payment MUST USE SUBQUERY (953 Rows)

SELECT # first_name, monthly_discount and pack_id from the customer table.  Then SELECTS monthly_payment from packages table
    first_name, monthly_discount, c.pack_id, monthly_payment
FROM
    customers c
        JOIN # INNER JOIN on pack pack_id
    packages p ON p.pack_id = c.pack_id
WHERE # checks the monthly_payment is greater then the subquery of AVG monthly_payments
    monthly_payment > (SELECT 
            AVG(monthly_payment)
        FROM
            packages);

/*19. Display the first name, city, state, birthdate and monthly discount for all customers who was born on the same date as customer number 179, and whose monthly discount is greater than the monthly 
discount of customer number 107. MUST USE SUBQUERY. (3 Rows)*/

SELECT # first_name, city, state, birth_datem monthly_discount from the customers table
    first_name, City, State, birth_date, monthly_discount
FROM
    customers
WHERE # birth_date is the same as the subquery checking the customer number 179 birth_date and the monthly_discount is greater than the subquery checking the monthly discount of customer number 107.
    (birth_date = (SELECT 
            birth_date
        FROM
            customers
        WHERE
            customer_id = 179))
        && (monthly_discount > (SELECT 
            monthly_discount
        FROM
            customers
        WHERE
            customer_id = 107));


#20. Display the first name, monthly discount, package number, main phone number and secondary phone number for all customers whose sector name is Business. MUST USE SUBQUERY. (515 Rows)

SELECT # first_name, monthly_discount, pack_id, main_phone_num, secondary_phone_num from the customers table
    first_name,
    monthly_discount,
    c.pack_id,
    main_phone_num,
    secondary_phone_num
FROM
    customers c
        JOIN # INNER JOIN the package table and the customer talbe on pack_id
    packages p ON p.pack_id = c.pack_id
WHERE # sector_id is the same as subquery checking the sector_id of the sector_name Bussiness
    sector_id = (SELECT 
            sector_id
        FROM
            sectors
        WHERE
            sector_name = 'Business');

