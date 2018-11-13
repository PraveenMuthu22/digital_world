using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
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

			ProductService productService = new ProductService();
			CustomerService customerService = new CustomerService();

			List<Product> products = productService.GetProductsByKeyword("mac");
			products.ForEach(p => Debug.WriteLine(p.Name));
			//Console.ReadLine();
		}

		static void InitializeDb()
		{
			ProductService productService = new ProductService();
			CustomerService customerService = new CustomerService();
			Product p = new Product
			{
				Catagory = Catagory.CAMERA,
				Name = "Nikon",
				Description = "Professional Camera",
				Specification = "23 MP",
			};

			Product p1 = new Product
			{
				Catagory = Catagory.COMPUTER,
				Name = "Surface Pro 3",
				Description = "Tablet / Laptop",
				Specification = "i5 16 GB ram",
			};

			Product p2 = new Product
			{
				Catagory = Catagory.COMPUTER,
				Name = "Macbook pro 2015",
				Description = "Laptop",
				Specification = "i5 16 GB ram",
			};

			Product p3 = new Product
			{
				Catagory = Catagory.HEADPHONE_OR_SPEAKER,
				Name = "Senheiser in ear earphones",
				Description = "Dun Dun DUn",
				Specification = "Noize Cancellation",
			};

			Customer c = new Customer
			{
				Email = "jhonny@gmail.com",
				FirstName = "Jhonny",
				LastName = "English",
				Password = "123",
			};


			productService.Add(p);
			productService.Add(p1);
			productService.Add(p2);
			productService.Add(p3);
			customerService.Add(c);

			productService.AddReview(
				new Review
				{
					CustomerId = 1,
					ProductId = 1,
					Stars = 2,
					Text = "It's a good camera",
				});

			customerService.AddAddress(new Address
			{
				LineOne = "11G/1 ",
				LineTwo = "Yokshire Road",
				City = "London",
				Phone = "07123123",
				Zip = "6531",
				CustomerId = 1,
			});


			customerService.AddAddress(new Address
			{
				LineOne = "12/3 ",
				LineTwo = "Stafford Road",
				City = "Colombo",
				Phone = "012345643",
				Zip = "1234",
				CustomerId = 1,
			});

			customerService.AddPurchase(1, 1);
			customerService.AddPurchase(1, 2);


			customerService.SetDefaultAddress(1, 1);
			Debug.WriteLine(customerService.GetDefaulAddress(1).LineOne);
		}
	}
}