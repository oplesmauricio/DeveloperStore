using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands.Products;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Notifications;
using SalesApi.Infrastructure.Entities;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
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

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var produtct = _mapper.Map<Domain.Entities.Product>(request);

            //efetuar alguma validacao de negocio e mapear para objeto de banco
            //produtct.ValidationExample();

            var produtctEntity = _mapper.Map<ProductEntity>(produtct);
            _productRepository.Add(produtctEntity);

            await _mediator.Publish(new ProductCreatedNotification { Product = produtct });

            return _mapper.Map<ProductDto>(produtctEntity);
        }
    }
}
