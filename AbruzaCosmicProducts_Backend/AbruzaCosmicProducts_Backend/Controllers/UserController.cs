using AbruzaCosmicProducts_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbruzaCosmicProducts_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AbruzaDBContext context;

        public UserController(AbruzaDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllUsers ()
        {
            return Ok(await context.User.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            context.User.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> SearchUser(int id)
        {
            var user = await context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            var user = await context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            context.User.Remove(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            context.User.RemoveRange(context.User);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
