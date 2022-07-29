using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.DataAccessLayer.Context;
using Products.Domain.Products.Entities;
using Products.Domain.Products.Repositories;

namespace Products.Repository.Products.Impliments
{
    public class ProductQueryRepository: IProductQueryRepository
    {

        private readonly MahdaviContext _db;

        public ProductQueryRepository(MahdaviContext db)
        {
            _db = db;
        }    

        public async Task<IEnumerable<Product>> GetAllAsync()=>        
           await _db.Products.Include(c=>c.Category).ToListAsync();
       

        public async Task<Product> GetByIdAsync(long id)=>        
             await _db.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
        

        public async Task<IEnumerable<Product>> GetAllAsNoTrackingAsync()=>        
             await _db.Products.Include(c => c.Category).AsNoTracking().ToListAsync();
        

        public async Task<Product> GetByIdAsNoTrackingAsync(long id)=>        
             await _db.Products.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        
    }
}
