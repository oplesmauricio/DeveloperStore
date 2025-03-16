using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;

namespace SalesApi.Application.Querys
{
    public class GetAllProductsQuery : IRequest<Result<IEnumerable<DTO.Response.ProductDto>>> { }

}
