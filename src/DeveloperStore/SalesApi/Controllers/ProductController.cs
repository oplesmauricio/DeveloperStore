using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Commands;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Querys;
using SalesApi.Domain.Entities;

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProductsQuery());

                return Ok(new BaseResponse<IEnumerable<ProductDto>>(result.Value, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand productDto)
        {
            try
            {
                var result = await _mediator.Send(productDto);
                return CreatedAtAction(nameof(GetAll), new BaseResponse<SalesApi.Application.DTO.Response.ProductDto>(result.Value, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }
    }
}
