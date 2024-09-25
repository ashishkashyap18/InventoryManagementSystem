using ManagementSystem.Models;

namespace ManagementSystem.Interface
{
    public interface IUnitServices
    {
        Task<IEnumerable<Unit>> GetAllUnits();
        Task<Unit> GetUnitById(int id);
        Task<Unit> CreateUnit(Unit unit);
        Task<bool> UpdateUnit(Unit unit);
        Task<bool> DeleteUnit(int id);
    }
}
