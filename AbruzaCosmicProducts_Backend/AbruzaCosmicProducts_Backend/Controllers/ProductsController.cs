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
    }
}
