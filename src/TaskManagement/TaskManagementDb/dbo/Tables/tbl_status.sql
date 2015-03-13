CREATE TABLE [dbo].[tbl_status] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [nameStatus] VARCHAR (MAX) NOT NULL,
    [Ordinal]    INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

