
insert into tbl_priority(namePriority, Ordinal)values('high', 3) 
insert into tbl_priority(namePriority, Ordinal)values('normal', 2)
insert into tbl_priority(namePriority, Ordinal)values('low', 1)


insert into tbl_status(nameStatus, Ordinal)values('undone', 1)
insert into tbl_status(nameStatus, Ordinal)values('completed', 2)

insert into tbl_task(subjectTask, StartDate, DueDate, DateCompleted, CreateDate, idPriority, idStatus, isUser)
values('check user', '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM',2, 4, '53223af8-a6be-4579-bfb0-9a2e38380696')

insert into tbl_task(subjectTask, StartDate, DueDate, DateCompleted, CreateDate, idPriority, idStatus, isUser)
values('check user', '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM',3, 5, '53223af8-a6be-4579-bfb0-9a2e38380696')



