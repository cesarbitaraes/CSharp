CREATE OR ALTER PROCEDURE [spListCourse] 
    @Category NVARCHAR(60) --Parâmetro para uma procedure
AS
    DECLARE @CategoryId INT
    SET @CategoryId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = @Category)
    SELECT * FROM [Curso] WHERE [CategoriaId] = @CategoryId

DROP PROCEDURE [spListCourse]

EXEC [spListCourse] 'Backend'