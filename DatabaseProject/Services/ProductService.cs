using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Models_Updated;

namespace DatabaseProject.Services
{
	public class ProductService
	{
		public Product Add(Product product)
		{
			using (var context = new ShopDbContext())
			{
				try
				{
					context.Database.Log = Console.WriteLine;
					var response = context.Products.Add(product);
					context.SaveChanges();
					return response;
				}
				catch (SqlException e)
				{
					Console.WriteLine(e.ToString());
					return null;
				}
			}
		}

		/**
		 * Get given product
		 */
		public Product Get(int id)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				return context.Products.Find(id);
			}			
		}

		/**
		 * Removes selected product
		 */
		public bool Remove(int id)
		{
			using (var context = new ShopDbContext())
			{
				Product product = context.Products.Find(id);
				if (product == null)
				{
					return false;
				}

				context.Products.Remove(product);

				context.SaveChanges();
				return true;
			}
		}

		/**
		 * Modify selected product using data form passed product
		 */
		public bool Edit(Product responseProduct, int id)
		{
			using (var context = new ShopDbContext())
			{
				//Get product. If it doesn't exist return null
				Product oldProduct = context.Products.Find(id);
				if (oldProduct == null)
				{
					return false;
				}

				var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductUpdated>());
				var mapper = config.CreateMapper();
				ProductUpdated updatedProduct =  mapper.Map<ProductUpdated>(responseProduct);

				context.Entry(oldProduct).CurrentValues.SetValues(updatedProduct);

				context.SaveChanges();
				return true;
			}
		}

		/**
		 * Get a list of products that belongs to given category
		 */
		public List<Product> GetByCatagory(Category category)
		{
			using (var context = new ShopDbContext())
			{
				List<Product> products = context.Products
					.Where(p => p.Category == category).ToList();

				return products;
			}
		}

		/**
		 * Add review to product
		 */
		public bool AddReview(Review review)
		{
			using (var context = new ShopDbContext())
			{
				Product product = context.Products.Find(review.ProductId);
				if (product == null)
				{
					return false;
				}

				Customer customer = context.Customers.Find(review.CustomerId);
				if (customer == null)
				{
					return false;
				}

				review.Customer = customer;

				product.Reviews.Add(review);

				context.SaveChanges();
				return true;
			}
		}

		/**
		 * Get a list of reviews associated with the product
		 */
		public List<Review> GetReviews(int id)
		{
			using (var context = new ShopDbContext())
			{
				Product oldProduct = context.Products.Find(id);
				if (oldProduct == null)
				{
					return null;
				}

				return oldProduct.Reviews;
			}
		}

		public List<Product> GetProductsByKeyword(string keyword)
		{
			keyword = keyword.ToLower();
			using (var context = new ShopDbContext())
			{
				List<Product> products = context.Products.Where(p =>
						p.Name.Contains(keyword) || p.Description.Contains(keyword) ||
						p.Specification.Contains(keyword))
					.ToList();

				return products;
;			}
		}
	}
}