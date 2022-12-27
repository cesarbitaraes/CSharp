CREATE DATABASE [Cursos]

USE [Cursos]

CREATE TABLE [Categoria]( -- Digitar o nome entre colchetes permite usar keywords como nomes, por exemplo.
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL

    --PRIMARY KEY([Id])
    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]), -- Permite nomear campos
)
GO -- Faz com que tudo anteriormente seja executado

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