--CREATE Database [A4_Trevor_egbert_Q2];
USE [A4_Trevor_egbert_Q2]

GO

DROP TABLE Student;

CREATE TABLE Student(
	Student_ID int NOT NULL
	CONSTRAINT student_PK PRIMARY KEY (Student_ID),
	CONSTRAINT unique_student_id UNIQUE(Student_ID),
	Email VARCHAR(250)
	CONSTRAINT unqiue_email UNIQUE(Email),
	Fname VARCHAR(250) NOT NULL,
	Lname VARCHAR(250) NOT NULL,
	Dept_no VARCHAR(4)
	CHECK(Dept_no IN('CS', 'EE', 'PH', 'LIT', 'ENG', 'MATH'))
);

DROP TABLE Assignment;

CREATE TABLE Assignment(
	Assignment_ID  int NOT NULL
	CONSTRAINT assignment_PK PRIMARY KEY (Assignment_ID),
	CONSTRAINT unique_assignment_id UNIQUE(Assignment_ID),
	Assignment_Name VARCHAR(250) NOT NULL DEFAULT 'CS 3550 Assignment', 
	Assignment_Description VARCHAR(500),
	Due_Date DATETIME NOT NULL,
	Max_Possible_Grade int
	CHECK(Max_Possible_Grade BETWEEN 0 AND 200),
	Submission_type VARCHAR(15)
	CHECK(Submission_type IN('Text Entry', 'Media Recording', 'File Upload', 'Website URL'))
	);

	DROP TABLE StudentAssignment;

	CREATE TABLE StudentAssignment(
	SubMission_date  DATETIME NOT NULL,
	Grade int,
	CHECK(Grade BETWEEN 0 AND 200),
	Student_ID INT,
	Assignment_ID INT,
	CONSTRAINT StudentAssignment_PK PRIMARY KEY(Student_ID, Assignment_ID),
	CONSTRAINT foreignkey_1 FOREIGN KEY(Student_ID) REFERENCES Student(Student_ID),
	CONSTRAINT foreignkey_2 FOREIGN KEY(Assignment_ID) REFERENCES Assignment(Assignment_ID)
	ON DELETE CASCADE
    ON UPDATE CASCADE
	);

GO
