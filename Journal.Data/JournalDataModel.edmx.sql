
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2014 12:34:36
-- Generated from EDMX file: C:\Users\plyusnin\Sources\netJournal\Journal.Data\JournalDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Journal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_UserSession]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSession'
CREATE INDEX [IX_FK_UserSession]
ON [dbo].[Sessions]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------