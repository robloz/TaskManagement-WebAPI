using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.SqlServer.Mapper
{
    class TaskMapper
    {
        public static TaskManagement.Api.Models.Task CreateTask(TaskManagement.Data.SqlServer.Task task)
        {
            IEnumerable<TaskManagement.Data.SqlServer.Category> enumerableCategory = task.tbl_category;


            return new TaskManagement.Api.Models.Task
            {
                Id = task.id,
                CreateDate = task.CreateDate,
                DateCompleted = task.DateCompleted,
                DueDate = task.DueDate,
                Priority = PriorityMapper.CreatePriority( task.tbl_priority),
                StartDate = task.StartDate,
                Status = StatusMapper.CreateStatus( task.tbl_status ),
                SubjectTask = task.subjectTask,
                Place = task.place,
                Categories = ((IEnumerable<TaskManagement.Data.SqlServer.Category>)task.tbl_category)
                                .Select(CategoryMapper.CreateCategory)
                                .ToList(),

                Links = new List<TaskManagement.Api.Models.Link>{
                new TaskManagement.Api.Models.Link{
                    Title="self",
                    Rel = "self",
                    Href ="/api/Task/"+task.id
                }

               }
            };


        }

        public static TaskManagement.Data.SqlServer.Task CreateTask(TaskManagement.Api.Models.Task task)
        {

            return new TaskManagement.Data.SqlServer.Task
            {
                CreateDate = task.CreateDate,
                DateCompleted = task.DateCompleted,
                DueDate = task.DueDate,
                id = task.Id,
                idPriority = task.Priority.Id,
                idStatus = task.Status.Id,
                place = task.Place,
                StartDate = task.StartDate,
                subjectTask = task.SubjectTask,
                tbl_category = task.Categories.Select(CategoryMapper.CreateCategory).ToList(),
                tbl_priority = PriorityMapper.CreatePriority(task.Priority),
                tbl_status = StatusMapper.CreateStatus(task.Status)
            };

        }

    }
}
