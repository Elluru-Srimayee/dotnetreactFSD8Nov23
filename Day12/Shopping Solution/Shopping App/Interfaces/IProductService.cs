using Shopping_App.Models;

namespace Shopping_App.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Add(Product product);
    }
}
