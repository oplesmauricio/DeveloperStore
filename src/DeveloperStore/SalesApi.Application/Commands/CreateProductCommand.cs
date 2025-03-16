﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using SalesApi.Application.DTO.Request;

namespace SalesApi.Application.Commands
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
