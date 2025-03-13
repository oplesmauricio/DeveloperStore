using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface ISaleService
    {
        Sale CreateSale(Sale sale);
        Sale CancelSale(int saleId);
        Sale GetSaleById(int saleId);
        IEnumerable<Sale> GetAllSales();
        void DeleteSale(int id);
    }
}
