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
        Product CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
    }
}
