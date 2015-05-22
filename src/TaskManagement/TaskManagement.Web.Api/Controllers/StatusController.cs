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
    public class StatusController : ApiController
    {
      IRepository _repository;

      public StatusController(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Status> Get()
        {
            return _repository.Status;
        }

        public Status Get(int id)
        {

            Status status = _repository.Status.SingleOrDefault(x => x.Id == id);

            if (status == null)
            {
                throw new HttpResponseException(

                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = String.Format("Status {0} not found", id)
                    }
                    );
            }

            return status;

        }
    }
}
