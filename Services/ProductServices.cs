using ManagementSystem.DbConnect;
using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;

        public ProductServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.Include(p=>p.Unit).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null) return product;
            return null;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
