-- Get Courses by StudentId Procedure
CREATE PROCEDURE spGetCoursesByStudentId
 @StudentID INT
AS
BEGIN
 SELECT c.CourseId, c.CourseName, c.TeacherId
    FROM Student s LEFT OUTER JOIN StudentCourse sc on sc.StudentId = s.StudentId 
 LEFT OUTER JOIN Course c on c.CourseId = sc.CourseId
    WHERE s.StudentId = @StudentId
END
GO

-- Insert Student stored Procedure
CREATE PROCEDURE spInsertStudent
 @StandardId INT,
 @FirstName VARCHAR(100),
 @LastName VARCHAR(100)
AS
BEGIN
     INSERT INTO Student(FirstName ,LastName, StandardId)
     VALUES(@FirstName, @LastName, @StandardId);
     SELECT SCOPE_IDENTITY() AS StudentId
END
GO

-- Update Student stored Procedure
CREATE PROCEDURE spUpdateStudent
 @StudentId INT,
 @StandardId INT,
 @FirstName VARCHAR(100),
 @LastName VARCHAR(100)
AS
BEGIN
    UPDATE Student
 SET FirstName = @FirstName,
     LastName = @LastName,
     StandardId = @StandardId
 WHERE StudentId = @StudentId;

END
GO

-- Delete Student stored Procedure
CREATE PROCEDURE spDeleteStudent
 @StudentId int
AS
BEGIN
    DELETE FROM Student
 WHERE StudentId = @StudentId
END
GO

-- Student Course View
CREATE VIEW vwStudentCourse
AS
 SELECT s.StudentId, 
   s.FirstName, 
   s.LastName,
   sc.CourseId, 
   c.CourseName
 FROM    Student s INNER JOIN StudentCourse sc
 ON  s.StudentId = sc.StudentId 
 INNER JOIN Course c ON sc.CourseId = c.CourseId
GO