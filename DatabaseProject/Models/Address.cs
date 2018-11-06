using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string LineOne { get; set; }
		public string LineTwo { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		[Required]
		public Customer Customer { get; set; }
	}
}