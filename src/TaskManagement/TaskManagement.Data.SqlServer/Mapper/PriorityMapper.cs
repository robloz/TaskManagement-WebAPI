using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.SqlServer.Mapper
{
    class PriorityMapper
    {
        public static TaskManagement.Api.Models.Priority CreatePriority(TaskManagement.Data.SqlServer.Priority priority)
        {
            return new TaskManagement.Api.Models.Priority
            {
               Id = priority.id,
               NamePriority = priority.namePriority,
               Ordinal = priority.Ordinal, 
               Links = new List<TaskManagement.Api.Models.Link>{
                new TaskManagement.Api.Models.Link{
                    Title="self",
                    Rel = "self",
                    Href ="/api/Priorities/"+priority.id
                }
               }
            };
        }

        public static TaskManagement.Data.SqlServer.Priority CreatePriority(TaskManagement.Api.Models.Priority priority)
        {
            return new TaskManagement.Data.SqlServer.Priority
            {
                id = priority.Id,
                namePriority = priority.NamePriority,
                Ordinal = priority.Ordinal

            };
        }
    }
}
