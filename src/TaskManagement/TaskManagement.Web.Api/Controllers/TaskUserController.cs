using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Api.Models;
using TaskManagement.Api.Models.Abstract;
using TaskManagement.Web.Api.Infrastructure.Identity;

namespace TaskManagement.Web.Api.Controllers
{
    public class TaskUserController : ApiController
    {
        IRepository _repository;
        IAuthnManager _authnManager;

        public TaskUserController(IRepository repository, IAuthnManager authnManager)
        {
            _repository = repository;
            _authnManager = authnManager;
        }

        // api/taks/idTask/priority
        public async System.Threading.Tasks.Task<IEnumerable<AppUser>> Get(int idTask)
        {

            Task task = _repository.Tasks.SingleOrDefault(x => x.Id == idTask);
            List<AppUser> users = new List<AppUser>();

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

            var idUsers = _repository.TasksUsers.Where(x => x.idTask == idTask);

            foreach(var i in idUsers){
                var user = await _authnManager.FindByIdAsync(i.idUser);
                users.Add(user);
            }

            return users;
                
               
        }
    }
}
