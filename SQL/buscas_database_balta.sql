--Count com subselect:
SELECT
    [Id],
    [Title],
    [Url],
    (SELECT COUNT([CareerId]) FROM [CareerItem] WHERE [CareerId] = [Id]) AS [Courses]
FROM
    [Career]

SELECT NEWID()

SELECT * FROM [Course]
SELECT * FROM [Student]
SELECT * FROM [StudentCourse]

INSERT INTO
    [Student]
VALUES (
    'c3d924e1-dc58-41e2-8329-f76ed355dcf9',
    'Andre Baltieri',
    'hello@balta.io',
    '12345678901',
    '12345678',
    NULL,
    GETDATE()
)

INSERT INTO
    [StudentCourse]
VALUES (
    '5f5a33f8-4ff3-7e10-cc6e-3fa000000000',
    'c3d924e1-dc58-41e2-8329-f76ed355dcf9',
    50,
    0,
    '2020-01-13 12:35:54',
    GETDATE()
)

SELECT
    [Student].[Name] AS [Student],
    [Course].[Title] AS [Course],
    [StudentCourse].[Progress],
    [StudentCourse].[LastUpdateDate]
FROM
    [Course]
    LEFT JOIN [StudentCourse] ON [StudentCourse].[CourseId] = [Course].[Id]
    LEFT JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]

EXEC spStudentProgress 'c3d924e1-dc58-41e2-8329-f76ed355dcf9'
SELECT * FROM [Student]
EXEC spDeleteStudent 'c3d924e1-dc58-41e2-8329-f76ed355dcf9'