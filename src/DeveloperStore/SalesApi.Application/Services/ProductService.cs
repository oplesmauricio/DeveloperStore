using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventLogger _eventLogger;

        public ProductService(IProductRepository productRepository, IEventLogger eventLogger)
        {
            _productRepository = productRepository;
            _eventLogger = eventLogger;
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();

        public Product CreateProduct(Product product)
        {
            _productRepository.Add(product);
            _eventLogger.Log("SaleCreated");
            return product;
        }
    }
}
