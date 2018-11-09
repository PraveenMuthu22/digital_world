using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;

namespace ConsoleAppp
{
	class Program
	{
		static void Main(string[] args)
		{
			//InitializeDb();
			Product p = new Product
			{
				Id = "1",
				Catagory = Catagory.CAMERA,
				Name = "Nikon",
				Description = "This is a Camera",
				Specification = "15 MP",
				Reviews = new List<Review>()
			};

			
			ProductService productService = new ProductService();
			productService.Add(p);
		}

		static void InitializeDb()
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<ShopDbContext>());
		}
	}
}
