

using Resources.Models;

namespace Resources.Response;

public class ResultResponse 
{
    public bool Success { get; set; }
    public string? Message {  get; set; }   
    public Product? Product { get; set; }
    public decimal? Valid {  get; set; }  
   
    public static ResultResponse Succeeded()
    {
        Console.WriteLine($"\nProduct was created successfully.");
        return new ResultResponse { Success = true};
    }

    public static ResultResponse Exists()
    {
        Console.WriteLine("\nProduct Whith the same name already exists.");
        return new ResultResponse { Success = false};
    }
    public static ResultResponse Failed()
    {
        Console.WriteLine("\nSomething went wrong.");
        return new ResultResponse { Success = false};
    }
}


