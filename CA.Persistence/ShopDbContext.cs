using CA.Application.Interfaces;
using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CA.Persistence
{
    public class ShopDbContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ShopDbContext()
        : base()
        {
        }
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
