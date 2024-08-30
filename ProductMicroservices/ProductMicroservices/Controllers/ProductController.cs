using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Models;
using ProductMicroservices.Repositories;

namespace ProductMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return new OkObjectResult(product);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult PutProduct([FromBody] Product product)
		{
            if (product != null)
            {
				using(var scope = new TransactionScope())
                {
					_productRepository.UpdateProduct(product);
					scope.Complete();
					return new OkResult();
				}
			}

            return new NoContentResult();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using(var scope = new TransactionScope())
			{
				_productRepository.InsertProduct(product);
				scope.Complete();
				return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
			}
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
