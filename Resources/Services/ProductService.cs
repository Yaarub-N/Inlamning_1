

using Newtonsoft.Json;
using Resources.Models;
using Resources.Response;

namespace Resources.Services
{
    public class ProductService
    {
        private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
        private readonly FileService _fileService = new FileService(_filePath);
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
                        var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
                        _fileService.SaveToFile(json);

                        return new ResultResponse { Success = true };


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

            try
            {
                var product = _fileService.GetFromFile();

                if (!string.IsNullOrEmpty(product))
                {
                    _products = JsonConvert.DeserializeObject<List<Product>>(product)!;
                }

            }
            catch { }
            return _products;



        }

    }
}
