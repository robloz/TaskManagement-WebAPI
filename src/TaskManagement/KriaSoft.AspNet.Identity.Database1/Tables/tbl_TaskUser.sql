CREATE TABLE [dbo].[tbl_TaskUser] (
    [idTask] INT            NOT NULL,
    [idUser] NVARCHAR (128) NOT NULL,
    CONSTRAINT [cust_acct_pk] PRIMARY KEY CLUSTERED ([idTask] ASC, [idUser] ASC),
    CONSTRAINT [FK_TaskUser_] FOREIGN KEY ([idTask]) REFERENCES [dbo].[tbl_task] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

