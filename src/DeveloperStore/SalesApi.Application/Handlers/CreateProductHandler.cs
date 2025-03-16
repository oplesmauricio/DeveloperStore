using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands;
using SalesApi.Application.DTO.Request;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Notifications;
using SalesApi.Infrastructure.Entities;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<DTO.Response.ProductDto>>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMediator mediator, IMapper mapper)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Result<DTO.Response.ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var produtct = _mapper.Map<Product>(request);

            //efetuar alguma validacao de negocio e mapear para objeto de banco
            //produtct.ValidationExample();

            var produtctEntity = _mapper.Map<ProductEntity>(produtct);
            _productRepository.Add(produtctEntity);

            await _mediator.Publish(new ProductCreatedNotification { Product = produtct });
            
            return _mapper.Map<SalesApi.Application.DTO.Response.ProductDto>(produtctEntity);
        }
    }
}
