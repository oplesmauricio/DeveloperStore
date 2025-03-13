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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEventLogger _eventLogger;
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;

        public SaleService(ISaleRepository saleRepository, IEventLogger eventLogger, IEnumerable<IDiscountStrategy> discountStrategies)
        {
            _saleRepository = saleRepository;
            _eventLogger = eventLogger;
            _discountStrategies = discountStrategies;
        }

        public Sale CreateSale(Sale sale)
        {
            sale.ApplyDiscounts(_discountStrategies);
            _saleRepository.Add(sale);
            _eventLogger.Log("SaleCreated");
            return sale;
        }

        public Sale CancelSale(int saleId)
        {
            var sale = _saleRepository.GetById(saleId);
            if (sale == null) throw new Exception("Sale not found");
            sale.IsCanceled = true;
            _saleRepository.Update(sale);
            _eventLogger.Log("SaleCanceled");
            return sale;
        }

        public Sale GetSaleById(int saleId) => _saleRepository.GetById(saleId);
        public IEnumerable<Sale> GetAllSales() => _saleRepository.GetAll();

        public void UpdateSale(Sale sale)
        {
            sale.ApplyDiscounts(_discountStrategies);
            _eventLogger.Log("UpdateSale");
            _saleRepository.Update(sale);
        }

        public void DeleteSale(int id)
        {
            _eventLogger.Log($"DeleteSale - Id:{id}");
            _saleRepository.Delete(id);
        }
    }
}
