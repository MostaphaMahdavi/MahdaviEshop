using System;
using System.Threading.Tasks;
using Products.DataAccessLayer.Context;
using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWorks;
using Products.Repository.Products.Impliments;

namespace Products.Repository.UnitOfWorks
{
    public class CommandUnitOfWork: ICommandUnitOfWork
    {
       private readonly MahdaviContext _db;
        public CommandUnitOfWork(MahdaviContext db)
        {
            _db = db;
        }

        private IProductCommandRepository _productCommandRepository;
        public IProductCommandRepository ProductCommandRepository { get { 
             return   _productCommandRepository?? new ProductCommandRepository(_db);
            } }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
