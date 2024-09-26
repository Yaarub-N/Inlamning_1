

using Resources.Models;
using Resources.Response;

namespace Resources.Services
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>();
        public ResultResponse AddToList(Product product)

        {

            try
            {
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    return ResultResponse.Failed();

                }
                else
                {
                    if (_products.Any(P => P.ProductName == product.ProductName))
                    {
                        return ResultResponse.Exists();
                    }
                    else
                    {

                        _products.Add(product);


                        return ResultResponse.Succeeded();


                    }
                }
            }
            catch
            {
                return ResultResponse.Failed();

            }

        }
        public IEnumerable<Product> GetAllProductService()
        {

            return _products;


        }

    }
}
