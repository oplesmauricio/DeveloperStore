using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesApi.Application.DTO.Request
{
    public class SaleDto
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItemDto> Items { get; set; } = new List<SaleItemDto>();
    }
}
