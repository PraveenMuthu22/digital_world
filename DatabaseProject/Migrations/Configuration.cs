using System.Diagnostics;
using DatabaseProject.Enums;
using DatabaseProject.Models;
using DatabaseProject.Services;

namespace DatabaseProject.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
			ProductService productService = new ProductService();
	        CustomerService customerService = new CustomerService();
	        Product p = new Product
	        {
		        Category = Category.CAMERA,
		        Name = "Nikon",
		        Description = "Professional Camera",
		        Specification = "23 MP",
	        };

	        Product p1 = new Product
	        {
		        Category = Category.COMPUTER,
		        Name = "Surface Pro 3",
		        Description = "Tablet / Laptop",
		        Specification = "i5 16 GB ram",
	        };

	        Product p2 = new Product
	        {
		        Category = Category.COMPUTER,
		        Name = "Macbook pro 2015",
		        Description = "Laptop",
		        Specification = "i5 16 GB ram",
	        };

	        Product p3 = new Product
	        {
		        Category = Category.HEADPHONE_OR_SPEAKER,
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

	        Customer c2 = new Customer
	        {
		        Email = "bob@gmail.com",
		        FirstName = "Bob",
		        LastName = "Jordan",
		        Password = "234",
	        };


			productService.Add(p);
	        productService.Add(p1);
	        productService.Add(p2);
	        productService.Add(p3);
	        customerService.Add(c);
	        customerService.Add(c2);


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

            customerService.SetDefaultAddress(1, 1);

            customerService.AddPurchase(1, 1);
	        customerService.AddPurchase(1, 2);



		}
    }
}
