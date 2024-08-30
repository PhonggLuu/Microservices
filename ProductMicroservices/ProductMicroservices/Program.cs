using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Models;
using ProductMicroservices.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductDbContext>(
	options => options.UseNpgsql(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		npgsqlOptions => npgsqlOptions.EnableRetryOnFailure()
	).EnableSensitiveDataLogging()
	 .EnableDetailedErrors()
);

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
