﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Api.Models;
using TaskManagement.Api.Models.Abstract;

namespace TaskManagement.Web.Api.Controllers
{
    // subcontrol from TaskController
    public class TaskStatusController : ApiController
    {

        IRepository _repository;

        public TaskStatusController(IRepository repository)
        {
            _repository = repository;
        }
        // api/task/idTask/status
        public Status Get(int idTask){

            Task task = _repository.Tasks.SingleOrDefault(x=>x.Id==idTask);

            if(task==null){
                throw new HttpResponseException(
                    
                    new HttpResponseMessage{
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = String.Format("Priority {0} not found", idTask)
                    }
                    );
            }

            return task.Status;
        }

        public void Put(int idTask, int idStatus)
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

            task.Status = _repository.Status.FirstOrDefault(x=>x.Id==idStatus);

            
        }
    }
}
