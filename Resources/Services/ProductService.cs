

using Newtonsoft.Json;
using Resources.Interface;
using Resources.Models;
using Resources.Response;

namespace Resources.Services;

public class ProductService : IProductService
{
    private readonly IFileService _fileService;
    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
        GetAllProductService();
    }

    private List<Product> _products = [];

    public ResultResponse AddToList(Product product)        
    {
        try
        {
            GetAllProductService();
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
                    UpdateList();

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
        catch 
        { }
        return _products;
    }

    public ResultResponse DeleteProduct(string productId)
    {
        try
        {
            GetAllProductService();
            if (_products.Any())
            {
                var product = _products.FirstOrDefault(p => p.Id.ToString() == productId);

                if (product != null)
                {
                    _products.Remove(product);


                    UpdateList();

                    return new ResultResponse { Success = true };
                }
            }
        }
        catch{   }
        return new ResultResponse { Success = false}; 
    }

    public void UpdateList()
    {
        var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
        _fileService.SaveToFile(json);
    }

    public ResultResponse Update(Product product)
    {
        try
        {
            GetAllProductService(); 
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct == null) 
            {
                return ResultResponse.Failed(); 
            }
            else
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.price = product.price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Unit = product.Unit;
                existingProduct.Category = product.Category; 

                UpdateList(); 

                return new ResultResponse { Success = true }; 
            }
        }
        catch
        {
            return ResultResponse.Failed(); 
        }
    }
}
