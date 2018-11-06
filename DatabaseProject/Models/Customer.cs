using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public List<Address> Addresses { get; set; }
		public List<Review> Reviews { get; set; }
	}
}