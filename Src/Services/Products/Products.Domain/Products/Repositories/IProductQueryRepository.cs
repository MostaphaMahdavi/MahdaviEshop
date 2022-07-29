using System.Collections.Generic;
using System.Threading.Tasks;
using Products.Domain.Products.Dtos;
using Products.Domain.Products.Entities;

namespace Products.Domain.Products.Repositories
{
    public interface IProductQueryRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);

        Task<IEnumerable<Product>> GetAllAsNoTrackingAsync();
        Task<Product> GetByIdAsNoTrackingAsync(long id);
    }
}
