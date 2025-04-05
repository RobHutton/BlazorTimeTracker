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

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeEntries]') AND [c].[name] = N'Project');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [TimeEntries] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [TimeEntries] DROP COLUMN [Project];

ALTER TABLE [TimeEntries] ADD [Deleted] datetime2 NULL;

ALTER TABLE [TimeEntries] ADD [Description] nvarchar(500) NOT NULL DEFAULT N'';

ALTER TABLE [TimeEntries] ADD [ProjectId] int NOT NULL DEFAULT 0;

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Updated] datetime2 NULL,
    [Deleted] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);

CREATE INDEX [IX_TimeEntries_ProjectId] ON [TimeEntries] ([ProjectId]);

CREATE INDEX [IX_Projects_IsDeleted] ON [Projects] ([IsDeleted]);

ALTER TABLE [TimeEntries] ADD CONSTRAINT [FK_TimeEntries_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250403230430_CreateProjectTable', N'9.0.3');

COMMIT;
GO

