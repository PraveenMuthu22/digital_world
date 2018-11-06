using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.Enums;

namespace DatabaseProject.Models
{
	public class Product
	{
		public string Id { get; set; }
		public Catagory Catagory { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Specification { get; set; }
		public List<Review> Reviews { get; set; }
	}
}