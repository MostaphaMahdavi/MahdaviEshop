using System;
using System.Threading.Tasks;
using Products.DataAccessLayer.Context;
using Products.Domain.Products.Entities;
using Products.Domain.Products.Repositories;

namespace Products.Repository.Products.Impliments
{
    public class ProductCommandRepository: IProductCommandRepository
    {
       private readonly MahdaviContext _db;
        public ProductCommandRepository(MahdaviContext db)
        {
            _db = db;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            return product;
        }

        public void Delete(Product product)=>        
            _db.Products.Remove(product);
        

        public Product Update(Product product)
        {
             _db.Products.Update(product);
            return product;
        }
    }
}
