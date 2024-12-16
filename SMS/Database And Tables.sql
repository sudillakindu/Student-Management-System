-- Create the database
CREATE DATABASE StudentManagementSystem;

-- Use the database
USE StudentManagementSystem;

-- Create tables
-- 01. Creating a Course Table
CREATE TABLE Course (
    CourseID                     CHAR(5)        PRIMARY KEY CHECK (CourseID LIKE 'C%'),
    CourseName                   VARCHAR(60)    NOT NULL,
    Credit                       INT            NOT NULL CHECK (Credit > 0),
    CourseDescription            VARCHAR(100),
    CoursePrice                  DECIMAL(10, 2) NOT NULL CHECK (CoursePrice >= 0)
);

-- 02. Creating a Instructor Table
CREATE TABLE Instructor (
    InstructorID                 CHAR(5)        PRIMARY KEY CHECK (InstructorID LIKE 'I%'),
    Name                         VARCHAR(30)    NOT NULL,
    NIC                          VARCHAR(12)    UNIQUE,
    Email                        VARCHAR(40)    NOT NULL CHECK (Email LIKE '%@%'),
    PhoneNumber                  VARCHAR(10)    NOT NULL CHECK (PhoneNumber LIKE '[0-9]%'),
    Expertise                    VARCHAR(250)   NOT NULL,
    Gender                       VARCHAR(6)     NOT NULL CHECK (Gender IN ('Male', 'Female')),
    Salary                       DECIMAL(10,2)  NOT NULL CHECK (Salary > 0)
);

-- 03. Creating a Student Table
CREATE TABLE Student (
    StudentID                    CHAR(5)        PRIMARY KEY CHECK (StudentID LIKE 'S%'),
    Name                         VARCHAR(30)    NOT NULL,
    DOB                          DATE           NOT NULL,
    Age                          INT            NOT NULL,
    NIC                          VARCHAR(12)    UNIQUE,
    Email                        VARCHAR(40)    NOT NULL CHECK (Email LIKE '%@%'),
    PhoneNumber                  VARCHAR(10)    NOT NULL CHECK (PhoneNumber LIKE '[0-9]%'),
    Address                      VARCHAR(80)    NOT NULL,
    RegisterDate                 DATETIME       DEFAULT GETDATE(),
    Gender                       VARCHAR(6)     NOT NULL CHECK (Gender IN ('Male', 'Female')),
    Status                       VARCHAR(9)     NOT NULL CHECK (Status IN ('Active', 'Completed', 'Dropped')),
	StudentPicture               VARBINARY(MAX) NULL
);

-- 04. Creating a EnrollmentStudent Table
CREATE TABLE EnrollmentStudent (
    EnrollmentID                CHAR(5)        PRIMARY KEY CHECK (EnrollmentID LIKE 'E%'),
    StudentID                   CHAR(5)        NOT NULL,
    CourseID                    CHAR(5)        NOT NULL,
	InstructorID				CHAR(5)        NOT NULL,
    StartDate                   DATE           NOT NULL,
    Duration                    VARCHAR(7)	   NOT NULL CHECK (Duration IN ('1 Month', '2 Month', '3 Month', '6 Month', '9 Month', '1 Year', '2 Year', '3 Year', '4 Year')),
	EnrollmentDate              DATETIME       DEFAULT GETDATE()
	FOREIGN KEY (StudentID)     REFERENCES Student (StudentID),	
	FOREIGN KEY (CourseID)      REFERENCES Course (CourseID),
	FOREIGN KEY (InstructorID)  REFERENCES Instructor (InstructorID)
);

-- 05. Creating a FeeManagement Table
CREATE TABLE FeeManagement (
    EnrollmentID				CHAR(5)			UNIQUE NOT NULL,
    FeeID						CHAR(5)			PRIMARY KEY NOT NULL,
    StudentID					CHAR(5)			NOT NULL,
    StudentName					VARCHAR(30)		NOT NULL,
    CourseID					CHAR(5)			NOT NULL,
	CourseName					VARCHAR(60)		NOT NULL,
    PaymentDate					DATE			NOT NULL,
    TotalFee					DECIMAL(10,2)	NOT NULL,
    Status						VARCHAR(9)		CHECK (Status IN ('Pending', 'Partial', 'Paid', 'Cancelled')),
    AmountPaid					DECIMAL(10,2),
    RemBalance					DECIMAL(10,2),
    Note						VARCHAR(250),
	FOREIGN KEY (EnrollmentID)  REFERENCES EnrollmentStudent (EnrollmentID),	
	FOREIGN KEY (StudentID)     REFERENCES Student (StudentID),	
	FOREIGN KEY (CourseID)      REFERENCES Course (CourseID)
);

-- 06. Creating a FeeManagement Table
CREATE TABLE Attendance (			
    StudentID					CHAR(5)			NOT NULL,
    StudentName					VARCHAR(30)		NOT NULL,
    AttendanceDate				DATE			NOT NULL,
    AbsentOrPresent				VARCHAR(7)		CHECK (AbsentOrPresent IN ('Absent', 'Present')),	
	PRIMARY KEY (StudentID, AttendanceDate),
	FOREIGN KEY (StudentID)     REFERENCES Student (StudentID)	
);

