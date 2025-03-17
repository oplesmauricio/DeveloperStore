using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface IDiscountStrategy
    {
        bool IsApplicable(int quantity);
        decimal CalculateDiscount(int quantity, decimal unitPrice);
    }
}
