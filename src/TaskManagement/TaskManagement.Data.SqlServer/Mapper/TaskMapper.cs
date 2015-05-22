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
    }
}
