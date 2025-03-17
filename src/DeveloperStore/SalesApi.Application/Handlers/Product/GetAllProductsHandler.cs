using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Querys.Products;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Handlers.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsEntity = _productRepository.GetAll();

            //aqui eu posso passar diretamente para dto pois o mapeamento me permite
            return productsEntity.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }
    }

}
