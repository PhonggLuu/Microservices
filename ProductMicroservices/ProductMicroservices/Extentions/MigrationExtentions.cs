using ProductMicroservices.Repositories;

namespace ProductMicroservices.Extentions
{
	public static class MigrationExtentions
	{
		public static void ApplyMigrations(this IApplicationBuilder app)
		{
			//using IScopeService scope = app.ApplicationServices.CreateScope();
		}
	}
}
