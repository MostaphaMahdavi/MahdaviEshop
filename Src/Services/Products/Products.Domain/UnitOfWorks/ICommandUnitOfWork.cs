using System;
using System.Threading.Tasks;
using Products.Domain.Products.Repositories;

namespace Products.Domain.UnitOfWorks
{
    public interface ICommandUnitOfWork
    {
        public IProductCommandRepository ProductCommandRepository { get;}


        Task SaveAsync();
    }
}
