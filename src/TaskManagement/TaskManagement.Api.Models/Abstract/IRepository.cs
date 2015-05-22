using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Api.Models.Abstract
{
    public interface IRepository
    {
        IEnumerable<TaskManagement.Api.Models.Category> Categories { get; }
        IEnumerable<TaskManagement.Api.Models.Priority> Priorities { get; }
        IEnumerable<TaskManagement.Api.Models.Status> Status { get; }
        IEnumerable<TaskManagement.Api.Models.Task> Tasks { get; }
        IEnumerable<TaskManagement.Api.Models.TaskUser> TasksUsers { get; }

        TaskManagement.Api.Models.Category Save(TaskManagement.Api.Models.Category category);
        void DeleteCategory(int id);
    }
}
