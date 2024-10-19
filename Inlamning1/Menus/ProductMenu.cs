using Resources.Interface;
using Resources.Models;
using Resources.Services;

namespace Inlamning1.Menus;

public class ProductMenu
{
    private readonly IProductService _productService;

    public ProductMenu(IProductService productService, ProductUnitMenu productUnitMenu)
    {
        _productService = productService;
        _productUnitMenu = productUnitMenu;
    }

    private readonly ProductUnitMenu _productUnitMenu;

    public void CreatProduct()
    {
        try
        {
            Console.Clear();
            Product product = new Product();
            Category category = new Category();
            product.Category = category;

            Console.Clear();
            Console.WriteLine("Creat new product\n");

            Console.Write("Write product name: ");
            product.ProductName = Console.ReadLine()!;

            product.price = ReadAndValidateDecimal("Enter product price: ");

            Console.WriteLine("Enter product unit: ");
            product.Unit = _productUnitMenu.Unit(product);

            product.Quantity = ReadAndValidateDecimal("Enter product quantity: ");

            Console.Write("Enter product category ID: ");
            category.CategoryId = Console.ReadLine()!;

            Console.Write("Enter product category Name: ");
            category.CategoryName = Console.ReadLine()!;

            var result = _productService.AddToList(product);
            if (result.Success)
            {
                Console.WriteLine($"\nProduct was created successfully.");
            }
            else
            {
                Console.WriteLine($"\n{result.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    public static decimal ReadAndValidateDecimal(string isValid)
    {
        try
        {        
        decimal value;

        while (true)
        {
            Console.Write(isValid);
            string input = Console.ReadLine()!;

            if (decimal.TryParse(input, out value) && value != 0)
            {
                return value;
            }
            else
            {
                Console.WriteLine("Invalid value. Please enter a valid decimal number: ");
            }
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return 0;
    }


    public void ViewAllProducts()
    {
        try { 
        var productsList = _productService.GetAllProductService();

        Console.Clear();
        Console.WriteLine("View All products\n");

        if (productsList.Any())

        {
            foreach (Product product in productsList)
            {
                Console.WriteLine("Product ID:".PadRight(19) + $"{product.Id}" + "\nName: ".PadRight(20) + $"{product.ProductName}" + "\nPrice: ".PadRight(20) + $"{product.price:C}" + "\nQuantity: ".PadRight(20) + $"{product.Quantity} {product.Unit}" + "\nCategory ID: ".PadRight(20) + $"{product.Category.CategoryId}" + "\nCategory Name: ".PadRight(20) + $"{product.Category.CategoryName}\n");
            }
        }
        else
        {
            Console.WriteLine("No product in list");
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public void ViewOneProduct()
    {

        try {
            var productsList = _productService.GetAllProductService();

            Console.Clear();
            Console.WriteLine("View One Product\n");
            Console.Write("Enter product ID to search: ");
            string search = Console.ReadLine()!.Trim();

            if (productsList.Any())
            {
                var product = productsList.FirstOrDefault(p => p.Id.ToString() == search);

                if (product != null)
                {
                    Console.Clear();
                    DisplayProductDetails(product);
                }
                else
                {
                    Console.WriteLine("No product was found.");
                }
            }
            else
            {
                Console.WriteLine("No products in list.");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public void DeleteProduct()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Delete a Product\n");
            Console.Write("Enter product ID : ");

            string search = Console.ReadLine()!.Trim();
            var productsList = _productService.GetAllProductService();
            var product = productsList.FirstOrDefault(p => p.Id.ToString() == search);

            if (product != null)
            {
                DisplayProductDetails(product);

                Console.WriteLine("Are you sure you want to delete this product? (y/n): ");
                var input= Console.ReadLine()!.Trim().ToLower();

                if (input.Equals("y"))
                {
                    var result = _productService.DeleteProduct(search);
                    ;
                    if (result.Success)
                    {
                        Console.WriteLine("Product successfully deleted.");
                    }
                }    
            }
            else
            {
                Console.WriteLine("No product was found.");
            }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();     
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public void UpdateProduct()
    {
        try {
            var productsList = _productService.GetAllProductService();

            Console.Clear();
            Console.WriteLine("Update a Product\n");
            Console.Write("Enter product ID to search: ");
            string search = Console.ReadLine()!.Trim();

            if (productsList.Any())
            {
                var product = productsList.FirstOrDefault(p => p.Id.ToString() == search);
                if (product != null)
                {
                    Console.Clear();
                    DisplayProductDetails(product);
                    Console.WriteLine("Update the product\n");

                    Console.Write("Write product name: ");
                    product.ProductName = Console.ReadLine()!;

                    product.price = ReadAndValidateDecimal("Enter product price: ");

                    Console.WriteLine("Enter product unit");
                    product.Unit = _productUnitMenu.Unit(product);

                    product.Quantity = ReadAndValidateDecimal("Enter product quantity: ");

                    Console.Write("Enter product category ID: ");
                    product.Category.CategoryId = Console.ReadLine()!;

                    Console.Write("Enter product category Name: ");
                    product.Category.CategoryName = Console.ReadLine()!;

                    _productService.Update(product);
                }
                else
                {
                    Console.WriteLine("No product was found.");
                }
            }
            else
            {
                Console.WriteLine("No products in list.");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void DisplayProductDetails(Product product)
    {
        Console.Clear();
        Console.WriteLine("Product ID:".PadRight(19) + $"{product.Id}" + "\nName: ".PadRight(20) + $"{product.ProductName}" + "\nPrice: ".PadRight(20) + $"{product.price:C}" + "\nQuantity: ".PadRight(20) + $"{product.Quantity} {product.Unit}" + "\nCategory ID: ".PadRight(20) + $"{product.Category.CategoryId}" + "\nCategory Name: ".PadRight(20) + $"{product.Category.CategoryName}\n");
    }
}   









