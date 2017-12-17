
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/17/2017 18:47:28
-- Generated from EDMX file: D:\Projects\Snokye\Snokye.VVM\Model\Snokye.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SnokyeDev];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoBillBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillBaseSet] DROP CONSTRAINT [FK_UserInfoBillBase];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoSet];
GO
IF OBJECT_ID(N'[dbo].[ProfileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfileSet];
GO
IF OBJECT_ID(N'[dbo].[BillBaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillBaseSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfoSet'
CREATE TABLE [dbo].[UserInfoSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [DisplayName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(32)  NOT NULL,
    [Disabled] bit  NOT NULL,
    [UserGuid] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProfileSet'
CREATE TABLE [dbo].[ProfileSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Category] nvarchar(50)  NOT NULL,
    [Key] nvarchar(50)  NOT NULL,
    [Value] nvarchar(50)  NOT NULL,
    [UserGuid] uniqueidentifier  NULL
);
GO

-- Creating table 'BillBaseSet'
CREATE TABLE [dbo].[BillBaseSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [BillerID] bigint  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [UserInfo_Id] bigint  NOT NULL
);
GO

-- Creating table 'BillBaseSet_ExampleBill'
CREATE TABLE [dbo].[BillBaseSet_ExampleBill] (
    [Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfoSet'
ALTER TABLE [dbo].[UserInfoSet]
ADD CONSTRAINT [PK_UserInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfileSet'
ALTER TABLE [dbo].[ProfileSet]
ADD CONSTRAINT [PK_ProfileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BillBaseSet'
ALTER TABLE [dbo].[BillBaseSet]
ADD CONSTRAINT [PK_BillBaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BillBaseSet_ExampleBill'
ALTER TABLE [dbo].[BillBaseSet_ExampleBill]
ADD CONSTRAINT [PK_BillBaseSet_ExampleBill]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_Id] in table 'BillBaseSet'
ALTER TABLE [dbo].[BillBaseSet]
ADD CONSTRAINT [FK_UserInfoBillBase]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoBillBase'
CREATE INDEX [IX_FK_UserInfoBillBase]
ON [dbo].[BillBaseSet]
    ([UserInfo_Id]);
GO

-- Creating foreign key on [Id] in table 'BillBaseSet_ExampleBill'
ALTER TABLE [dbo].[BillBaseSet_ExampleBill]
ADD CONSTRAINT [FK_ExampleBill_inherits_BillBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[BillBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------