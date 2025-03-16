using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface IProductService
    {
        Result<DTO.Response.ProductDto> CreateProduct(DTO.Request.ProductDto product);
        Result<IEnumerable<DTO.Response.ProductDto>> GetAllProducts();
    }
}
