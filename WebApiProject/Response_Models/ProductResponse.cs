using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseProject.Enums;
using DatabaseProject.Models;

namespace WebApiProject.View_Models
{
	public class ProductResponse
	{
		public int Id { get; set; }
		public Category Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Specification { get; set; }
	}
}