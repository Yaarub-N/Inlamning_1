

using Resources.Models;
using Resources.Response;
using Resources.Services;

namespace Inlamning1.Menus;

public class ProductMenu
{
    private readonly ProductService _productService = new ProductService();
    private readonly ProductUnitMenu _productUnitMenu = new ProductUnitMenu();

    public void CreatProduct()
    {

        Product product = new Product();
        Category category = new Category();
        product.Category = category;

        Console.Clear();
        Console.WriteLine("Creat new product\n");

        Console.WriteLine("Write product name: ");
        product.ProductName = Console.ReadLine()!;

        product.price = ReadAndValidateDecimal("Enter product price: ");

        Console.WriteLine("Enter product unit");
        product.Unit = _productUnitMenu.Unit(product);
      
        product.Quantity = ReadAndValidateDecimal("Enter product quantity: ");

        Console.WriteLine("Enter product category ID: ");
        category.CategoryId = Console.ReadLine()!;

        Console.WriteLine("Enter product category Name: ");
        category.CategoryName = Console.ReadLine()!;

        var result = _productService.AddToList(product);

        Console.WriteLine(result.Message);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();

    }

    public static decimal ReadAndValidateDecimal(string isValid)
    {
        decimal value;

        while (true)
        {
            Console.WriteLine(isValid);
            string input = Console.ReadLine()!;

            if (decimal.TryParse(input, out value) && value != 0)
            {
                return value;
            }
            else
            {
                Console.WriteLine("Invalid value. Please enter a valid decimal number.");
            }
        }
    }


    public void ViewAllProducts()
    {
        var productsList = _productService.GetAllProductService();

        Console.Clear();
        Console.WriteLine("View All products\n");

        if (productsList.Any())

        {
            foreach (Product product in productsList)
            {
                Console.WriteLine($"Product ID: {product.Id}\nName: {product.ProductName}\nprice: {product.price:C}\nQuantity: {product.Quantity} {product.Unit}\nCategory ID: {product.Category.CategoryId}\nCategory name: {product.Category.CategoryName}");
            }
        }

        else
        {
            Console.WriteLine("No product in list");
        }
       

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }
}


