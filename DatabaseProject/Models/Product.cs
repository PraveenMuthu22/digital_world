using System.Collections.Generic;
using DatabaseProject.Enums;

namespace DatabaseProject.Models
{
	public class Product
	{
		public Product()
		{
			Reviews = new List < Review >();
		}

		public int Id { get; set; }
		public Catagory Catagory { get; set; }
		public string Name { get; set; }  
		public string Description { get; set; }
		public string Specification { get; set; }
		public List<Review> Reviews { get; set; }
		public List<Customer> Customers { get; set; }
	}
}