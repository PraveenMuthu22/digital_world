using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseProject.Models
{
	public class Review
	{
		public int Id { get; set; }
	    [Required] public string Text { get; set; }
	    [Required] public int Stars { get; set; }

		[Required] public Product Product { get; set; }
		public int ProductId { get; set; }

		[Required] public Customer Customer { get; set; }
		public int CustomerId { get; set; }
	}
}