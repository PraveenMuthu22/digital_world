using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Stars { get; set; }
		[Required]
		public virtual Product Product { get; set; }
		public int ProductId { get; set; }
		[Required]
		public virtual Customer Customer { get; set; }
		public int CustomerId { get; set; }
	}
}
