using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public IActionResult GetAll() => Ok(_productService.GetAllProducts());

        [HttpPost]
        public IActionResult Create([FromBody] Product sale)
        {
            _productService.CreateProduct(sale);
            return CreatedAtAction(nameof(Create), new { id = sale.Id }, sale);
        }
    }
}
