using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;

namespace SalesApi.Application.Querys.SAles
{
    public class GetAllSalesQuery : IRequest<Result<IEnumerable<SaleDto>>>
    {
    }
}
