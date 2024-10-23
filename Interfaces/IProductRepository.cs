using OPIGESHOP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPIGESHOP.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);
        Task<bool> SaveAsync();
    }
}
