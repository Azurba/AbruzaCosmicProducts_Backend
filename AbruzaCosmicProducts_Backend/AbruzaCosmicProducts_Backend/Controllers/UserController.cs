using AbruzaCosmicProducts_Backend.Model;
using AbruzaCosmicProducts_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AbruzaCosmicProducts_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly AbruzaDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(AbruzaDBContext context, IConfiguration configuration, IUserService userService)
        {
            _context = context;
            _configuration = configuration;
            _userService = userService;
        }

        //                                     ==== Authentication user operations ====

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<string>> GetMe()
        {
            var Email = _userService.GetMyEmail();
            return Ok(Email);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
        {
            //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, "Admin")
        };

            byte[] key = GenerateHmacSha512Key();

            var symmetricKey = new SymmetricSecurityKey(key);

            //Here we're creating the JWT token passing the claims, the credential and the expiration time (1 day)
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512)
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        //This creates a key with minimum size of 512, as required by the documentation
        private byte[] GenerateHmacSha512Key()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[64]; // 64 bytes = 512 bits
                rng.GetBytes(key);
                return key;
            }
        }


        //                                      ==== General user operations ====

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _context.User.ToListAsync());
        }

        //[HttpPost("users")]
        //public async Task<ActionResult<User>> AddUser(User user)
        //{
        //    _context.User.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        //}

        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> SearchUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("users")]
        public async Task<ActionResult> DeleteAllUsers()
        {
            _context.User.RemoveRange(_context.User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
