using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using AutoMapper;
using DatabaseProject;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;
using WebApiProject.View_Models;

namespace WebApiProject.Controllers
{
	public class ProductsController : ApiController
	{
		private ProductService productService;

		public ProductsController()
		{

			productService = new ProductService();
		}


		// GET: api/products/search/macbook
		[HttpGet]
		[Route("api/products/search/{keyword}")]
		public List<ProductResponse> GetByKeyWord(string keyword)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductResponse>());
			var mapper = config.CreateMapper();

			return mapper.Map<List<Product>, List<ProductResponse>>(productService.GetProductsByKeyword(keyword));
		}

		// GET: api/products/category/COM
		// PUTER
		[HttpGet]
		[Route("api/products/category/{category}")]
		public List<ProductResponse> GetByCategory(Category category)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductResponse>());
			var mapper = config.CreateMapper();

			return mapper.Map<List<Product>, List<ProductResponse>>(productService.GetByCatagory(Category.Computer));
		}

		// GET: api/Product/5
		[HttpGet]
		[Route("api/products/{id}")]
		public ProductResponse Get(int id)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductResponse>());
			var mapper = config.CreateMapper();
			return mapper.Map<ProductResponse>(productService.Get(id));
		}

	    // GET: api/Product/reviews/1
	    [HttpGet]
	    [Route("api/products/reviews/{id}")]
	    public List<ReviewResponse> GetReviews(int id)
	    {
	        var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewResponse>());
	        var mapper = config.CreateMapper();
	        return mapper.Map<List<Review>, List<ReviewResponse>>(productService.GetReviews(id));
	    }

        // POST: api/Products
        [HttpPost]
		[Route("api/products")]
		public bool Post([FromBody] Product product)
		{
			bool response = productService.Add(product);
		    return response;
		}

	    // POST: api/Products/review
	    [HttpPost]
	    [Route("api/products/review")]
	    public bool PostReview([FromBody] Review review)
	    {
	        bool response = productService.AddReview(review);
	        return response;
	    }

        // PUT: api/Products/5
        [HttpPut]
		[Route("api/products")]
		public bool Put([FromBody] Product product)
		{
			bool response = productService.Edit(product);
		    return response;
		}

		// DELETE: api/Products/5
		[HttpDelete]
		[Route("api/products/{id}")]
		public bool Delete(int id)
		{
			bool response = productService.Remove(id);
		    return response;
		}
	}
}