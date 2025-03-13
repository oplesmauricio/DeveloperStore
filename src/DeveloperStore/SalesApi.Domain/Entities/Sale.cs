using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;

namespace SalesApi.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public decimal TotalValue => Items.Sum(i => i.TotalPrice);
        public string Store { get; set; }
        public List<SaleItem> Items { get; set; } = new();
        public bool IsCanceled { get; set; }

        public void ApplyDiscounts(IEnumerable<IDiscountStrategy> strategies)
        {
            foreach (var item in Items)
            {
                item.ApplyDiscount(strategies);
            }
        }
    }
}
