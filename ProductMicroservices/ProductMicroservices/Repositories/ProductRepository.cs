using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductDbContext _context;
		public ProductRepository(ProductDbContext context)
		{
			_context = context;
		}
		public void DeleteProduct(int id)
		{
			var product = _context.Products.Find(id);
			_context.Products.Remove(product);
			Save();
		}

		public Product GetProductByID(int productId)
		{
			return _context.Products.Find(productId);
		}

		public IEnumerable<Product> GetProducts()
		{
			return _context.Products.ToList();
		}

		public void InsertProduct(Product product)
		{
			_context.Products.Add(product);
			Save();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			_context.Entry(product).State = EntityState.Modified;
			Save();
		}
	}
}
