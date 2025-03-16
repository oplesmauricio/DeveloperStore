using System.ComponentModel.DataAnnotations;

namespace SalesApi.Application.DTO.Request
{
    public class ProductDto
    {
        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The price is required.")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
