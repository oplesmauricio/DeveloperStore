using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApi.Infrastructure.Entities
{
    [Table("products")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("image")]
        public string Image { get; set; }
    }
}
