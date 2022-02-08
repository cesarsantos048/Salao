IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [ServicoId] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Apelido] varchar(50) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Servicos] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Descricao] text NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Servicos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Servicos_ClienteId] ON [Servicos] ([ClienteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220201140740_InitialCreate', N'3.1.22');

GO

