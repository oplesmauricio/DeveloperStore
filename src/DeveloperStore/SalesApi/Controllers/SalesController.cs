using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService) => _saleService = saleService;

        [HttpGet]
        public IActionResult GetAll() => Ok(_saleService.GetAllSales());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var sale = _saleService.GetSaleById(id);
                if (sale == null) return NotFound();
                return Ok(sale);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Sale sale)
        {
            _saleService.CreateSale(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _saleService.DeleteSale(id);
            return NoContent();
        }
    }
}
