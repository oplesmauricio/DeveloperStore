using System.Net;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTO.Request;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.ExtensionMethods;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Services;
using SalesApi.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService) => _saleService = saleService;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _saleService.GetAllSales();
                return Ok(new BaseResponse<IEnumerable<SalesApi.Application.DTO.Response.SaleDto>>(result.Value, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Application.DTO.Request.SaleDto saleDto)
        {
            try
            {
                var result = _saleService.CreateSale(saleDto);

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
                var result = _saleService.CancelSale(id);
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
