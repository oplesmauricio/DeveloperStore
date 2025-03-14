using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;
using System.Text.Json.Serialization;

namespace SalesApi.Domain.Entities
{
    [Table("saleitems")]
    public class SaleItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [ForeignKey("Sale")]
        [Column("saleid")]
        public int SaleId { get; set; }

        [Column("productid")]
        public int ProductId { get; set; }

        [Column("productdescription")]
        public string ProductDescription { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Column("discount")]
        public decimal Discount { get; private set; }

        [NotMapped]
        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

        [JsonIgnore]
        public Sale? Sale { get; set; }

        public void ApplyDiscount(IEnumerable<IDiscountStrategy> strategies)
        {
            foreach (var strategy in strategies)
            {
                if (strategy.IsApplicable(Quantity))
                {
                    Discount = strategy.CalculateDiscount(Quantity, UnitPrice);
                    break;
                }
            }
        }
    }
}
