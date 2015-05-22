using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Web.Api.Infrastructure.Identity;
// security
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TaskManagement.Common.Interface;

namespace TaskManagement.Web.Api.Controllers
{
    public class HomeController : Controller
    {

        private IDateTime _time;

        // public to be able to make unit tests
        private AppUserManager _authnManager;
        public AppUserManager UserManager
        {
            get
            {
                //  return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                if (_authnManager == null)
                    _authnManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                return _authnManager;
            }

            set
            {
                _authnManager = value;
            }
        }

        public HomeController(IDateTime time)
        {
            _time = time;
            /*
            UserManager.Create(new AppUser { UserName = "jose", nickname="jose" }, "11111dad");
            UserManager.Create(new AppUser { UserName = "juan", nickname="juan" }, "11111dad");
             * */
        }

        public ActionResult Index()
        {


            AppUser user = UserManager.FindByName(HttpContext.User.Identity.Name);
            
            DateTime d =_time.UtcNow;

            return View();


        }
    }
}
