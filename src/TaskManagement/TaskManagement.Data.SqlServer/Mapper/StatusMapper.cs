using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.SqlServer.Mapper
{
    class StatusMapper
    {
        public static TaskManagement.Api.Models.Status CreateStatus(TaskManagement.Data.SqlServer.Status status)
        {
            return new TaskManagement.Api.Models.Status
            {
                Id = status.id,
                NameStatus = status.nameStatus,
                Ordinal = status.Ordinal,
                Links = new List<TaskManagement.Api.Models.Link>{
                new TaskManagement.Api.Models.Link{
                    Title="self",
                    Rel = "self",
                    Href ="/api/Status/"+status.id
                }
               }
            };


        }
    }
}
