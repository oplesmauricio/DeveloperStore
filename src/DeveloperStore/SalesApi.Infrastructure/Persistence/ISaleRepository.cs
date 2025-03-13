using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        void Update(Sale sale);
        Sale GetById(int saleId);
        IEnumerable<Sale> GetAll();
        void Delete(int id);
    }
}
