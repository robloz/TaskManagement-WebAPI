using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TaskManagement.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "TaskStatusApi",
                routeTemplate: "api/Task/{idTask}/status/{statusId}",
                defaults: new { controller = "TaskStatus", statusId=RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "TaskPriorityApi",
                routeTemplate: "api/Task/{idTask}/priority/",
                defaults: new { controller = "TaskPriority" }
            );

            config.Routes.MapHttpRoute(
                name: "TaskUserApi",
                routeTemplate: "api/Task/{idTask}/users/",
                defaults: new { controller = "TaskUser" }
            );

            config.Routes.MapHttpRoute(
                name: "TaskCategoriesApi",
                routeTemplate: "api/Task/{idTask}/category/",
                defaults: new { controller = "TaskCategories" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
