using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using SalesApi.Infrastructure.Persistence;
using SalesApi.Application.DTO.Request;
using SalesApi.Application.DTO.Response;
using AutoMapper;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventLogger _eventLogger;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IEventLogger eventLogger, IMapper mapper)
        {
            _productRepository = productRepository;
            _eventLogger = eventLogger;
            _mapper = mapper;
        }

        public IEnumerable<DTO.Response.ProductDto> GetAllProducts()
        {
            var productsEntity = _productRepository.GetAll();

            //aqui eu posso passar diretamente para dto pois o mapeamento me permite
            return productsEntity.Select(p => _mapper.Map<DTO.Response.ProductDto>(p)).ToList();
        }

        public DTO.Response.ProductDto CreateProduct(DTO.Request.ProductDto productDto)
        {
            var produtct = _mapper.Map<Product>(productDto);

            //efetuar alguma validacao de negocio e mapear para objeto de banco

            //produtct.ValidationExample();

            var produtctEntity = _mapper.Map<ProductEntity>(produtct);
            _productRepository.Add(produtctEntity);

            _eventLogger.Log("SaleCreated");
            return _mapper.Map<SalesApi.Application.DTO.Response.ProductDto>(produtct);
        }
    }
}
