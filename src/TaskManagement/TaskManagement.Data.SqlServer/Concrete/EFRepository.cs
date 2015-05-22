using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Api.Models;
using TaskManagement.Api.Models.Abstract;
using TaskManagement.Data.SqlServer.Mapper;

namespace TaskManagement.Data.SqlServer.Concrete
{
    public class EFRepository: IRepository
    {

        protected virtual TaskManagementDBEntities context { set; get; }

        public EFRepository()
        {
            context = new TaskManagementDBEntities();
        }

        public IEnumerable<TaskManagement.Api.Models.Category> Categories
        {
            get
            {
                return context.tbl_category.Select(CategoryMapper.CreateCategory);
            }
        }

        public IEnumerable<TaskManagement.Api.Models.Priority> Priorities
        {
            get
            {
                return context.tbl_priority.Select(PriorityMapper.CreatePriority);
            }
        }

        public IEnumerable<TaskManagement.Api.Models.Status> Status
        {
            get
            {
                return context.tbl_status.Select(StatusMapper.CreateStatus);
            }
        }

        public IEnumerable<TaskManagement.Api.Models.Task> Tasks
        {
            get
            {
                return context.tbl_task.Select(TaskMapper.CreateTask);
            }
        }

        public IEnumerable<TaskManagement.Api.Models.TaskUser> TasksUsers
        {
            get
            {
                return context.tbl_TaskUser.Select(TaskUserMapper.CreateTask);
            }
        }
        
        public TaskManagement.Api.Models.Category Save(TaskManagement.Api.Models.Category category)
        {
            var cat = CategoryMapper.CreateCategory(category);
 
            context.tbl_category.Add(cat);

            context.SaveChanges();

            // return the insert element with the right id
            return CategoryMapper.CreateCategory(cat);

        }

        public void DeleteCategory(int id)
        {

            var item = context.tbl_category.FirstOrDefault(x => x.id == id);

            if (item != null)
            {
                context.tbl_category.Remove(item);
            }

            context.SaveChanges();

        }

    }
}
