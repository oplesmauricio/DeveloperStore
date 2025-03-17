using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;
using FluentResults;
using SalesApi.Domain.Services.Validations;

namespace SalesApi.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public string SaleNumber { get; set; }

        public DateTime SaleDate { get; set; }

        public Guid CustomerId { get; set; }

        public decimal TotalValue => Items.Sum(i => i.TotalPrice);

        public Guid BranchId { get; set; }

        public List<SaleItem> Items { get; set; } = new();

        public bool IsCanceled { get; set; }

        public void ApplyDiscounts(IEnumerable<IDiscountStrategy> strategies)
        {
            foreach (var item in Items)
            {
                item.ApplyDiscount(strategies);
            }
        }

        public Result QuantityValidation(IEnumerable<IQuantityValidationStrategy> strategies)
        {
            foreach (var item in Items)
            {
                var result = item.QuantityValidation(strategies);

                if (result.IsFailed)
                    return result;
            }

            return Result.Ok();
        }
    }
}
