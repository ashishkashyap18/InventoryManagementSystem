using ManagementSystem.Models;

namespace ManagementSystem.Interface
{
    public interface IProductionServices
    {
        Task<IEnumerable<Production>> GetAllProductions();
        Task<Production> GetProductionById(int id); 
        Task<Production> CreateProduction(Production production);
        Task<bool> UpdateProduction(Production production);
        Task<bool> DeleteProduction(int id);
    }
}
