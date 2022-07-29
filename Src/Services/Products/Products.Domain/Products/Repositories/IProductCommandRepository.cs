using System;
using System.Threading.Tasks;
using Products.Domain.Products.Entities;

namespace Products.Domain.Products.Repositories
{
    public interface IProductCommandRepository
    {
        Task<Product> AddAsync(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
