SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    INNER JOIN [Categoria] -- INNER JOIN é uma interseção
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    LEFT JOIN [Categoria] -- Captura todos os valores da primeira tabela, no caso retorna todos os cursos
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    RIGHT JOIN [Categoria] -- Captura todos os valores da segunda tabela, no caso retorna todos as categorias
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    FULL OUTER JOIN [Categoria] -- Captura todos os valores de todas as tabelas
        ON [Curso].[CategoriaId] = [Categoria].[Id]

    SELECT TOP 100
        [Id], [Nome]
    FROM
        [Curso]
UNION -- No union devemos ter os mesmos tipos de dados. UNION ALL é remove os repetidos, similar a um distinct.
    SELECT TOP 100
        [Id], [Nome]
    FROM
        [Categoria]