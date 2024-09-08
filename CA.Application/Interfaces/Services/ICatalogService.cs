namespace CA.Application.Interfaces;

using CA.Application.Models;
using CA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface ICatalogService
{
    Task<IEnumerable<Product>> GetCatalog();
    Task<IEnumerable<Product>> GetCatalogByCategory(string category);
    Task<Product> GetCatalog(Guid id);
}
