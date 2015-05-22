using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace TaskManagement.Web.Api.Infrastructure.Identity
{
    public class AuthnManagerIdentity: IAuthnManager
    {

        private AppUserManager _authnManager;
        public AppUserManager UserManager
        {
            get
            {
                //  return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                if (_authnManager == null)
                    _authnManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
                return _authnManager;
            }

            set
            {
                _authnManager = value;
            }
        }

        public string GetCurrentUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public int GetCurrentUserId
        {
            get { return FindByNameAsync(GetCurrentUser).Id; }
        }

        public async System.Threading.Tasks.Task<Identity.AppUser> FindByNameAsync(string name)
        {
            AppUser user = await UserManager.FindByNameAsync(name);

            return user;
        }

        public async System.Threading.Tasks.Task<Identity.AppUser> FindByIdAsync(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            return user;
        }


    }
}