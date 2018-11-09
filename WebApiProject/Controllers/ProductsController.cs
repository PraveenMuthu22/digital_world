using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;

namespace WebApiProject.Controllers
{
    public class ProductsController : ApiController
    {
	    private ProductService ProductService;

	    public ProductsController()
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
			Debug.WriteLine("Product recieved");
			Debug.WriteLine(product.Name);

			Product p = new Product
			{
				Catagory = Catagory.CAMERA,
				Name = "Nikon",
				Description = "This is a Camera",
				Specification = "15 MP",
				Reviews = new List<Review>()


			};
			ProductService.Add(p);
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
