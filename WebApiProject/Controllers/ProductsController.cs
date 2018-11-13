using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		//TODO : Get by keyword controller
		// GET: api/Product
		[HttpGet]
		[Route("api/products/search/{keyword}")]
		public List<Product> GetByKeyWord(string keyword)
		{
			return ProductService.GetProductsByKeyword(keyword);
		}

		// GET: api/Product/5
		[HttpGet]
		[Route("api/products/{id}")]
		public Product Get(int id)
        {
	        return ProductService.Get(id);
        }

		// POST: api/Products
		[HttpPost]
		[Route("api/products")]
		public void Post([FromBody]Product product)
		{
			ProductService.Add(product);
		}

        // PUT: api/Product/5
		[HttpPut]
		[Route("api/products/id")]
        public void Put(int id, [FromBody]Product product)
        {
	        ProductService.Edit(product, id);
        }

		// DELETE: api/Product/5
		[HttpDelete]
		[Route("api/products/id")]
		public void Delete(int id)
        {
	        ProductService.Remove(id);
        }


    }
}
