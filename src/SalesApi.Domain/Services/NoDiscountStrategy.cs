using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(int quantity) => quantity < 4;
        public decimal CalculateDiscount(int quantity, decimal unitPrice) => 0;
    }
}
