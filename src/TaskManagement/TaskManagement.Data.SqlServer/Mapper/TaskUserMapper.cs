﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.SqlServer.Mapper
{
    class TaskUserMapper
    {
     public static TaskManagement.Api.Models.TaskUser CreateTask(TaskManagement.Data.SqlServer.TaskUser task)
            {
                return new TaskManagement.Api.Models.TaskUser
                {
                    idTask = task.idTask,
                    idUser = task.idUser,
                };


            }
     public static TaskManagement.Data.SqlServer.TaskUser CreateTask(TaskManagement.Api.Models.TaskUser task)
     {
         return new TaskManagement.Data.SqlServer.TaskUser
         {
             idTask = task.idTask,
             idUser = task.idUser,
         };


     }
    }
}
