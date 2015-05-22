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
    public class PrioritiesController : ApiController
    {
        IRepository _repository;

        public PrioritiesController(IRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Priority> Get()
        {

            return _repository.Priorities;
        }


        public Priority Get(int id)
        {
            Priority priority = _repository.Priorities.SingleOrDefault(x=>x.Id==id);

            if(priority==null)
            {
                throw new HttpResponseException(
                    
                    new HttpResponseMessage{
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = String.Format("Priority {0} not found", id)
                    }
                    );
            }

            return priority;
        }

    }
}
