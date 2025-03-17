using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public interface ISaleRepository
    {
        void Add(SaleEntity sale);
        void Update(SaleEntity sale);
        SaleEntity GetById(int saleId);
        IEnumerable<SaleEntity> GetAll();
        void Delete(int id);
    }
}
