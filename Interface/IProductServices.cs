using ManagementSystem.Models;

namespace ManagementSystem.Interface
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAllProduct ();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
