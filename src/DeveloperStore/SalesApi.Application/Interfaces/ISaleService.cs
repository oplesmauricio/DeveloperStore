using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Application.DTO.Request;
using SalesApi.Application.DTO.Response;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface ISaleService
    {
        DTO.Response.SaleDto CreateSale(DTO.Request.SaleDto sale);
        void CancelSale(int saleId);
        IEnumerable<DTO.Response.SaleDto> GetAllSales();
    }
}
