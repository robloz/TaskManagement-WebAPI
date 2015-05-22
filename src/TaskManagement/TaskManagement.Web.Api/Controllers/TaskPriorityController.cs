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
    public class TaskPriorityController : ApiController
    {

        IRepository _repository;

        public TaskPriorityController(IRepository repository)
        {
            _repository = repository;
        }

        // api/taks/idTask/priority
        public Priority Get(int idTask)
        {

            Task task = _repository.Tasks.SingleOrDefault(x => x.Id == idTask);

            if (task == null)
            {
                throw new HttpResponseException(

                        new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            ReasonPhrase = String.Format("Priority {0} not found", idTask)
                        }
                    );
            }

            return task.Priority;
        }
    }
}
