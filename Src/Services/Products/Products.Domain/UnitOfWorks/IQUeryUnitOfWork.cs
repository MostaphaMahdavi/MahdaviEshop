using Products.Domain.Products.Repositories;

namespace Products.Domain.UnitOfWorks
{
    public interface IQUeryUnitOfWork
    {
        public IProductQueryRepository ProductQueryRepository { get; }
    }
}
