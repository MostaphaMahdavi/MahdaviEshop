using Products.DataAccessLayer.Context;
using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWorks;
using Products.Repository.Products.Impliments;

namespace Products.Repository.UnitOfWorks
{
    public class QueryUnitOfWork : IQUeryUnitOfWork
    {
        private readonly MahdaviContext _db;
        public QueryUnitOfWork(MahdaviContext db)
        {
            _db = db;
        }

        private IProductQueryRepository _productQueryRepository;
        public IProductQueryRepository ProductQueryRepository
        {
            get
            {
                return _productQueryRepository ?? new ProductQueryRepository(_db);
            }
        }
    }
}
