CREATE PROCEDURE [dbo].[GetAllTStudent]
  
AS
BEGIN
    SELECT *
    FROM Students
   
END


CREATE PROCEDURE [dbo].[AddStudent]
    @studentID int,
    @name nvarchar(50),
    @email nvarchar(100)
AS
BEGIN
    INSERT INTO Students (studentID, name, email, Created, CreatedBy, LastModified, LastModifiedBy)
    VALUES (
        @studentID,
        @name,
        @email,
        GETDATE(),
        'System',
        GETDATE(),
        'System'
    )
END
CREATE PROCEDURE [dbo].[UpdateStudent]
	@Id int,
    @studentId int,
    @name nvarchar(50),
    @email nvarchar(100)
AS
BEGIN
    UPDATE Students 
    SET 
		studentID = @studentId,
        name = @name,
        email = @email,
        LastModified = GETDATE(),
        LastModifiedBy = 'System'
    WHERE 
        Id = @Id
END
CREATE PROCEDURE [dbo].[DeleteStudent]
    @Id int
AS
BEGIN
    DELETE FROM Students
    WHERE Id = @Id
END
