﻿

using Newtonsoft.Json;
using Resources.Interface;
using Resources.Models;
using Resources.Response;

namespace Resources.Services;

public class ProductService : IProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
    private readonly FileService _fileService = new FileService(_filePath);
    public Product? CurrentProduct { get; set; } 
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
        catch { }
        return _products;



    }
    public ResultResponse DeleteProduct(string productId)
    {
        // Hämta den senaste produktlistan
        GetAllProductService();

        if (_products.Any())
        {
            var product = _products.FirstOrDefault(p => p.Id.ToString() == productId);

            if (product != null)
            {
                _products.Remove(product); // Ta bort produkten från listan

             
                UpdateList(); 

                return new ResultResponse{Success = true}; // Produkten hittades och raderades
            }
        }

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
            
            var exestingProduct= _products.FirstOrDefault(p => p.Id == product.Id); 

            if (exestingProduct==null)
            {
                return ResultResponse.Failed();
            }
            else
            {
                _products.Remove(exestingProduct);
                exestingProduct = product;
                  _products.Add(exestingProduct);
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
