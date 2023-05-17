using AbruzaCosmicProducts_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace AbruzaCosmicProducts_Backend
{
    public class AbruzaDBContext : DbContext
    {
        public AbruzaDBContext(DbContextOptions<AbruzaDBContext>options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserCart> UserCart { get; set; }


    }
}
