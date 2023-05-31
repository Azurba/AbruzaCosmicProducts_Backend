using AbruzaCosmicProducts_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbruzaCosmicProducts_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AbruzaDBContext context;

        public ProductsController(AbruzaDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await context.Product.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> SearchProduct(int id)
        {
            var product = await context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("type/{productType}")]
        public async Task<ActionResult<List<Product>>> GetProductsByType(string productType)
        {
            var products = await context.Product.Where(p => p.Type == productType).ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
        }

        [HttpPost("multiple")]
        public IActionResult AddMultipleProducts([FromBody] List<Product> products)
        {
            try
            {
                // Check if the products list is null or empty
                if (products == null || products.Count == 0)
                {
                    return BadRequest("No products provided");
                }

                // Your logic to add the products to the database goes here
                foreach (var product in products)
                {
                    // Perform necessary operations to add the product to the database
                    // This could include validation, mapping, and saving to the database context
                    context.Product.Add(product);
                }

                // Save changes to the database
                context.SaveChanges();

                // Return a success response
                return Ok("Products added successfully");
            }
            catch (Exception ex)
            {
                // If an exception occurs during the process, return an error response
                return StatusCode(500, $"An error occurred while adding products: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductById(int id)
        {
            var product = await context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            context.Product.Remove(product);
            await context.SaveChangesAsync();

            return Ok(product);
        }

        //[HttpDelete]
        //public async Task<ActionResult> DeleteAll()
        //{
        //    context.Product.RemoveRange(context.Product);
        //    await context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
