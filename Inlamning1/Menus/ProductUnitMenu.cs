
using Resources.Models;
using Resources.Response;
using Resources.Services;

namespace ConsoleApp.Menus;

public class ProductUnitMenu
{
    
    public string Unit(Product product)
    {
        Console.WriteLine("1.pcs");
        Console.WriteLine("2.kg");
        Console.WriteLine("3.l");
        Console.WriteLine("4.m");
        string unitChoice = Console.ReadLine()!.Trim();
        switch (unitChoice)
        {
            case "1":
                product.Unit = "pcs";
                
                 break;
            case "2":
                product.Unit = "kg";
                break;
            case "3":
                product.Unit = "l";
                break;
            case "4":
                product.Unit = "m";
                break;
            default:
                Console.Write("invalid value");
                break;
        }
       return product.Unit;
    }

}
