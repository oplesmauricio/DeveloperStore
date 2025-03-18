using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands.SAles;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Domain.Notifications.Sales;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;
using SalesApi.Infrastructure.Entities;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Handlers.Sale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Result<SaleDto>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;
        private readonly IEnumerable<IQuantityValidationStrategy> _quantityValidationStrategies;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateSaleHandler(ISaleRepository saleRepository, IEnumerable<IDiscountStrategy> discountStrategies, IEnumerable<IQuantityValidationStrategy> quantityValidationStrategies, IMapper mapper, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _discountStrategies = discountStrategies;
            _quantityValidationStrategies = quantityValidationStrategies;
            _mapper = mapper;
            _mediator = mediator;
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

            await _mediator.Publish(new CreatedSaleNotification { Sale = sale });

            return _mapper.Map<SaleDto>(saleEntity);
        }
    }
}
