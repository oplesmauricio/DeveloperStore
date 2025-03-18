using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesApi.Infrastructure.Entities
{
    [Table("saleitems")]
    public class SaleItemEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Sale")]
        [Column("saleid")]
        public int SaleId { get; set; }

        [Column("productid")]
        public Guid ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Column("discount")]
        public decimal Discount { get; set; }

        [NotMapped]
        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

        [JsonIgnore]
        public SaleEntity? Sale { get; set; }
    }
}
