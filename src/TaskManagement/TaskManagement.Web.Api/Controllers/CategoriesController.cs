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
    public class CategoriesController : ApiController
    {

        IRepository _repository;

        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> Get()
        {
            return _repository.Categories;
        }

        public Category Get(int id)
        {

            Category category = _repository.Categories.SingleOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new HttpResponseException(

                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = String.Format("Category {0} not found", id)
                    }
                    );
            }

            return category;

        }

        
        public HttpResponseMessage Post(HttpRequestMessage request, Category category)
        {

            var c = _repository.Save(category);

            var response = request.CreateResponse(HttpStatusCode.Created, category);
            response.Headers.Add("Location", 
                _repository.Categories.SingleOrDefault(x=>x.Id==c.Id)
                    .Links.First(x=>x.Rel=="self").Href
            );

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {

            _repository.DeleteCategory(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
