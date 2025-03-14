using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public interface IProductRepository
    {
        void Add(Product sale);
        Product GetById(int saleId);
        IEnumerable<Product> GetAll();
        void Delete(int id);
    }
}
