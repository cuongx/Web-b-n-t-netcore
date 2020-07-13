IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704160544_InitApp')
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Price] real NOT NULL,
        [CarManufacturer] int NULL,
        [AvatarPath] nvarchar(max) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704160544_InitApp')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AvatarPath', N'CarManufacturer', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    INSERT INTO [Employees] ([Id], [AvatarPath], [CarManufacturer], [Name], [Price])
    VALUES (1, N'images/cd-4.jpg', 3, N'FordEverest', CAST(8000000 AS real));
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AvatarPath', N'CarManufacturer', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704160544_InitApp')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AvatarPath', N'CarManufacturer', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    INSERT INTO [Employees] ([Id], [AvatarPath], [CarManufacturer], [Name], [Price])
    VALUES (2, N'images/cd-5.jpg', 4, N'Lexus2019', CAST(9000000 AS real));
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AvatarPath', N'CarManufacturer', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704160544_InitApp')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200704160544_InitApp', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704161239_CreateEmployeesTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200704161239_CreateEmployeesTable', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704161905_SeedingEmoloyeesData')
BEGIN
    ALTER TABLE [Employees] DROP CONSTRAINT [PK_Employees];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704161905_SeedingEmoloyeesData')
BEGIN
    EXEC sp_rename N'[Employees]', N'employees';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704161905_SeedingEmoloyeesData')
BEGIN
    ALTER TABLE [employees] ADD CONSTRAINT [PK_employees] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200704161905_SeedingEmoloyeesData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200704161905_SeedingEmoloyeesData', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    ALTER TABLE [employees] DROP CONSTRAINT [PK_employees];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    EXEC sp_rename N'[employees]', N'Employees';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200705095240_InitIdentityTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200705095240_InitIdentityTables', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'CarManufacturer');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Employees] DROP COLUMN [CarManufacturer];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    ALTER TABLE [Employees] ADD [CarbrandId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [City] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    CREATE TABLE [Carbrands] (
        [CarbrandId] int NOT NULL IDENTITY,
        [CarbrandName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Carbrands] PRIMARY KEY ([CarbrandId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CarbrandId', N'CarbrandName') AND [object_id] = OBJECT_ID(N'[Carbrands]'))
        SET IDENTITY_INSERT [Carbrands] ON;
    INSERT INTO [Carbrands] ([CarbrandId], [CarbrandName])
    VALUES (1, N'FORD');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CarbrandId', N'CarbrandName') AND [object_id] = OBJECT_ID(N'[Carbrands]'))
        SET IDENTITY_INSERT [Carbrands] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CarbrandId', N'CarbrandName') AND [object_id] = OBJECT_ID(N'[Carbrands]'))
        SET IDENTITY_INSERT [Carbrands] ON;
    INSERT INTO [Carbrands] ([CarbrandId], [CarbrandName])
    VALUES (2, N'LEXUS');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CarbrandId', N'CarbrandName') AND [object_id] = OBJECT_ID(N'[Carbrands]'))
        SET IDENTITY_INSERT [Carbrands] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    UPDATE [Employees] SET [AvatarPath] = N'fOR.jpg', [CarbrandId] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    UPDATE [Employees] SET [AvatarPath] = N'lAMBO.jpg', [CarbrandId] = 2
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    CREATE INDEX [IX_Employees_CarbrandId] ON [Employees] ([CarbrandId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Carbrands_CarbrandId] FOREIGN KEY ([CarbrandId]) REFERENCES [Carbrands] ([CarbrandId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200707074437_ExtendIdentityTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200707074437_ExtendIdentityTables', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    CREATE TABLE [Descriptions] (
        [DescriptionId] int NOT NULL IDENTITY,
        [OriginName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Descriptions] PRIMARY KEY ([DescriptionId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    CREATE TABLE [EmployeeDescriptions] (
        [EmployeeId] int NOT NULL,
        [DescriptionId] int NOT NULL,
        [EmployeesId] int NULL,
        CONSTRAINT [PK_EmployeeDescriptions] PRIMARY KEY ([EmployeeId], [DescriptionId]),
        CONSTRAINT [FK_EmployeeDescriptions_Descriptions_DescriptionId] FOREIGN KEY ([DescriptionId]) REFERENCES [Descriptions] ([DescriptionId]) ON DELETE CASCADE,
        CONSTRAINT [FK_EmployeeDescriptions_Employees_EmployeesId] FOREIGN KEY ([EmployeesId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DescriptionId', N'OriginName') AND [object_id] = OBJECT_ID(N'[Descriptions]'))
        SET IDENTITY_INSERT [Descriptions] ON;
    INSERT INTO [Descriptions] ([DescriptionId], [OriginName])
    VALUES (1, N'Anh Quốc'),
    (2, N'Hoa Kì'),
    (3, N'Việt Nam'),
    (4, N'Italia');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DescriptionId', N'OriginName') AND [object_id] = OBJECT_ID(N'[Descriptions]'))
        SET IDENTITY_INSERT [Descriptions] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'DescriptionId', N'EmployeesId') AND [object_id] = OBJECT_ID(N'[EmployeeDescriptions]'))
        SET IDENTITY_INSERT [EmployeeDescriptions] ON;
    INSERT INTO [EmployeeDescriptions] ([EmployeeId], [DescriptionId], [EmployeesId])
    VALUES (1, 1, NULL),
    (2, 1, NULL),
    (3, 2, NULL),
    (4, 2, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'DescriptionId', N'EmployeesId') AND [object_id] = OBJECT_ID(N'[EmployeeDescriptions]'))
        SET IDENTITY_INSERT [EmployeeDescriptions] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    CREATE INDEX [IX_EmployeeDescriptions_DescriptionId] ON [EmployeeDescriptions] ([DescriptionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    CREATE INDEX [IX_EmployeeDescriptions_EmployeesId] ON [EmployeeDescriptions] ([EmployeesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200709151200_CreateDescriptionTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200709151200_CreateDescriptionTable', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200711161300_CreateOrderTable')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [OrderName] nvarchar(100) NOT NULL,
        [EmployeesId] int NULL,
        [Employeeee] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_Employees_EmployeesId] FOREIGN KEY ([EmployeesId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200711161300_CreateOrderTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Employeeee', N'EmployeesId', N'OrderName') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    INSERT INTO [Orders] ([OrderId], [Employeeee], [EmployeesId], [OrderName])
    VALUES (1, 0, NULL, N'Trắng');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Employeeee', N'EmployeesId', N'OrderName') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200711161300_CreateOrderTable')
BEGIN
    CREATE INDEX [IX_Orders_EmployeesId] ON [Orders] ([EmployeesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200711161300_CreateOrderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200711161300_CreateOrderTable', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'Employeeee');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Orders] DROP COLUMN [Employeeee];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [Avatar] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [CarColor] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [Carname] nvarchar(100) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [City] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [EmployeeId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    ALTER TABLE [Orders] ADD [Phone] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712014211_AlterOrderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200712014211_AlterOrderTable', N'3.1.5');
END;

GO

