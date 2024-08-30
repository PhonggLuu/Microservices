using System.ComponentModel;

namespace ProductMicroservices.Models
{
	public class Product
	{
		[DisplayName("Product Id")]
		public int Id { get; set; }
		[DisplayName("Product Name")]
		public string? Name { get; set; }
		[DisplayName("Product Description")]
		public string? Description { get; set; }
		[DisplayName("Product Price")]
		public decimal Price { get; set; }
	}
}
