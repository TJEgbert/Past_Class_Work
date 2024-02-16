USE Student2550;

/* 1. Provide a list of distinct locations that have been used to teach sections of courses.  Arrange the list in order of location. (12 rows returned) */

SELECT DISTINCT
    Location
FROM
    Section
ORDER BY Location;

/* 2. List the phone number, full name (as one column) and employer for all students with a last name of "Torres". Sort by Employer (3 rows returned) */

SELECT 
    Phone AS 'Phone number',
    CONCAT(First_Name, ' ', Last_Name) AS 'Full Name',
    Employer
FROM
    Student
WHERE
    Last_Name = 'Torres'
ORDER BY Employer;

/* 3. List the course number and course description of all courses that have a prerequisite of course 350. Arrange in order of course number. (2 rows returned) */

SELECT 
    Course_No, Description
FROM
    Course
WHERE
    Prerequisite = 350
ORDER BY Course_No;

/* 4. List the course number, description and cost for all 200 level courses (200-299) costing less than $1100. Arrange by course number. Format and add a ‘$’ in front of the COST. (2 rows returned) */

SELECT 
    Course_No, Description, CONCAT('$', Cost) AS 'Cost'
FROM
    Course
WHERE
    Course_No BETWEEN 200 AND 299
        AND Cost < 1100
ORDER BY Course_No;

/* 5. List the course number, section id and location for all 100 level courses (100 through 199) that are taught in room L214 or L509. Order by location and course number. (26 rows returned) */

SELECT 
    Course_No, Section_Id, Location
FROM
    Section
WHERE
    Course_No BETWEEN 100 AND 199
        AND (Location = 'L214' OR Location = 'L509')
ORDER BY Location , Course_No;

/* 6. List the course number and section id for classes with a capacity of 12 or 15 (use the IN clause). Order the list by course number and section id. (28 rows returned) */

SELECT 
    Course_No, Section_Id
FROM
    Section
WHERE
    Capacity IN (12 , 15)
ORDER BY Course_No , Section_Id;

/* 7. List the student ID and GRADE for all of the midterm exam scores (MT) in section 141. Arrange the list by student ID and grade. (6 rows returned) */

SELECT 
    Student_Id, Numeric_Grade AS 'Grade'
FROM
    Grade
WHERE
    Grade_Type_Code = 'MT'
        AND Section_Id = 141
ORDER BY Student_Id , Numeric_Grade;

/* 8. List the course number and description for all 300 level courses that have a prerequisite, arranged on course description. (2 rows returned) */

SELECT 
    Course_No, Description
FROM
    Course
WHERE
    Course_No LIKE '3%'
        AND Prerequisite IS NOT NULL
ORDER BY Description;

/* 9. Provide an alphabetical list of the full name and phone number of all students that work for 'New York Culture' (the full name should be displayed as one column with an alias of 'Student Name') (4 rows returned) */

SELECT 
    CONCAT(First_Name, ' ', Last_Name) AS 'Student Name', Phone
FROM
    Student
WHERE
    Employer = 'New York Culture'
ORDER BY 'Student Name'; 

/* 10. Provide a list of student employers that are corporations (have "Co." in their name). List each employer only once and arrange the list alphabetical order. (5 rows returned) */

SELECT DISTINCT
    Employer
FROM
    Student
WHERE
    Employer LIKE '%CO.'
ORDER BY Employer;

/* 11. Provide an alphabetical list of students in area code 617. List student name in the format <last name (all upper case)>, <first initial>. ( Example, SMITH, J. ) followed by the phone number. (5 rows returned) */

SELECT 
    CONCAT(UCASE(Last_Name),
            ', ',
            LEFT(UCASE(First_Name), 1),
            '.'),
    Phone
FROM
    Student
WHERE
    Phone LIKE '617%'
ORDER BY Last_Name;

/* 12. List the name and address of all instructors without a zip code. (1 row returned) */

SELECT 
    CONCAT(First_Name, ' ', Last_Name) AS 'Name', Street_Address
FROM
    Instructor
WHERE
    ZIP IS NULL;

/* 13 Provide a list of zip codes for Jackson Heights, NY. Sort on zip. (3 rows returned) */

SELECT 
    Zip, City, State
FROM
    ZipCode
WHERE
    City = 'Jackson Heights'
        AND State = 'NY'
ORDER BY Zip;

/* 14. List the course number and location for all courses taught in a classroom that ends in the number 10. Arrange the list on location. (11 rows returned) */

SELECT 
    Course_No, Location
FROM
    Section
WHERE
    Location LIKE '%10'
ORDER BY Location;

/* 15. Provide a list containing full state name, state abbreviation and city from the zip code table for MA, OH, PR and WV. (You'll need to use the CASE expression). MA is Massachusetts, OH is Ohio, PR is Puerto Rico and WV is West Virginia. Sort by state. (8 rows returned) */

SELECT 
    CASE
        WHEN State = 'MA' THEN 'Massachusetts'
        WHEN State = 'OH' THEN 'Ohio'
        WHEN State = 'PR' THEN 'Puerto Rico'
        WHEN State = 'WV' THEN 'West Virginia'
    END AS 'Full State Name',
    State,
    City
FROM
    ZipCode
WHERE
    State IN ('MA' , 'OH', 'PR', 'WV')
ORDER BY State;

/* 16. Create a listing containing a single column address (salutation, first name, last name, address, zip) as 'Instructor Address' for each instructor in zip code 10015. Sort the list in alphabetical order. (3 rows returned) */

SELECT 
    CONCAT(Salutation,
            ', ',
            First_Name,
            ', ',
            Last_Name,
            ', ',
            Street_Address,
            ', ',
            Zip) AS 'Instructor Address'
FROM
    Instructor
WHERE
    Zip = 10015
ORDER BY Last_Name;

/* 17. List the student ID, final exam (FI) score and exam result ('PASS' or 'FAIL') for all students in section 156. A final score of 85 or higher is required to pass. Arrange the list by student ID. (8 rows returned) */

SELECT 
    Student_Id,
    Grade_Type_Code,
    Numeric_Grade,
    CASE
        WHEN Numeric_Grade >= 85 THEN 'PASS'
        ELSE 'FAIL'
    END AS 'Exam Results'
FROM
    Grade
WHERE
    Grade_Type_Code = 'FI'
        AND Section_Id = 156
ORDER BY Student_ID;

/* 18. List the first name, last name and phone number for all students that registered on 2/13/2007. Arrange the list in order of last name and first name. (29 rows returned) */

SELECT 
    First_Name, Last_Name, Phone, Registration_Date
FROM
    Student
WHERE
    Registration_Date = '2007-02-13'
ORDER BY Last_Name , FIrst_Name;

/* 19. List course number, section ID and start date for all sections located in L509. Arrange by start date (25 rows returned) */

SELECT 
    Course_No, Section_Id, Start_Date_Time
FROM
    Section
WHERE
    Location = 'L509'
ORDER BY Start_Date_Time;

/* 20. List the course number, section ID, start date, instructor ID and capacity for all Sections with a start date in July 2019. Arrange the list by start date and course number. (14 rows returned) */

SELECT 
    Course_No,
    Section_Id,
    Start_Date_Time,
    Instructor_ID,
    Capacity
FROM
    Section
WHERE
    Start_Date_Time LIKE '2019-07-%'
ORDER BY Start_Date_Time , Course_No;

    