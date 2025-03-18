using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Commands.Products;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Querys.Products;

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEventLogger _logger;

        public ProductController(IMediator mediator, IEventLogger eventLogger)
        {
            _mediator = mediator;
            _logger = eventLogger;
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
                _logger.Log(ex);
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
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }
    }
}
