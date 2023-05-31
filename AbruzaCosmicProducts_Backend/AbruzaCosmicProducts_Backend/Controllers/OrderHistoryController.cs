using AbruzaCosmicProducts_Backend.Model;
using AbruzaCosmicProducts_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbruzaCosmicProducts_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        //                                      === OrderHistory related methods ===

        public static OrderHistory orderHistory = new OrderHistory();
        private readonly AbruzaDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public OrderHistoryController(AbruzaDBContext context, IConfiguration configuration, IUserService userService)
        {
            _context = context;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderHistory>>> GetAllOrdersHistory()
        {
            return Ok(await _context.OrderHistory.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> AddOrderHistory(OrderHistory orderHistory)
        {
            try
            {
                _context.OrderHistory.Add(orderHistory);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to add order history: {ex.Message}");
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<List<OrderHistory>>> GetOrderHistoryByEmail(string email)
        {
            try
            {
                var orderHistory = await _context.OrderHistory
                    .Where(o => o.Email == email)
                    .ToListAsync();

                return Ok(orderHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve order history by email: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                _context.OrderHistory.RemoveRange(_context.OrderHistory);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete all order history: {ex.Message}");
            }
        }

    }
}

