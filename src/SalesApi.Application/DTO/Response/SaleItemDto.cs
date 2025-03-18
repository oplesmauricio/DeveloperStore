namespace SalesApi.Application.DTO.Response
{
    public class SaleItemDto
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int SaleId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
