using Resources.Models;
using Resources.Response;

namespace Resources.Interface
{
    public interface IProductService
    {
        Product? CurrentProduct { get; set; }

        ResultResponse AddToList(Product product);
        ResultResponse DeleteProduct(string productId);
        IEnumerable<Product> GetAllProductService();
        ResultResponse Update(Product product);
    }
}