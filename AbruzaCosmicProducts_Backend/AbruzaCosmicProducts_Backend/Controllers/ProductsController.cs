using AbruzaCosmicProducts_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Product>>> getAllProducts() {
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

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(getAllProducts), new { id = product.Id }, product);
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

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            context.Product.RemoveRange(context.Product);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
