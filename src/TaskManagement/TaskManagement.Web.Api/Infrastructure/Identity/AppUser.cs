using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace TaskManagement.Web.Api.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {              // <------------add this

        public string nickname { get; set; }
        public string surname { get; set; }
        public string picture { get; set; }
        public Nullable<System.DateTime> dateBirthday { get; set; }
        public string passwordUser { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.Guid> UserGuid { get; set; }
        public Nullable<int> IDRol { get; set; }

    }
}