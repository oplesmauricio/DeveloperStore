using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Interfaces
{
    public interface IProductService
    {
        DTO.Response.ProductDto CreateProduct(DTO.Request.ProductDto product);
        IEnumerable<DTO.Response.ProductDto> GetAllProducts();
    }
}
