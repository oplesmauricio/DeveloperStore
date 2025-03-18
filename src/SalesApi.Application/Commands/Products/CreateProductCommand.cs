using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace SalesApi.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<Result<DTO.Response.ProductDto>>
    {
        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "The price is required.")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
