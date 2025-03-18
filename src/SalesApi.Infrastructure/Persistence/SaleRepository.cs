using Microsoft.EntityFrameworkCore;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) => _context = context;

        public void Add(SaleEntity sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Update(SaleEntity sale)
        {
            _context.Sales.Update(sale);
            sale.SaleDate = sale.SaleDate.ToUniversalTime();
            _context.SaveChanges();
        }

        public SaleEntity GetById(int saleId) => _context.Sales.Include(s => s.Items).FirstOrDefault(s => s.Id == saleId);

        public IEnumerable<SaleEntity> GetAll() => _context.Sales.Include(s => s.Items).ToList();

        public void Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale != null)
                _context.Sales.Remove(sale);

            _context.SaveChanges();
        }
    }
}
