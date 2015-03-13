CREATE TABLE [dbo].[tbl_TaskCategory] (
    [idTask]     INT NOT NULL,
    [idCategory] INT NOT NULL,
    CONSTRAINT [task_cat_pk] PRIMARY KEY CLUSTERED ([idTask] ASC, [idCategory] ASC),
    CONSTRAINT [FK_Category_] FOREIGN KEY ([idCategory]) REFERENCES [dbo].[tbl_category] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Task] FOREIGN KEY ([idTask]) REFERENCES [dbo].[tbl_task] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

