using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
