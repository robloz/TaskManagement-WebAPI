using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.SqlServer.Mapper
{
    class CategoryMapper
    {
        public static TaskManagement.Api.Models.Category CreateCategory(TaskManagement.Data.SqlServer.Category category)
        {
            return new TaskManagement.Api.Models.Category
            {
                Id = category.id,
                DescriptionCategory = category.descriptionCategory,
                NameCategory = category.nameCategory,
                Links = new List<TaskManagement.Api.Models.Link>{
                new TaskManagement.Api.Models.Link{
                    Title="self",
                    Rel = "self",
                    Href ="/api/Categories/"+category.id
                }
               }
            };
        }

        public static TaskManagement.Data.SqlServer.Category CreateCategory(TaskManagement.Api.Models.Category category)
        {
            return new TaskManagement.Data.SqlServer.Category
            {

                id = category.Id,
                descriptionCategory = category.DescriptionCategory,
                nameCategory = category.NameCategory,

            };
        }
    }
}
