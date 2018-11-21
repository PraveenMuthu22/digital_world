using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Models;

namespace DatabaseProject.Models_Updated
{
	class CustomerUpdated
	{
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
