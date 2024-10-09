using Resources.Services;

namespace Inlamning1.Menus
{
    public class Menu
    {
        private readonly ProductService _productService = new ProductService();
        private readonly ProductMenu _productMenu = new ProductMenu();
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Main Menu");
                Console.WriteLine("1.Creat product");
                Console.WriteLine("2.View all products");
                Console.WriteLine("3.View One product");
                Console.WriteLine("4.Delete a product");
                Console.WriteLine("5.Update a product");

                Console.WriteLine("6.Exit");

                Console.WriteLine("\nEnter your choice");

                string option = Console.ReadLine()!.Trim();
                switch (option)
                {
                    case "1":
                        _productMenu.CreatProduct();

                        break;
                    case "2":
                        _productMenu.ViewAllProducts();
                        break;
                    case "3":
                        _productMenu.ViewOneProduct();
                        break;
                    case "4":
                        _productMenu.DeleteProduct();
                        break;
                    case "5":
                        _productMenu.updateProduct();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid value try again by pressing ENTER");
                        Console.ReadLine();
                        break;
                }

            }
        }
    }
}
