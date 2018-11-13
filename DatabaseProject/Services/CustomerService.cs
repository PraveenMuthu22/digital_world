﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using DatabaseProject.Models;

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
		public bool Remove(Customer Customer)
		{
			using (var context = new ShopDbContext())
			{
				Customer oldCustomer = context.Customers.Find(Customer.Id);
				if (oldCustomer == null)
				{
					return false;
				}
				context.Customers.Remove(Customer);
				return true;
			}
		}

		/**
		 * Edit given customer
		 */
		public bool Edit(Customer updatedCustomer, int id)
		{
			using (var context = new ShopDbContext())
			{
				//Get Customer. If it doesn't exist return null
				Customer oldCustomer = context.Customers.Find(id);
				if (oldCustomer == null)
				{
					return false;
				}

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

				//Add customer reference to address
				address.Customer = customer;

				//If it's the first address, make it default address
				if (customer.Addresses.Count == 0)
				{
					customer.DefaultAddress = address;
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

				customer.DefaultAddress = address;
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

				context.Entry(customer).Reference(c => c.DefaultAddress).Load();

				return customer.DefaultAddress;
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