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
    public class TaskController : ApiController
    {
        IRepository _repository;

        public TaskController(IRepository repository)
        {
            _repository = repository;
        }

        // /api/Task
        public IEnumerable<Task> Get()
        {
            return _repository.Tasks;
        }
        // /api/Task/id
        public Task Get(int id)
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

            return task;

        }

        public HttpResponseMessage Post(HttpRequestMessage request, Task task)
        {

            var t = _repository.Save(task);

            var response = request.CreateResponse(HttpStatusCode.Created, task);
            response.Headers.Add("Location",
                _repository.Categories.SingleOrDefault(x => x.Id == t.Id)
                    .Links.First(x => x.Rel == "self").Href
            );

            return response;
        }

    }
}
