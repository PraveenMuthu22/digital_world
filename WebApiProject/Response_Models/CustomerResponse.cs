using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseProject.Models;

namespace WebApiProject.View_Models
{
	public class CustomerResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public Address DefaultAddress { get; set; }
		public int AddressId { get; set; }
		public List<Address> Addresses { get; set; }
		public List<Review> Reviews { get; set; }
		public List<Product> Products { get; set; }
	}
}