using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;

namespace SalesApi.Domain.Entities
{
    [Table("sales")]
    public class Sale
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("saledate")]
        public DateTime SaleDate { get; set; }

        [Column("customer")]
        public string Customer { get; set; }

        [NotMapped] 
        public decimal TotalValue => Items.Sum(i => i.TotalPrice);

        [Column("store")]
        public string Store { get; set; }

        public List<SaleItem> Items { get; set; } = new();

        [Column("iscanceled")]
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
