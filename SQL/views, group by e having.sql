CREATE OR ALTER VIEW vwContagemCursosPorCategoria AS -- View não pode ter ORDER BY
    SELECT TOP 100
        [Categoria].[Id],
        [Categoria].[Nome],
        COUNT([Curso].[CategoriaId]) AS [Cursos]
    FROM
        [Categoria]
        INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY
        [Categoria].[Id],
        [Categoria].[Nome],
        [Curso]. [CategoriaId]
    HAVING
        COUNT([Curso].[CategoriaId]) > 1

SELECT * FROM vwContagemCursosPorCategoria
WHERE Id = 1