using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Commands.SAles;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Application.Querys.SAles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SalesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllSalesQuery());
                return Ok(new BaseResponse<IEnumerable<SalesApi.Application.DTO.Response.SaleDto>>(result.Value, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                    return CreatedAtAction(nameof(GetAll), new BaseResponse<Application.DTO.Response.SaleDto>(result.Value, "Success", "Operação concluída com sucesso"));

                var error = result.Errors.FirstOrDefault();
                var httpCodeResponse = error.Metadata[nameof(HttpStatusCode)];
                var errorMainMsg = error.Metadata["error"];

                return StatusCode((int)httpCodeResponse, new BaseErrorResponse(httpCodeResponse.ToString(), errorMainMsg.ToString(), result.Errors.Serialization().ToString()));
            }
            catch (Exception)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var command = new CancelSaleCommand(id);
                var result = _mediator.Send(command);
                return Ok(new BaseResponse<SalesApi.Application.DTO.Response.SaleDto>(null, "Success", "Venda cancelada com sucesso"));
            }
            catch (Exception)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }
    }
}
