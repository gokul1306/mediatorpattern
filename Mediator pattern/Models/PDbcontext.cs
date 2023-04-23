using Microsoft.EntityFrameworkCore;

namespace Mediator_pattern.Models
{
    public class PDbcontext : DbContext
    {
         public PDbcontext(DbContextOptions<PDbcontext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } 
        public DbSet<User> User{ get; set; }
        public DbSet<Bidding> Bidding{ get; set; }
    }
}