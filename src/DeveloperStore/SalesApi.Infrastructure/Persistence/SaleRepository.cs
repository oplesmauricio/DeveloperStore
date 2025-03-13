using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) => _context = context;

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        public Sale GetById(int saleId) => _context.Sales.Include(s => s.Items).FirstOrDefault(s => s.Id == saleId);

        public IEnumerable<Sale> GetAll() => _context.Sales.Include(s => s.Items).ToList();

        public void Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
                _context.Sales.Remove(sale);

            _context.SaveChanges();
        }
    }
}
