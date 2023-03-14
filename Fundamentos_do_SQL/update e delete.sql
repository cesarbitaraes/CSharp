SELECT * FROM [Categoria]

BEGIN TRANSACTION
    UPDATE 
        [Categoria] 
    SET 
        [Nome] = 'Azure'
    WHERE
        [Id] = 4
COMMIT --ROLLBACK

SELECT * FROM [Curso]

BEGIN TRANSACTION
    DELETE FROM 
        [Categoria]
    WHERE
        [Id] = 3
COMMIT --ROLLBACK