USE master
GO

DROP DATABASE IF EXISTS StuManagement
CREATE DATABASE StuManagement
GO

USE StuManagement
GO

DROP TABLE  IF EXISTS Student
CREATE TABLE Student(
	stuId INT PRIMARY KEY IDENTITY,
	stuPass BIT,
	stuName NVARCHAR(50),
	stuAddress NVARCHAR (50),
	stuPhone INT,
	stuEmail NVARCHAR (50),
	depId NVARCHAR (50)
)
GO

INSERT INTO Student(stuPass,stuName,stuAddress,stuPhone,stuEmail,depId) 
	VALUES (1,'Namle','220/20',098822828,'aaaa@gmail.com','toan')
GO 

create proc AddStudent
@stuPass bit, @stuName NVARCHAR(50), @stuAddress NVARCHAR(50), @stuPhone NVARCHAR(50),@stuEmail NVARCHAR(50),@depId NVARCHAR(50)
as
begin
	INSERT INTO Student (stuPass,stuName,stuAddress,stuPhone,stuEmail,depId)
	VALUES (@stuPass,@stuName,@stuAddress,@stuPhone,@stuEmail,@depId);	
end
go

create proc UpdateStudent
@stuPass bit, @stuName NVARCHAR(50), @stuAddress NVARCHAR(50), @stuPhone NVARCHAR(50),@stuEmail NVARCHAR(50),@depId NVARCHAR(50), @stuId int as
begin
	update Student
	set stuPass=@stuPass, stuName=@stuName, stuAddress=@stuAddress, stuPhone=@stuPhone, stuEmail=@stuEmail, depId=@depId
	where stuId=@stuId
end
go

create proc DelStudent
@Id int
as
begin
	delete Student where stuId=@id	
end
go
Drop TABLE Exam
CREATE TABLE Exam(
	examId INT PRIMARY KEY IDENTITY,
	examName NVARCHAR(50),
	examMark float,
	examDate Date,
	stuId INT,
	couId INT
)
GO

create proc AddExam
@examName NVARCHAR(50), @examMark NVARCHAR(50), @examDate date,@stuId INT,@couId INT
as
begin
	INSERT INTO Exam (examName,examMark,examDate,stuId,couId)
	VALUES (@examName,@examMark,@examDate,@stuId,@couId);	
end
go

create proc UpdateExam
@examName NVARCHAR(50), @examMark NVARCHAR(50), @examDate date,@stuId INT,@couId INT
, @examId int as
begin
	update Exam
	set examName=@examName, examMark=@examMark, examDate=@examDate, stuId=@stuId, couId=@couId
	where examId = @examId
end
go

create proc DelExam
@id int
as
begin
	delete Exam where examId=@id	
end
go

CREATE TABLE Course(
	couId INT PRIMARY KEY IDENTITY,
	couName NVARCHAR(50),
	couSemester int
)
GO

create proc AddCourse
@couName NVARCHAR(50),@couSemester int
as
begin
	INSERT INTO Course(couName,couSemester)
	VALUES (@couName,@couSemester);	
end
go
create proc UpdateCourse
@couName NVARCHAR(50),@couSemester int, @couId int
 as
begin
	update Course
	set couName=@couName, couSemester = @couSemester
	where couId=@couId
end
go

create proc DelCourse
@id int
as
begin
	delete Course where couId=@id	
end
go

---------------------
drop proc highestMark
create proc highestMark
as
@examMark int
begin
	SELECT MAX(@examMark)
FROM Exam
end
go