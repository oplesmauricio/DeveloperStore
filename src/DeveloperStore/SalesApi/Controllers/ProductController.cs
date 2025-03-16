using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _productService.GetAllProducts();

                return Ok(new BaseResponse<IEnumerable<ProductDto>>(result.Value, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                //telemmetria ou kibana passando ex
                return StatusCode(500, new BaseErrorResponse("InternalServerError", "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SalesApi.Application.DTO.Request.ProductDto productDto)
        {
            try
            {
                var result = _productService.CreateProduct(productDto);
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
