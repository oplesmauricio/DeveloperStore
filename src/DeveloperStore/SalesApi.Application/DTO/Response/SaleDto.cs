﻿namespace SalesApi.Application.DTO.Response
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItemDto> Items { get; set; } = new List<SaleItemDto>();
        public bool IsCanceled { get; set; }
    }
}
