using FluentResults;
using MediatR;

namespace SalesApi.Application.Commands.SAles
{
    public class CancelSaleCommand : IRequest<Result>
    {
        public CancelSaleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
