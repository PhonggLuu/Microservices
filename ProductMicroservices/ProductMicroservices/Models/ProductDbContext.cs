using Microsoft.EntityFrameworkCore;

namespace ProductMicroservices.Models
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Ánh xạ tên bảng và schema chính xác
			modelBuilder.Entity<Product>().ToTable("Products", "public");
		}
	}
}
