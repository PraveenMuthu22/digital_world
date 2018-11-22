using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using AutoMapper;
using DatabaseProject.Models;
using DatabaseProject.Models_Updated;

namespace DatabaseProject.Services
{
	public class CustomerService
	{
		/**
		 * Add new customer
		 */
		public Customer Add(Customer customer)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				var response = context.Customers.Add(customer);
				context.SaveChanges();
				return response;
			}
		}

		/**
		 * Get customer of given id
		 */
		public Customer Get(int id)
		{
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				return context.Customers.Find(id);
			}
		}

		/**
		 * Remove given customer
		 */
		public bool Remove(int id)
		{
			using (var context = new ShopDbContext())
			{
				Customer oldCustomer = context.Customers.Find(id);
				if (oldCustomer == null)
				{
					return false;
				}
				context.Customers.Remove(oldCustomer);
				return true;
			}
		}

		/**
		 * Edit given customer
		 */
		public bool Edit(Customer responseCustomer, int id)
		{
			using (var context = new ShopDbContext())
			{
				//Get Customer. If it doesn't exist return null
				Customer oldCustomer = context.Customers.Find(id);
				if (oldCustomer == null)
				{
					return false;
				}

				var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerUpdated>());
				var mapper = config.CreateMapper();
				CustomerUpdated updatedCustomer = mapper.Map<CustomerUpdated>(responseCustomer);

				context.Entry(oldCustomer).CurrentValues.SetValues(updatedCustomer);

				context.SaveChanges();
				return true;
			}
		}

		/**
		 * Add a new address to the customer
		 */
		public bool AddAddress(Address address)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(address.CustomerId);
				if (customer == null)
				{
					return false;
				}
				//If it's the first address, make it default address
				if (customer.Addresses.Count == 0)
				{
					customer.DefaultAddressId = address.Id;
				}

				customer.Addresses.Add(address);
				context.SaveChanges();
				return true;
			}
		}

		public bool SetDefaultAddress(int addressId, int customerId)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(customerId);
				if (customer == null)
				{
					return false;
				}

				Address address = context.Addresses.Find(addressId);
				if (address == null)
				{
					return false;
				}
				customer.DefaultAddressId = address.Id;
				context.SaveChanges();
				return true;
			}
		}

		public Address GetDefaulAddress(int customerId)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(customerId);
				if (customer == null)
				{
					return null;
				}
				return context.Addresses.Find(customer.DefaultAddressId);
			}
		}

		/**
		 * Get list of addresses of given customer
		 */
		//Explicit Loading
		public List<Address> GetAddresses(int id)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(id);
				if (customer == null)
				{
					return null;
				}

				context.Entry(customer).Collection(c => c.Addresses).Load();
				return customer.Addresses;
			}
		}

		//Explicit loading
		public List<Review> GetReviews(int id)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(id);
				if (customer == null)
				{
					return null;
				}
				
				context.Entry(customer).Collection(c => c.Reviews).Load();
				return customer.Reviews;
			}
		}

		public bool AddPurchase(int customerId, int productId)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(customerId);
				if (customer == null)
				{
					return false;
				}

				Product product = context.Products.Find(productId);
				if (product == null)
				{
					return false;
				}

				customer.Products.Add(product);
				context.SaveChanges();
				return true;
			}
		}

		public List<Product> GetPurchases(int id)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(id);
				if (customer == null)
				{
					return null;
				}
				
				context.Entry(customer).Collection(c => c.Products).Load();
				return customer.Products;
			}
		}
	}
}