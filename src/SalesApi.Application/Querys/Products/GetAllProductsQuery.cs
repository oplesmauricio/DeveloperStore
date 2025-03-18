using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;

namespace SalesApi.Application.Querys.Products
{
    public class GetAllProductsQuery : IRequest<Result<IEnumerable<ProductDto>>> { }

}
