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
                return Ok(new BaseResponse<IEnumerable<ProductDto>>(_productService.GetAllProducts(), "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse<IEnumerable<ProductDto>>(null, "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SalesApi.Application.DTO.Request.ProductDto productDto)
        {
            try
            {
                var produtct = _productService.CreateProduct(productDto);
                return CreatedAtAction(nameof(GetAll), new BaseResponse<SalesApi.Application.DTO.Response.ProductDto>(produtct, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception)
            {
                return Ok(new BaseResponse<List<ProductDto>>(null, "Fail", "Tivemos um problema"));
            }
        }
    }
}
