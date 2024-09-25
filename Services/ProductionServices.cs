using ManagementSystem.DbConnect;
using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public class ProductionServices : IProductionServices
    {
        private readonly AppDbContext _context;

        public ProductionServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Production> CreateProduction(Production production)
        {
            await _context.Productions.AddAsync(production);
            await _context.SaveChangesAsync();
            return production;
        }

        public async Task<bool> DeleteProduction(int id)
        {
            var production = await GetProductionById(id);
            if(production != null)
            {
                _context.Productions.Remove(production);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Production>> GetAllProductions()
        {
            return await _context.Productions.ToListAsync();
        }

        public async Task<Production> GetProductionById(int id)
        {
            var production = await _context.Productions.FindAsync(id);
            if (production == null) { return null; }
            return production;
        }

        public async Task<bool> UpdateProduction(Production production)
        {
            _context.Productions.Update(production);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
