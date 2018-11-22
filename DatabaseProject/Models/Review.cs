using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseProject.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Stars { get; set; }

		[Required] public Product product { get; set; }
		public int ProductId { get; set; }

		[Required] public Customer Customer { get; set; }
		public int CustomerId { get; set; }
	}
}