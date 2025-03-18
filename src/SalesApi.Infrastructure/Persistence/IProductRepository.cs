using SalesApi.Infrastructure.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public interface IProductRepository
    {
        void Add(ProductEntity sale);
        IEnumerable<ProductEntity> GetAll();
        void Delete(int id);
    }
}
