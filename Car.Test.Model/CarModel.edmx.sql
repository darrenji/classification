
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2014 17:15:20
-- Generated from EDMX file: F:\学习\练习\Car.Test\Car.Test.Model\CarModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarTest];
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

-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL,
    [Status] smallint  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [CarCategoryID] int  NOT NULL
);
GO

-- Creating table 'CarCategory'
CREATE TABLE [dbo].[CarCategory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL,
    [PreLetter] nvarchar(8)  NOT NULL,
    [ParentID] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Level] int  NOT NULL,
    [IsLeaf] bit  NOT NULL,
    [Status] smallint  NOT NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'CarSell'
CREATE TABLE [dbo].[CarSell] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CarCategoryIds] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CarCategory'
ALTER TABLE [dbo].[CarCategory]
ADD CONSTRAINT [PK_CarCategory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CarSell'
ALTER TABLE [dbo].[CarSell]
ADD CONSTRAINT [PK_CarSell]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarCategoryID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK_CarCategoryCar]
    FOREIGN KEY ([CarCategoryID])
    REFERENCES [dbo].[CarCategory]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCategoryCar'
CREATE INDEX [IX_FK_CarCategoryCar]
ON [dbo].[Car]
    ([CarCategoryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------