using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;

namespace SalesApi.Infrastructure.Entities
{
    [Table("sales")]
    public class SaleEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("saledate")]
        public DateTime SaleDate { get; set; }

        [Column("salenumber")]
        public string SaleNumber { get; set; }

        [Column("customer")]
        public Guid CustomerId { get; set; }

        [NotMapped] 
        public decimal TotalValue => Items.Sum(i => i.TotalPrice);

        [Column("store")]
        public Guid BranchId { get; set; }

        public List<SaleItemEntity> Items { get; set; } = new();

        [Column("iscanceled")]
        public bool IsCanceled { get; set; }
    }
}
