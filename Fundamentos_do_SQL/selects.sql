SELECT  * FROM [Curso]
SELECT TOP 2 * FROM [Curso] -- A dica é sempre usar o top.

SELECT TOP 2
    [Id], [Nome]
FROM
    [Curso]

SELECT DISTINCT TOP 100
    [Id], [Nome]
FROM
    [Categoria]

SELECT TOP 100
    [Id], [Nome], [CategoriaId]
FROM
    [Curso]
WHERE
    [Id] = 1 AND -- OR, IS NULL, IS NOT NULL
    [CategoriaId] = 1

SELECT TOP 100
    [Id], [Nome], [CategoriaId]
FROM
    [Curso]
-- WHERE
--     [Id] = 1 AND -- OR, IS NULL, IS NOT NULL
--     [CategoriaId] = 1
ORDER BY 
    [Nome] ASC -- DESC

SELECT TOP 100
    MAX([Id])
FROM
    [Curso]

SELECT TOP 100
    COUNT([Id]) -- AVG, SUM
FROM
    [Curso]

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Nome] LIKE '%Fundamentos%' -- % no início e no fim é similar a contém.

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Id] IN (1, 3)

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Id] BETWEEN 2 AND 3

SELECT TOP 100
    [Id] AS [Codigo],
    [Nome]
FROM
    [Curso]

SELECT TOP 100
    Count([Id]) AS [Total]
FROM
    [Curso]