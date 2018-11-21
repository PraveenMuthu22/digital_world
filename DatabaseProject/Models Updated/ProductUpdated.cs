using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Enums;
using DatabaseProject.Models;

namespace DatabaseProject.Models_Updated
{
	class ProductUpdated
	{
		public Category Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Specification { get; set; }
		public List<Review> Reviews { get; set; }
		public List<Customer> Customers { get; set; }
	}
}
