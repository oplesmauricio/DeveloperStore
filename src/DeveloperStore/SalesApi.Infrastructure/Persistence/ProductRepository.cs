using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) => _context = context;

        public void Add(ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var products = _context.Products.Find(id);
            if (products != null)
                _context.Products.Remove(products);

            _context.SaveChanges();
        }

        public IEnumerable<ProductEntity> GetAll() => _context.Products.ToList();

    }
}
