IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TimeEntries] (
    [Id] int NOT NULL IDENTITY,
    [Project] nvarchar(255) NOT NULL,
    [Start] datetime2 NOT NULL,
    [End] datetime2 NULL,
    [Created] datetime2 NOT NULL,
    [Updated] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_TimeEntries] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250331004721_InitialDatabaseCreation', N'9.0.3');

CREATE INDEX [IX_TimeEntries_IsDeleted] ON [TimeEntries] ([IsDeleted]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250331232420_AddIsDeletedIndex', N'9.0.3');

COMMIT;
GO

