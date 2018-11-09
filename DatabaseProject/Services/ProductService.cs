using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Models;

namespace DatabaseProject.Services
{
	public class ProductService
	{
		//DbSet context = new ShopDbContext().Products;
		public Product Add(Product product)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				var response = context.Products.Add(product);
				context.SaveChanges();
				return response;
			}
		}

		public Product Get(int id)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				return context.Products.Find(id);
			}
		}

		public Product Remove(Product product)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				var response = context.Products.Remove(product);
				context.SaveChanges();
				return response;
			}
		}

		public Product Edit(Product response, int id)
		{
			using (var context = new ShopDbContext())
			{
				//Get product. If it doesn't exist return null
				Product oldProduct = context.Products.Find(id);
				if (oldProduct == null)
				{
					return null;
				}

				Product newProduct = new Product
				{
					Id = oldProduct.Id,
					Catagory = response.Catagory,
					Name = response.Name,
					Description = response.Description,
					Reviews = response.Reviews,
					Specification = response.Specification
				};

				var returned = context.Products.Attach(newProduct);
				context.Entry(newProduct).State = EntityState.Modified;
				context.Database.Log = Console.WriteLine;
				context.SaveChanges();
				return returned;
			}
		}
	}
}