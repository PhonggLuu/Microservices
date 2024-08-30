using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductByID(int productId);
		void InsertProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int productId);
		void Save();
	}
}
