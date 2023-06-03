using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }
}
