using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;
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
