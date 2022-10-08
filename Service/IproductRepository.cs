using Assignment_12_1.Models;

namespace Assignment_12_1.Service
{
    public interface IproductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int? id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int? id);
        int GetMaxId();
    }
}
