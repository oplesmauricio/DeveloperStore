using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands.Products;
using SalesApi.Application.Commands.SAles;
using SalesApi.Application.DTO.Response;
using SalesApi.Domain.Services.Validations;
using SalesApi.Domain.Services;
using SalesApi.Infrastructure.Persistence;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Application.Handlers.Sale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Result<SaleDto>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;
        private readonly IEnumerable<IQuantityValidationStrategy> _quantityValidationStrategies;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IEnumerable<IDiscountStrategy> discountStrategies, IEnumerable<IQuantityValidationStrategy> quantityValidationStrategies, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _discountStrategies = discountStrategies;
            _quantityValidationStrategies = quantityValidationStrategies;
            _mapper = mapper;
        }

        public async Task<Result<SaleDto>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = _mapper.Map<Domain.Entities.Sale>(request);

            var resultValidation = sale.QuantityValidation(_quantityValidationStrategies);
            if (resultValidation.IsFailed)
                return Result.Fail(new BusinessError(System.Net.HttpStatusCode.BadRequest, "Invalid Sell", resultValidation.Errors.Serialization().ToString()));

            sale.ApplyDiscounts(_discountStrategies);

            var saleEntity = _mapper.Map<SaleEntity>(sale);
            _saleRepository.Add(saleEntity);

            return _mapper.Map<SaleDto>(saleEntity);
        }
    }
}
