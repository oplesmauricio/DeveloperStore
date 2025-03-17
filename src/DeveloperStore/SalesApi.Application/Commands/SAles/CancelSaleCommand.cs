using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands.Products;

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
