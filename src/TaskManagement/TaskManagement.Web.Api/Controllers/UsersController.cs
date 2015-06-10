using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Web.Api.Infrastructure.Identity;

namespace TaskManagement.Web.Api.Controllers
{
    public class UsersController : ApiController
    {

        IAuthnManager _authnManager;

        public UsersController(IAuthnManager authnManager)
        {
            _authnManager = authnManager;

        }


        public IEnumerable<AppUser> Get()
        {

            return _authnManager.Users;
        }



    }
}
