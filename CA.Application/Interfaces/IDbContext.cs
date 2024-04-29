using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}
