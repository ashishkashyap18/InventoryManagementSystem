using ManagementSystem.DbConnect;
using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public class UnitServices : IUnitServices
    {
        private readonly AppDbContext _context;

        public UnitServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> CreateUnit(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            return unit;
        }

        public async Task<bool> DeleteUnit(int id)
        {
            var unit = await GetUnitById(id);
            if(unit != null)
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Unit>> GetAllUnits()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit> GetUnitById(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit != null) return unit;
            return null;
        }

        public async Task<bool> UpdateUnit(Unit unit)
        {
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
