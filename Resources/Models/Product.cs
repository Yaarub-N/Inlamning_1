
namespace Resources.Models;

public class Product
{

    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; } = null!;
    public decimal price { get; set; }
    public string Unit { get; set; }=null!;
    public decimal Quantity { get; set; }
    public Category Category { get; set; } = null!;
   
}