using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;

namespace WebApiProject.Controllers
{
    public class ProductController : ApiController
    {
	    private ProductService ProductService;

	    public ProductController()
	    {
		    ProductService = new ProductService();
	    }

	    // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

		// POST: api/Product
		[HttpPost]
		[Route("api/products")]
		public void Post([FromBody]Product product)
		{
			Product p = new Product
			{
				Catagory = Catagory.CAMERA,
				Description = "This is a Camera",

			}
			ProductService.Add();
		}

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
