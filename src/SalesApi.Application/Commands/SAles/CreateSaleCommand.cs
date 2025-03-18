using FluentResults;
using MediatR;
using SalesApi.Application.Commands.Products;

namespace SalesApi.Application.Commands.SAles
{
    public class CreateSaleCommand : IRequest<Result<DTO.Response.SaleDto>>
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItemDto> Items { get; set; } = new List<SaleItemDto>();
    }
}
