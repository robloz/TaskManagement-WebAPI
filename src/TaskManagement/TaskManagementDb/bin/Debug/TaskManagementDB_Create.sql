﻿/*
Deployment script for TaskManagementDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TaskManagementDB"
:setvar DefaultFilePrefix "TaskManagementDB"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)] COLLATE Modern_Spanish_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)];


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Name]...';


GO
CREATE TYPE [dbo].[Name]
    FROM NVARCHAR (50) NOT NULL;


GO
PRINT N'Creating [dbo].[Flag]...';


GO
CREATE TYPE [dbo].[Flag]
    FROM BIT NOT NULL;


GO
PRINT N'Creating [dbo].[Email]...';


GO
CREATE TYPE [dbo].[Email]
    FROM NVARCHAR (100) NULL;


GO
PRINT N'Creating [dbo].[Phone]...';


GO
CREATE TYPE [dbo].[Phone]
    FROM NVARCHAR (25) NULL;


GO
PRINT N'Creating [dbo].[tbl_TaskCategory]...';


GO
CREATE TABLE [dbo].[tbl_TaskCategory] (
    [idTask]     INT NOT NULL,
    [idCategory] INT NOT NULL,
    CONSTRAINT [task_cat_pk] PRIMARY KEY CLUSTERED ([idTask] ASC, [idCategory] ASC)
);


GO
PRINT N'Creating [dbo].[tbl_status]...';


GO
CREATE TABLE [dbo].[tbl_status] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [nameStatus] VARCHAR (MAX) NOT NULL,
    [Ordinal]    INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[tbl_priority]...';


GO
CREATE TABLE [dbo].[tbl_priority] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [namePriority] VARCHAR (MAX) NULL,
    [Ordinal]      INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[tbl_category]...';


GO
CREATE TABLE [dbo].[tbl_category] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [nameCategory]        VARCHAR (MAX) NULL,
    [descriptionCategory] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[tbl_TaskUser]...';


GO
CREATE TABLE [dbo].[tbl_TaskUser] (
    [idTask] INT            NOT NULL,
    [idUser] NVARCHAR (128) NOT NULL,
    CONSTRAINT [cust_acct_pk] PRIMARY KEY CLUSTERED ([idTask] ASC, [idUser] ASC)
);


GO
PRINT N'Creating [dbo].[tbl_task]...';


GO
CREATE TABLE [dbo].[tbl_task] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [subjectTask]   VARCHAR (MAX)  NOT NULL,
    [StartDate]     DATETIME       NULL,
    [DueDate]       DATETIME       NULL,
    [DateCompleted] DATETIME       NULL,
    [CreateDate]    DATETIME       NULL,
    [idPriority]    INT            NULL,
    [idStatus]      INT            NULL,
    [isUser]        NVARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating FK_Category_...';


GO
ALTER TABLE [dbo].[tbl_TaskCategory]
    ADD CONSTRAINT [FK_Category_] FOREIGN KEY ([idCategory]) REFERENCES [dbo].[tbl_category] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating FK_Task...';


GO
ALTER TABLE [dbo].[tbl_TaskCategory]
    ADD CONSTRAINT [FK_Task] FOREIGN KEY ([idTask]) REFERENCES [dbo].[tbl_task] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating FK_TaskUser_...';


GO
ALTER TABLE [dbo].[tbl_TaskUser]
    ADD CONSTRAINT [FK_TaskUser_] FOREIGN KEY ([idTask]) REFERENCES [dbo].[tbl_task] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key on [dbo].[tbl_task]....';


GO
ALTER TABLE [dbo].[tbl_task]
    ADD FOREIGN KEY ([idPriority]) REFERENCES [dbo].[tbl_priority] ([id]);


GO
PRINT N'Creating Foreign Key on [dbo].[tbl_task]....';


GO
ALTER TABLE [dbo].[tbl_task]
    ADD FOREIGN KEY ([idStatus]) REFERENCES [dbo].[tbl_status] ([id]);


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Update complete.'
GO