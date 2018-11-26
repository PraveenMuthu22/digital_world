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
		public bool Add(Product product)
		{
            //validation
		    if (string.IsNullOrEmpty(product.Name) || product.Price == 0 || product.Category == 0)
		    {
                Debug.WriteLine("Product Name, Price and Catagory cannot be empty");
		        return false;
		    }

		    {

		    }
			using (var context = new ShopDbContext())
			{
			    context.Database.Log = Console.WriteLine;
			    var response = context.Products.Add(product);
			    context.SaveChanges();
			    return true;
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
                    Debug.WriteLine("product with given id doesn't exist");
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
		public bool Edit(Product responseProduct)
		{
		    if (string.IsNullOrEmpty(responseProduct.Name) || responseProduct.Price == 0 || responseProduct.Category == 0 || responseProduct.Id == 0)
		    {
		        Debug.WriteLine("Product name, price and category cannot be null");
                return false;
		    }


            using (var context = new ShopDbContext())
			{
				//Get product. If it doesn't exist return null
				Product oldProduct = context.Products.Find(responseProduct.Id);
				if (oldProduct == null)
				{
                    Debug.WriteLine("Product of given id doesn't exist in database");
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
            //validate
		    if (review.CustomerId == 0 || review.ProductId == 0 || review.Stars == 0 ||
		        string.IsNullOrEmpty(review.Text))
		    {
                Debug.WriteLine("customerId, productId, stars and text cannot be null in review");
		        return false;
		    }

			using (var context = new ShopDbContext())
			{
				Product product = context.Products.Find(review.ProductId);
				if (product == null)
				{
				    Debug.WriteLine("Product of given id doesn't exist in database");
                    return false;
				}

				Customer customer = context.Customers.Find(review.CustomerId);
				if (customer == null)
				{
				    Debug.WriteLine("Customer of given id doesn't exist in database");
                    return false;
				}

                //add customer and product reference to review
			    review.Customer = customer;
			    review.Product = product;

                //Add review to both customer and product objects
                customer.Reviews.Add(review);
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
				    Debug.WriteLine("Product of given id doesn't exist in database");
                    return null;
				}
                context.Entry(oldProduct).Collection(p => p.Reviews).Load();
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