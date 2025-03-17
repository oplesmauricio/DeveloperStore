namespace SalesApi.Application.DTO.Response
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Canceled { get; set; }
        public List<SaleItemDto> Items { get; set; } = new List<SaleItemDto>();
    }
}
