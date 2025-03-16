using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;
using SalesApi.Infrastructure.Entities;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEventLogger _eventLogger;
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;
        private readonly IEnumerable<IQuantityValidationStrategy> _quantityValidationStrategies;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IEventLogger eventLogger, IEnumerable<IDiscountStrategy> discountStrategies, IMapper mapper, IEnumerable<IQuantityValidationStrategy> quantityValidationStrategies)
        {
            _saleRepository = saleRepository;
            _eventLogger = eventLogger;
            _discountStrategies = discountStrategies;
            _mapper = mapper;
            _quantityValidationStrategies = quantityValidationStrategies;
        }

        public Result<DTO.Response.SaleDto> CreateSale(DTO.Request.SaleDto saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);
            
            var resultValidation = sale.QuantityValidation(_quantityValidationStrategies);
            if (resultValidation.IsFailed)
                return Result.Fail(new BusinessError(System.Net.HttpStatusCode.BadRequest, "Invalid Sell", resultValidation.Errors.Serialization().ToString()));
            
            sale.ApplyDiscounts(_discountStrategies);

            var saleEntity = _mapper.Map<SaleEntity>(sale);
            _saleRepository.Add(saleEntity);

            _eventLogger.Log("SaleCreated");
            
            return _mapper.Map<SaleDto>(saleEntity);
        }

        public Result CancelSale(int saleId)
        {
            var sale = _saleRepository.GetById(saleId);
            if (sale == null)
                return Result.Fail("Nao existe venda sob este id no sistema");
            sale.IsCanceled = true;
            _saleRepository.Update(sale);
            _eventLogger.Log("SaleCanceled");

            return Result.Ok();
        }

        public Result<IEnumerable<DTO.Response.SaleDto>> GetAllSales()
        {
            var salesEntity = _saleRepository.GetAll();

            return salesEntity.Select(p => _mapper.Map<DTO.Response.SaleDto>(p)).ToList();
        }
    }
}
