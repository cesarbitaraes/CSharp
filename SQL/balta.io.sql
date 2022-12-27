--CREATE DATABASE [Curso];

--DROP DATABASE [Curso];

-- USE [master];
-- DECLARE @kill varchar(8000) = '';  
-- SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
-- FROM sys.dm_exec_sessions
-- WHERE database_id  = db_id('Curso')
-- EXEC(@kill);
-- DROP DATABASE [Curso];

USE [Curso]

CREATE TABLE [Aluno]( -- Digitar o nome entre colchetes permite usar keywords como nomes, por exemplo.
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL UNIQUE,
    [Nascimento] DATETIME NULL,
    [Active] BIT DEFAULT(0)

    --PRIMARY KEY([Id])
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]), -- Permite nomear campos
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
)
GO -- Faz com que tudo anteriormente seja executado

DROP TABLE [Aluno]

ALTER TABLE [Aluno]
    ADD [Document] NVARCHAR(11)

ALTER TABLE [Aluno]
    DROP COLUMN [Document]

ALTER TABLE [Aluno]
    ALTER COLUMN [Document] CHAR(11)

ALTER TABLE [Aluno]
    ALTER COLUMN [Active] BIT NOT NULL

ALTER TABLE [Aluno]
    ADD PRIMARY KEY([Id])

ALTER TABLE [Aluno]
    DROP CONSTRAINT [PK__Aluno__3214EC07E5929F99]

CREATE TABLE [Curso]( -- Digitar o nome entre colchetes permite usar keywords como nomes, por exemplo.
    [Id] INT NOT NULL IDENTITY(1, 1), --Incrementa automaticamente o campo, nesse caso de 1 em 1
    --[Id] UNIQUEIDENTIFIER NOT NULL - gera automaticamente GUIDs para cada registro
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL

    --PRIMARY KEY([Id])
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]), -- Permite nomear campos
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])
)
GO -- Faz com que tudo anteriormente seja executado

CREATE TABLE [ProgressoCurso]( -- Digitar o nome entre colchetes permite usar keywords como nomes, por exemplo.
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE())

    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY(AlunoId, CursoId)
)
GO -- Faz com que tudo anteriormente seja executado

CREATE TABLE [Categoria]( -- Digitar o nome entre colchetes permite usar keywords como nomes, por exemplo.
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL

    --PRIMARY KEY([Id])
    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]), -- Permite nomear campos
)
GO -- Faz com que tudo anteriormente seja executado

DROP TABLE [Curso]

-- Índices: sempre criar nos campos que mais utilizamos em um tabela.
CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])
DROP INDEX [IX_Aluno_Email] ON [Aluno]

SELECT NEWID()