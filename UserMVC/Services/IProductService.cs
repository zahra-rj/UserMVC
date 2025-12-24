using UserMVC.Models;

namespace UserMVC.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetList();
        Task<Product> GetByID(int id);
     
        Task Insert(Product product);
        Task Update(Product product);
        Task delete(int id);

    }
}
