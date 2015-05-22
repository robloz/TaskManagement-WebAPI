using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Api.Models;
using TaskManagement.Api.Models.Abstract;

namespace TaskManagement.Web.Api.Controllers
{
    public class TaskCategoriesController : ApiController
    {
        IRepository _repository;

        public TaskCategoriesController(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> Get(int id)
        {

            Task task = _repository.Tasks.SingleOrDefault(x => x.Id == id);

            if (task == null)
            {
                throw new HttpResponseException(

                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = String.Format("Task {0} not found", id)
                    }
                    );
            }

            return task.Categories;

        }

    }
}
