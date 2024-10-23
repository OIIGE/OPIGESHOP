using Microsoft.EntityFrameworkCore;
using OPIGESHOP.Data;
using OPIGESHOP.Interfaces;
using OPIGESHOP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPIGESHOP.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            return await _context.Products
                                 .Where(p => p.Name.Contains(name))
                                 .ToListAsync();
        }

        public async Task<bool> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
