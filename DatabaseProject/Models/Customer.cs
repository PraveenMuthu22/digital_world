using System.Collections.Generic;

namespace DatabaseProject.Models
{
	public class Customer
	{
		public Customer()
		{
			Addresses = new List<Address>();
			Reviews = new List<Review>();
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public virtual Address DefaultAddress { get; set; }
		public int AddressId { get; set; }
		public List<Address> Addresses { get; set; }
		public List<Review> Reviews { get; set; }
		public List<Product> Products { get; set; }
	}
}