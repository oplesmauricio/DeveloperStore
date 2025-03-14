using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTO.Response;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
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
                var products = _productService.GetAllProducts();
                var productsDto = products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
                return Ok(new BaseResponse<List<ProductDto>>(productsDto, "Success", "Operação concluída com sucesso"));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse<List<ProductDto>>(null, "Fail", "Tivemos um problema"));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SalesApi.Application.DTO.Request.ProductDto productDto)
        {
            try
            {
                var produtct = _productService.CreateProduct(_mapper.Map<Product>(productDto));
                var response = _mapper.Map<SalesApi.Application.DTO.Response.ProductDto>(produtct);

                return CreatedAtAction(nameof(Create), new { id = response.Id }, new BaseResponse<SalesApi.Application.DTO.Response.ProductDto>(response, "Success", "Operação concluída com sucesso"));

            }
            catch (Exception)
            {
                return Ok(new BaseResponse<List<ProductDto>>(null, "Fail", "Tivemos um problema"));
            }
        }
    }
}
