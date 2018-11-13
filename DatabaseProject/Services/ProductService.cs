using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using DatabaseProject.Enums;
using DatabaseProject.Models;

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
		//Eager Loading : Load the product along with the reviews
		public Product Get(int id)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				return context.Products.Include(p => p.Reviews).FirstOrDefault(p => p.Id == id);
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
				return true;
			}
		}

		/**
		 * Modify selected product using data form passed product
		 */
		public bool Edit(Product updatedProduct, int id)
		{
			using (var context = new ShopDbContext())
			{
				//Get product. If it doesn't exist return null
				Product oldProduct = context.Products.Find(id);
				if (oldProduct == null)
				{
					return false;
				}

				context.Entry(oldProduct).CurrentValues.SetValues(updatedProduct);

				context.SaveChanges();
				return true;
			}
		}

		/**
		 * Get a list of products that belongs to given catagory
		 */
		public List<Product> GetByCatagory(Catagory catagory)
		{
			using (var context = new ShopDbContext())
			{
				List<Product> products = context.Products
					.Where(p => p.Catagory == catagory).ToList();

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