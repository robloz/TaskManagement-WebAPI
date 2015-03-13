CREATE TABLE [dbo].[tbl_category] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [nameCategory]        VARCHAR (MAX) NULL,
    [descriptionCategory] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

