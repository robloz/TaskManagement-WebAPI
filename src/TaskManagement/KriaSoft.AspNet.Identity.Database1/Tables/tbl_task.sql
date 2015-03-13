CREATE TABLE [dbo].[tbl_task] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [subjectTask]   VARCHAR (MAX) NOT NULL,
    [StartDate]     DATETIME      NULL,
    [DueDate]       DATETIME      NULL,
    [DateCompleted] DATETIME      NULL,
    [CreateDate]    DATETIME      NULL,
    [idPriority]    INT           NULL,
    [idStatus]      INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idPriority]) REFERENCES [dbo].[tbl_priority] ([id]),
    FOREIGN KEY ([idStatus]) REFERENCES [dbo].[tbl_status] ([id])
);

