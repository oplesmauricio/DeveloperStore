using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using SalesApi.Application.DTO.Request;
using SalesApi.Application.DTO.Response;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface ISaleService
    {
        Result<DTO.Response.SaleDto> CreateSale(DTO.Request.SaleDto sale);
        Result CancelSale(int saleId);
        Result<IEnumerable<DTO.Response.SaleDto>> GetAllSales();
    }
}
