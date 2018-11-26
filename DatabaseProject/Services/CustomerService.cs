using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
		public bool Add(Customer customer)
		{
            //validate
		    if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) ||
		        string.IsNullOrEmpty(customer.Password)
		        || string.IsNullOrEmpty(customer.Email))
		    {
                Debug.WriteLine("First name, Last name, password and email cannot be null");
		        return false;
		    }
			using (var context = new ShopDbContext())
			{
				context.Database.Log = Console.WriteLine;
				var response = context.Customers.Add(customer);
				context.SaveChanges();
				return true;
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
                    Debug.WriteLine("No customer with given ID");
					return false;
				}
				context.Customers.Remove(oldCustomer);
				return true;
			}
		}

		/**
		 * Edit given customer
		 */
		public bool Edit(Customer responseCustomer)
		{
		    //validate
		    if (responseCustomer.Id == 0 ||  string.IsNullOrEmpty(responseCustomer.FirstName) || string.IsNullOrEmpty(responseCustomer.LastName) ||
		        string.IsNullOrEmpty(responseCustomer.Password)
		        || string.IsNullOrEmpty(responseCustomer.Email))
		    {
		        Debug.WriteLine("ID, First name, Last name, password and email cannot be null");
		        return false;
		    }

            using (var context = new ShopDbContext())
			{
				//Get Customer. If it doesn't exist return null
				Customer oldCustomer = context.Customers.Find(responseCustomer.Id);
				if (oldCustomer == null)
				{
                    Debug.WriteLine("Customer with given ID doesn't exist");
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
            //validate
            if(string.IsNullOrEmpty(address.City) || string.IsNullOrEmpty(address.LineOne)  || string.IsNullOrEmpty(address.Phone) 
               || string.IsNullOrEmpty(address.Zip) || string.IsNullOrEmpty(address.City) || address.CustomerId == 0)
		    {
                Debug.WriteLine("City, LineOne, Phone, Zip, City and customerId cannot be null");
		    }

            using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(address.CustomerId);
				if (customer == null)
				{
                    Debug.WriteLine("No customer with given id");
					return false;
				}

			    //Add customer reference 
			    address.Customer = customer;


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
				    Debug.WriteLine("No customer with given id");
                    return false;
				}

				Address address = context.Addresses.Find(addressId);
				if (address == null)
				{
				    Debug.WriteLine("No address with given id");
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
				    Debug.WriteLine("No customer with given id");
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
				    Debug.WriteLine("No customer with given id");
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
				    Debug.WriteLine("No customer with given id");
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
				    Debug.WriteLine("No customer with given id");
                    return false;
				}

				Product product = context.Products.Find(productId);
				if (product == null)
				{
				    Debug.WriteLine("No product with given id");
                    return false;
				}

			    Purchase purchase = new Purchase
			    {
                    Date = DateTime.Now,
                    Customer = customer,
                    CustomerId = customerId,
                    Product = product,
                    ProductId = productId,
			    };
           

				customer.Purchases.Add(purchase);
				context.SaveChanges();
				return true;
			}
		}

		public List<Purchase> GetPurchases(int id)
		{
			using (var context = new ShopDbContext())
			{
				Customer customer = context.Customers.Find(id);
				if (customer == null)
				{
				    Debug.WriteLine("No customer with given id");
                    return null;
				}
				
				context.Entry(customer).Collection(c => c.Purchases).Load();
				return customer.Purchases;
			}
		}
	}
}