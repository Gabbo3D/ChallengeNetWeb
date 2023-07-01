
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2023 18:53:17
-- Generated from EDMX file: C:\Users\Gab\source\repos\ATM_Challenge\ATM_Challenge.DTO\ModelATM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ATMdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CardBalance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BalanceSet] DROP CONSTRAINT [FK_CardBalance];
GO
IF OBJECT_ID(N'[dbo].[FK_CardWithdrawal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WithdrawalSet] DROP CONSTRAINT [FK_CardWithdrawal];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CardSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CardSet];
GO
IF OBJECT_ID(N'[dbo].[BalanceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BalanceSet];
GO
IF OBJECT_ID(N'[dbo].[WithdrawalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WithdrawalSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CardSet'
CREATE TABLE [dbo].[CardSet] (
    [IdCard] bigint IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Pin] nvarchar(max)  NOT NULL,
    [DueDate] datetime  NOT NULL,
    [Attempts] smallint  NOT NULL,
    [Lock] bit  NOT NULL
);
GO

-- Creating table 'BalanceSet'
CREATE TABLE [dbo].[BalanceSet] (
    [IdBalance] bigint IDENTITY(1,1) NOT NULL,
    [IdCard] bigint  NOT NULL,
    [RegDate] datetime  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'WithdrawalSet'
CREATE TABLE [dbo].[WithdrawalSet] (
    [IdWithdrawal] bigint IDENTITY(1,1) NOT NULL,
    [IdCard] bigint  NOT NULL,
    [RegDate] datetime  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCard] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [PK_CardSet]
    PRIMARY KEY CLUSTERED ([IdCard] ASC);
GO

-- Creating primary key on [IdBalance] in table 'BalanceSet'
ALTER TABLE [dbo].[BalanceSet]
ADD CONSTRAINT [PK_BalanceSet]
    PRIMARY KEY CLUSTERED ([IdBalance] ASC);
GO

-- Creating primary key on [IdWithdrawal] in table 'WithdrawalSet'
ALTER TABLE [dbo].[WithdrawalSet]
ADD CONSTRAINT [PK_WithdrawalSet]
    PRIMARY KEY CLUSTERED ([IdWithdrawal] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCard] in table 'BalanceSet'
ALTER TABLE [dbo].[BalanceSet]
ADD CONSTRAINT [FK_CardBalance]
    FOREIGN KEY ([IdCard])
    REFERENCES [dbo].[CardSet]
        ([IdCard])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CardBalance'
CREATE INDEX [IX_FK_CardBalance]
ON [dbo].[BalanceSet]
    ([IdCard]);
GO

-- Creating foreign key on [IdCard] in table 'WithdrawalSet'
ALTER TABLE [dbo].[WithdrawalSet]
ADD CONSTRAINT [FK_CardWithdrawal]
    FOREIGN KEY ([IdCard])
    REFERENCES [dbo].[CardSet]
        ([IdCard])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CardWithdrawal'
CREATE INDEX [IX_FK_CardWithdrawal]
ON [dbo].[WithdrawalSet]
    ([IdCard]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------