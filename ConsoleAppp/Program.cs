using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
		    Database.SetInitializer(new DropCreateDatabaseAlways<ShopDbContext>());
		    ProductService productService = new ProductService();
		    CustomerService customerService = new CustomerService();

            Product p1 = new Product
		    {
		        //Category = Category.COMPUTER,
		        Name = "USB cable",
		        Price = 300,
		    };

		    productService.Add(p1);
		    Console.ReadLine();
		}

		
	}
}