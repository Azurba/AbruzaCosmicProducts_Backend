using AbruzaCosmicProducts_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace AbruzaCosmicProducts_Backend
{
    public class AbruzaDBContext : DbContext
    {
        public AbruzaDBContext(DbContextOptions<AbruzaDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderHistory>()
                .Property(e => e.Total)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderHistory>()
                .HasMany(o => o.Products)
                .WithMany() // Many-to-many relationship
                .UsingEntity(join => join.ToTable("OrderHistoryProduct")); // Create a junction table named "OrderHistoryProduct"
        }




    }

}
