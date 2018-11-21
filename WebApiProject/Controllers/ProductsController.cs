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

			return mapper.Map<List<Product>, List<ProductResponse>>(productService.GetByCatagory(Category.COMPUTER));
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

		// POST: api/Products
		[HttpPost]
		[Route("api/products")]
		public void Post([FromBody] Product product)
		{
			productService.Add(product);
		}

		// PUT: api/Products/5
		[HttpPut]
		[Route("api/products/{id}")]
		public void Put(int id, [FromBody] Product product)
		{
			productService.Edit(product, id);
		}

		// DELETE: api/Products/5
		[HttpDelete]
		[Route("api/products/{id}")]
		public void Delete(int id)
		{
			productService.Remove(id);
		}
	}
}