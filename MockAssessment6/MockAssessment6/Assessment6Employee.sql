CREATE DATABASE StudentDB

CREATE TABLE Students(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(20) NOT NULL, 
    LastName NVARCHAR(20) NOT NULL,
    EMAIL NVARCHAR(30) NOT NULL,
    PHONE NVARCHAR(30) NOT NULL
)
SELECT * FROM Students

INSERT INTO Students (FirstName, LastName, EMAIL, PHONE)
VALUES ('Jane', 'Doe', 'jane@example.com', '313-55-0001'),
('James', 'Smith', 'james@example.com', '313-55-0002'),
('Susan', 'Jones', 'susan@example.com', '313-55-0003'),
('Javier', 'Rodriguez', 'javier@example.com', '313-55-0004'),
('DeAndre', 'Taylor', 'deandre@example.com', '313-55-0005')

Update Students 
Set LastName = 'Chirpus'
WHERE Id = 4;

DELETE  FROM Students
WHERE Id = 5;

SELECT * FROM Students 
WHERE FirstName Like 'James';

SELECT * FROM Students 
WHERE Id > 3 AND FirstName Like 'J%';

CREATE TABLE assignments(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Title NVARCHAR(40) NOT NULL, 
    Score TINYINT NOT NULL,
    StudentId INT FOREIGN KEY REFERENCES Students(Id) 
)
SELECT * FROM assignments

INSERT INTO assignments (StudentId, Title, Score)
VALUES ('1', 'Geography Quiz', '85'),
('1', 'US States Worksheet', '10'),
('4', 'Geography Quiz', '92');

SELECT * FROM assignments
Join Students on Students.ID = Students.Id



SELECT * FROM assignments, Students
WHERE Score > 90 
AND [Title] LIKE 'Geography Quiz%'
AND LastName IS NOT NULL 
AND FirstName IS NOT NULL;

SELECT * FROM Students, assignments 
WHERE LastName IS NOT NULL 
AND FirstName IS NOT NULL
and Score > 90;



