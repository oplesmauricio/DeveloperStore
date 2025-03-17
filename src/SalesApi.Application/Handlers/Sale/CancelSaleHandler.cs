using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using MediatR;
using SalesApi.Application.Commands.Products;
using SalesApi.Application.Commands.SAles;
using SalesApi.Application.DTO.Response;
using SalesApi.Domain.Services.Validations;
using SalesApi.Domain.Services;
using SalesApi.Infrastructure.Persistence;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Infrastructure.Entities;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Handlers.Sale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, Result>
    {
        private readonly ISaleRepository _saleRepository;

        public CancelSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Result> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = _saleRepository.GetById(request.Id);
            if (sale == null)
                return Result.Fail("Nao existe venda sob este id no sistema");
            sale.IsCanceled = true;
            _saleRepository.Update(sale);

            return Result.Ok();
        }
    }
}
