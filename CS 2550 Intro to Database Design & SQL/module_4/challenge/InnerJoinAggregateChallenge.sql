USE Student2550;

/*  1. Create a query that returns the average cost for all courses. (Round to two places, and 
alias the column heading).
(1 Row)  */

SELECT 
    ROUND(AVG(Cost)) AS 'Average course cost'
FROM
    Course;

/*  2. Create a query that returns the total number of unique Students that registered during February 2007. Alias 
the column as "February 2007 Registrations".
(1 Row)  */

SELECT 
    COUNT(Registration_Date) AS 'February 2007 Registrations'
FROM
    Student;

/*  3. Create a query that returns the average, highest and lowest final exam scores for
Section 147. Display the average exam score with 2 decimal places.
(1 Row)  */

SELECT 
    FORMAT(AVG(Numeric_Grade), 2) AS 'Average Score',
    MAX(Numeric_Grade) AS 'Highest Score',
    MIN(Numeric_Grade) AS 'Lowest Score'
FROM
    Grade
WHERE
    Grade_Type_Code = 'FI'
        AND Section_ID = 147;

/*  4. List the city, state and “number of zip codes” (alias) for all cities with more than two
zip codes. Arrange by state and city.
(10 Rows)  */

SELECT 
    City, State, COUNT(Zip) AS 'number of zip codes'
FROM
    ZipCode
GROUP BY State , City
HAVING COUNT(Zip) > 2;


/*  5. Provide a list of Sections and the number of students enrolled in each section for
students who enrolled on 2/21/2019. Sort from highest to lowest on the number of
students enrolled.
(14 Rows)  */

SELECT 
    Section_Id,
    COUNT(Student_Id) AS 'Students Enrolled',
    Enroll_date
FROM
    Enrollment
WHERE
    enroll_date = '2019-02-21'
GROUP BY Section_Id;


/*  6. Create a query listing the student ID and Average Grade for all students in Section
86. Sort your list on the student ID and display all of the average grades with 2
decimal places.
(6 Rows)  */

SELECT 
    Student_Id, FORMAT(AVG(Numeric_Grade), 2) AS 'Average Grade'
FROM
    Grade
WHERE
    Section_Id = 86
GROUP BY Student_Id;


/*  7. Create a query to determine the number of sections in which student ID 250 is
enrolled. Your output should contain the student ID and the number of sections
(alias) enrolled.
(1 Row)  */

SELECT 
    Student_Id,
    COUNT(Section_ID) AS 'Number of sections enrolled'
FROM
    Enrollment
WHERE
    Student_Id = 250;

/*  8. List the section ID and lowest quiz score (GRADE_TYPE_CODE='QZ') for all sections
where the low score is greater than a B (greater than 80). Arrange by section id.
(16 rows)  */

SELECT 
    Section_Id, MIN(Numeric_Grade)
FROM
    Grade
WHERE
    Grade_Type_Code = 'QZ'
GROUP BY Section_ID
HAVING MIN(Numeric_Grade) > 80;

/*  9. List the names of Employers having more than 5 student employees. Your output
should contain the employer name and the number of student employees. Arrange
the output on the number of employees from lowest to highest.
(4 Rows)  */

SELECT 
    Employer, COUNT(Student_Id)
FROM
    Student
GROUP BY Employer
HAVING COUNT(Student_ID) > 5
ORDER BY COUNT(Student_Id) ASC;


/*  10. List the section ID, number of participation grades (GRADE_TYPE_CODE='PA') and
lowest participation grade for all sections with more than 15 participation grades.
Arrange by section id.
(6 Rows)  */

SELECT 
    Section_id,
    COUNT(Grade_Type_Code) AS 'Number of Participation grade',
    MIN(Numeric_Grade) AS 'Lowest Participation Grade'
FROM
    Grade
WHERE
    Grade_Type_Code = 'PA'
GROUP BY Section_Id
HAVING COUNT(Grade_Type_Code) > 15;


/*  11. List the first and last name and phone number for students that live in Newark, NJ.
Sort on last name and first name.
(3 Rows)  */

SELECT 
    First_Name, Last_Name, Phone
FROM
    Student AS s
        JOIN
    ZipCode AS zc ON zc.Zip = s.Zip
WHERE
    City = 'Newark' AND State = 'NJ'
ORDER BY Last_Name , First_Name;

/*  12. For all 300 level courses (300-399), list the course number, prerequisite course
number and prerequisite course description. Sort by course number.
(2 Rows)  */

SELECT 
    c1.Course_No, c1.Prerequisite, c2.Description
FROM
    Course AS c1
        JOIN
    Course AS c2 ON c2.Course_No = c1.Prerequisite
WHERE
    c1.Prerequisite IS NOT NULL
        AND c1.Course_No BETWEEN 300 AND 399
GROUP BY c1.Course_No
ORDER BY c1.Course_No;

/*  13. List the course number and description for all 100-level courses taught by Charles
Lowry. Arrange the list in order of course number.
(6 rows)  */

SELECT 
    c.Course_No, c.Description
FROM
    Course AS c
        JOIN
    Section AS S ON s.Course_No = c.Course_No
        JOIN
    Instructor AS i ON i.Instructor_ID = s.Instructor_ID
WHERE
    c.Course_no BETWEEN 100 AND 199
        AND i.First_Name = 'Charles'
        AND i.Last_Name = 'Lowry'
GROUP BY c.Course_No
ORDER BY c.Course_No;  

/*  14. List the grade type code, grade type description and number of grades for each grade type in all sections of course
144. Arrange by description.
(5 Rows)  */

SELECT 
    gra.grade_type_code, Description, COUNT(Numeric_grade)
FROM
    Section AS Sec
        JOIN
    Grade AS Gra ON gra.section_id = sec.course_no
        JOIN
    Grade_type AS gty ON gty.Grade_type_Code = gra.Grade_type_Code
WHERE
    sec.Section_id = 144
GROUP BY gra.grade_type_code
ORDER BY Description;


/*  15. Provide an alphabetic list of students (by the Students’ Full Name – with last name
first) who have an overall grade average of 93 or higher. The results should be
sorted on Students’ Full name (showing last name first).
(3 Rows)  */

SELECT 
    CONCAT(Last_Name, ', ', First_Name) AS 'Full Name',
    AVG(Numeric_Grade) AS 'Grade Average'
FROM
    Student AS s
        JOIN
    Grade AS g ON g.Student_Id = s.Student_Id
GROUP BY s.Student_Id
HAVING AVG(Numeric_Grade) >= 93
ORDER BY 'Full Name';

/*  16. List the names and address (including city and state) for all faculty who have taught
less than 10 course sections.
(2 Rows)  */

SELECT 
    CONCAT(ins.First_Name, ' ', ins.Last_Name) AS Name,
    CONCAT(ins.Street_Address,
            ' ',
            City,
            ' ',
            State,
            '',
            ins.Zip) AS 'Adress'
FROM
    Instructor AS ins
        JOIN
    Section AS sec ON sec.Instructor_Id = ins.Instructor_Id
        JOIN
    ZipCode AS zi ON zi.Zip = ins.Zip
GROUP BY ins.instructor_Id
HAVING COUNT(section_no) < 10;


/*  17. List the course number and number of students enrolled in courses that do not have
a prerequisite. Sort the list by number of students enrolled from highest to lowest.
(4 Rows)  */

SELECT 
    sec.Course_No, COUNT(Student_Id) AS 'Enrolled Students'
FROM
    Enrollment AS enr
        JOIN
    Section AS sec ON sec.Section_Id = enr.Section_Id
        JOIN
    Course AS cou ON cou.Course_no = sec.Course_no
WHERE
    Prerequisite IS NULL
GROUP BY sec.Course_No
ORDER BY COUNT(Student_Id) ASC;

/*  18. Provide an alphabetic list of students (first and last names) their enrollment date(s),
and count of their enrollment(s) for that date, who are from Flushing, NY and who
enrolled prior to February 7, 2019.
(2 Rows)  */

SELECT 
    CONCAT(First_name, ' ', Last_Name) AS 'Name',
    Enroll_Date,
    COUNT(Enroll_Date)
FROM
    Enrollment AS enr
        JOIN
    Student AS stu ON stu.Student_Id = enr.Student_Id
        JOIN
    ZipCode AS zi ON zi.Zip = stu.Zip
WHERE
    City = 'Flushing' AND State = 'NY'
        AND Enroll_Date < '2019-02-07'
GROUP BY enr.Student_Id
ORDER BY Last_Name;


/*  19. Provide a listing of course numbers, descriptions, and formatted (with $) costs, that
include projects (Grade_type_code = 'PJ') as a part of their grading criteria.
(9 rows)  */

SELECT 
    cou.Course_No,
    Description,
    CONCAT('$ ', FORMAT(Cost, 2)) AS 'Cost'
FROM
    Course AS cou
        JOIN
    Section AS sec ON sec.Course_No = cou.Course_No
        JOIN
    Grade_Type_Weight AS gra ON gra.Section_Id = sec.Section_Id
WHERE
    Grade_Type_Code = 'PJ'
GROUP BY cou.Course_No;


/*  20. List the highest grade on the final exam (Grade_type_code = 'FI') that was given to a
student in course 145.
(1 Row)  */

SELECT 
    MAX(Numeric_Grade)
FROM
    Grade AS gra
        JOIN
    Section AS sec ON sec.Section_Id = gra.Section_Id
WHERE
    Grade_Type_Code = 'FI'
        AND Course_No = 145;
