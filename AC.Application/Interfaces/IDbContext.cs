using AC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AC.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }
}
