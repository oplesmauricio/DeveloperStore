﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Response;

namespace SalesApi.Application.Querys.Products
{
    public class GetAllProductsQuery : IRequest<Result<IEnumerable<ProductDto>>> { }

}
