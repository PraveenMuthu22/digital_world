using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Stars { get; set; }
		[Required]
		public Product Product { get; set; }
		[Required]
		public Customer Customer { get; set; }
	}
}
